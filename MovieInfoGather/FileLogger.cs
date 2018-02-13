using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace MovieInfoGather
{
    public class FileLogger
    {
        private static string _source = "MovieInfoGather Logger";
        private static string _log = "MovieInfoGather Logger";

        /// <summary>
        /// 특정 파일에 기록할 로그를 작성한다. (주로 주문정보에 사용해야 함.)
        /// 예) D:\[로그폴더]\S20181231000111.txt 형식으로 기록함.
        /// </summary>
        /// <param name="fullFileName">전체파일이름 (경로 + 파일명)</param>
        /// <param name="owner">소유자(메서드 또는 클래스.메서드)</param>
        /// <param name="title">로그 제목</param>
        /// <param name="message"></param>
        /// <param name="logCode"></param>
        /// <param name="e"></param>
        public static void WriteLog(string fullFileName, string owner, string title, string message, LogCode logCode = LogCode.Information, Exception e = null)
        {
            var fullFilePath = Path.GetDirectoryName(fullFileName);
            if (!Directory.Exists(fullFilePath))
            {
                Directory.CreateDirectory(fullFilePath);
            }

            var fullLog = string.Empty;

            if (e == null)
            {
                fullLog += $"{DateTime.Now.ToString("HH:mm:ss")} ({logCode.ToString()} [{owner}] [{title}] : {message})";
            }
            else
            {
                fullLog += $"{DateTime.Now.ToString("HH:mm:ss")} ({logCode.ToString()} [{owner}] [{title}] : {message})" + Environment.NewLine;
                fullLog += "Exception Message : " + e.Message + Environment.NewLine;
                fullLog += "Stack Trace : " + e.StackTrace;
            }

            var ext = Path.GetExtension(fullFileName);
            var fileNameWithoutExt = Path.GetFileNameWithoutExtension(fullFileName);
            var lastExtIndex = fullFileName.LastIndexOf(".", StringComparison.CurrentCulture);

            fullFileName = fullFileName.Substring(0, lastExtIndex) + DateTime.Now.ToString("yyyyMMdd") + ext;

            try
            {
                using (var sw = new StreamWriter(fullFileName, true, Encoding.UTF8, 4096))
                {
                    sw.WriteLine(fullLog);
                    sw.Close();
                    sw.Dispose();
                }
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists(_source))
                {
                    EventLog.CreateEventSource(_source, _log);
                    EventLog.WriteEntry(_source, ex.Message, EventLogEntryType.Error, 234);
                }
                else
                {
                    EventLog.WriteEntry(_source, ex.Message, EventLogEntryType.Error, 234);
                }
            }
        }
    }

    public enum LogCode
    {
        Information = 0,
        Success = 1,
        Error = -1,
        Failure = -2,
        Warning = -10,
        SystemError = -101,
        ApplicationError = -201
    }
}
