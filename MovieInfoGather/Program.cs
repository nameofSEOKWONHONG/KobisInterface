using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieInfoGather
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
#if DEBUG
            if (args.Length < 2) return;

            if (args.Length == 2 && args[0] == "-test")
            {
                MessageBox.Show("디버깅 테스트");
            }

            Mutex processMutex;
            var isMutexCreate = false;

            try
            {
                processMutex = new Mutex(true, "Global\\" + args[1], out isMutexCreate);

                if (!isMutexCreate)
                {
                    Console.WriteLine($"{args[1]} is Already Running! So Quit.");
                }

                MessageBox.Show($"{args[1]} 를 실행 합니다. \nOK 버튼을 누르면 실행 합니다.", $"{args[1]} running.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e2)
            {
                Console.WriteLine($"error message : {e2.Message}");
                return;
            }
#endif
            Application.ThreadException += Application_ThreadException;

            ServiceBase[] servicesToRun;
            using (var svc = new ServiceHost())
            {
                servicesToRun = new ServiceBase[]
                {
                svc
                };

                if (args.Length == 2 && args[0] == "-test")
                {
                    MessageBox.Show("Click OK");
                    svc.ServiceStart();

                    try
                    {
                        Console.WriteLine("서비스가 실행 중입니다.");
                        MessageBox.Show("OK 버튼을 누르면 종료합니다.", "Service Host is running.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception e3)
                    {
                        Console.WriteLine($"ServiceBase.Run Error : {e3.Message}");
                    }

                    svc.ServiceStop();
                }
                else
                {
                    try
                    {
                        ServiceBase.Run(servicesToRun);
                    }
                    catch (Exception e4)
                    {
                        ExceptionHandle(e4);
                    }
                }

#if DEBUG
                processMutex.ReleaseMutex();
            }
            processMutex.Dispose();
#endif

        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ExceptionHandle(e.Exception);
        }

        static void ExceptionHandle(Exception ex)
        {
            FileLogger.WriteLog(Consts.LOG_FILE_NAME, "SecurePrivacyFileEmailSender", "void Main", ex.Message, LogCode.Error, ex);
        }
    }
}
