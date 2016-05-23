using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportAutomation.Models
{
    public class ReportTab
    {
        public int ReportID { get; set; }
        public int TabID { get; set; }
        public string TabName { get; set; }
        public bool IsActive { get; set; }
        public int PosOrder { get; set; }
        public string SQLScript { get; set; }
        public string KeyField { get; set; }
    }
}
