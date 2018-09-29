using Quartz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Long.Utilities;
using System.Management.Automation.Runspaces;
using System.Management.Automation;
using System.Collections.ObjectModel;
using BuildServiceTest.Helper;

namespace BuildServiceTest.Job
{
    public class BuildJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine(context.Trigger.StartTimeUtc + " : check build progress status... ");

            if (!IsRun())
            {
                return;
            }

            Console.WriteLine(context.Trigger.StartTimeUtc + " : start build progress... ");

            //using (Runspace runspace = RunspaceFactory.CreateRunspace())
            //{
            //    runspace.Open();
            //    // Create a PowerShell object to run commands in the remote runspace.
            //    using (PowerShell powershell = PowerShell.Create())
            //    {
            //        powershell.Runspace = runspace;
            //        powershell.AddCommand(@"C:\Users\banana\Desktop\getProcessId.ps1");

            //        Collection<PSObject> results = powershell.Invoke();

            //        Console.WriteLine("--------------------------------");
            //        Console.WriteLine("result count:" + results.Count);

            //        for (int i = 0; i < results.Count; i++)
            //        {
            //            Console.WriteLine(
            //                              "{0}:{1}",
            //                              i,
            //                              results[i].ToString()
            //                              );
            //        }

            //        powershell.AddCommand(@"C:\Users\banana\Desktop\fakeBuild.ps1");
            //        Collection<PSObject> results2 = powershell.Invoke();

            //        Console.WriteLine("--------------------------------");
            //        Console.WriteLine("result2 count:" + results.Count);

            //        for (int i = 0; i < results2.Count; i++)
            //        {
            //            Console.WriteLine(
            //                              "{0}:{1}",
            //                              i,
            //                              results2[i].ToString()
            //                              );
            //        }
            //    }

            //    runspace.Close();
            //}
        }

        private bool IsRun()
        {
            string sql = "select * from T_Tasks";
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
    }
}
