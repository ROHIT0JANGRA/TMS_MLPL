using CodeLock.Areas.Ewaybill.Controllers;
using System;
using System.Threading;
using CodeLock.Models;
using CodeLock.Areas.Ewaybill.Repository;
using System.Threading.Tasks;

namespace CodeLock.Scheduler
{
    public class DataSyncScheduler
    {
        private Timer timer;
        private readonly object syncLock = new object();
        private readonly IEwaybillRepository ewaybillRepository;
        public DataSyncScheduler(IEwaybillRepository ewaybillRepository)
        {
            this.ewaybillRepository = ewaybillRepository;
        }

        public DataSyncScheduler()
        {
        }

        public void Start()
        {
            lock (syncLock)
            {
                if (timer == null)
                {
                    // Schedule task to run daily at 3:00 PM
                    DateTime now = DateTime.Now;
                    DateTime scheduledTime = new DateTime(now.Year, now.Month, now.Day, 15, 0, 0); // 3:00 PM
                    if (now > scheduledTime)
                    {
                        scheduledTime = scheduledTime.AddDays(1); // Schedule for tomorrow if past today
                    }
                    int dueTime = (int)(scheduledTime - DateTime.Now).TotalMilliseconds;

                    timer = new Timer(ExecuteTask, null, dueTime, Timeout.Infinite);
                }
            }
        }

        public void Stop()
        {
            lock(syncLock)
            {
                if (timer != null)
                {
                    timer.Dispose();
                    timer = null;
                }
            }
        }

        private async void ExecuteTask(object state)
        {
            try
            {
                DateTime previousDay = DateTime.Now.AddDays(-1);
                string fetchEwbDate = previousDay.ToString("yyyyMMdd");
                var model = new EwaybillGetDetailFromWebNoAndDate { EwbDate = fetchEwbDate, StateId = 0 };

                // Use ewaybillRepository to submit data
                await ewaybillRepository.SubmitDataInDbAllStates(model);
                await Task.Delay(5000);
            }
            catch (Exception ex)
            {
                // Handle exceptions (log or notify)
            }
            finally
            {
                lock (syncLock)
                {
                    if (timer != null)
                    {
                        Start(); // Reschedule task for next day
                    }
                }
            }
        }

        public bool IsRunning()
        {
            lock (syncLock)
            {
                return timer != null; // Check if timer is initialized and running
            }
        }
    }
}