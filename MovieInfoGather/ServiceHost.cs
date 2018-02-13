using MovieInfoGather.Models;
using MovieInfoGather.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MovieInfoGather
{
    public class ServiceHost : ServiceBase
    {
        readonly Timer _timer;
        bool _isLock;

        public ServiceHost()
        {
            _timer = new Timer
            {
                Interval = 1000 * int.Parse(Consts.INTERVAL) //10 * (1000 * 60); //1 hour
            };
            _timer.Elapsed += _timer_Elapsed;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!_isLock)
            {
                _isLock = true;

                FileLogger.WriteLog(Consts.LOG_FILE_NAME, "SerivceHost", "타이머 실행", "타이머가 실행 됩니다.", LogCode.Information);

                try
                {
                    
                    
                }
                catch (Exception ex)
                {
                    FileLogger.WriteLog(Consts.LOG_FILE_NAME, "SerivceHost", "타이머 오류 발생", ex.Message, LogCode.Error, ex);
                }

                _isLock = false;
            }
        }

        public void ServiceStart()
        {
            _timer.Start();
        }

        public void ServiceStop()
        {
            _timer.Stop();
        }

        protected override void OnStart(string[] args)
        {
            _timer.Start();
        }

        protected override void OnStop()
        {
            _timer.Stop();
        }
    }
}
