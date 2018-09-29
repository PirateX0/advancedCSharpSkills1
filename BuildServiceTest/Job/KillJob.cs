using Quartz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildServiceTest.Helper;

namespace BuildServiceTest.Job
{
    public class KillJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine(context.Trigger.StartTimeUtc + " : check kill progress status... ");

            if (!IsRun())
            {
                return;
            }

            Console.WriteLine(context.Trigger.StartTimeUtc + " : start kill progress... ");

            Kill();
            Stop();

            Console.WriteLine(context.Trigger.StartTimeUtc + " : finish kill progress... ");
        }

        private bool IsRun()
        {
            string sql = "select * from T_Tasks where Name = 'KillJob'";
            DataTable dataTable = SqlHelper.executeDataTable(sql);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (dataRow["Status"].ToString() == "1")
                {
                    return true;
                }
            }
            return false;
        }

        private void Kill()
        {
            string sql = "update  T_Tasks set status='0'  where Name = 'BuildJob'";
             SqlHelper.executeNonQuery(sql);
          
        }

        private void Stop()
        {
            string sql = "update  T_Tasks set status='0'  where Name = 'KillJob'";
            SqlHelper.executeNonQuery(sql);

        }
    }
}
