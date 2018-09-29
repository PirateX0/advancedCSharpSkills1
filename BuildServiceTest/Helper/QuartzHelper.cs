using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BuildServiceTest.Job;
using BuildServiceTest.Models;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace BuildServiceTest.Helper
{
    class QuartzHelper
    {
 

        public static void ScheduleByInterval()
        {
            IScheduler sched = new StdSchedulerFactory().GetScheduler();
            {
                JobDetailImpl jdBossReport = new JobDetailImpl("jdTest", typeof(BuildJob));

                var builder = CalendarIntervalScheduleBuilder.Create();
                builder.WithInterval(3, IntervalUnit.Second);
                IMutableTrigger triggerBossReport = builder.Build();
                triggerBossReport.Key = new TriggerKey("triggerTest");

                sched.ScheduleJob(jdBossReport, triggerBossReport);
                sched.Start();
            }
            {
                JobDetailImpl jdBossReport = new JobDetailImpl("jdTest2", typeof(KillJob));

                var builder = CalendarIntervalScheduleBuilder.Create();
                builder.WithInterval(3, IntervalUnit.Second);
                IMutableTrigger triggerBossReport = builder.Build();
                triggerBossReport.Key = new TriggerKey("triggerTest2");

                sched.ScheduleJob(jdBossReport, triggerBossReport);
                sched.Start();
            }
        }
    }
}
