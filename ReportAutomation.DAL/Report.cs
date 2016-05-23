using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ReportAutomation.Models
{
    [Serializable]
    public class Report : RetVals
    {
        public int ReportID { get; set; }
        public string ReportName { get; set; }
        public string FinalQCPerson { get; set; }
        public string FinalQCEmail { get; set; }
        public string BadQCPerson { get; set; }
        public string BadQCEmail { get; set; }
        public int ExecutionInterval { get; set; }
        public DateTime? NextExecution { get; set; }
        public DateTime? LastExecution { get; set; }
        public string LastExecutionStatus { get; set; }
        public bool IsActive { get; set; }
        public string ServerName { get; set; }
    }
}
