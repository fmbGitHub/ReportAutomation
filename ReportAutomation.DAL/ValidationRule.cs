using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportAutomation.Models
{
    public class ValidationRule : RetVals
    {
        public int ReportID { get; set; }
        public int TabID { get; set; }
        public int ValidationRuleID { get; set; }
        public string FieldName { get; set; }
        public string ValidationType { get; set; }
        public string RuleText { get; set; }
        public bool IsActive { get; set; }
        public int PosOrder { get; set; }
    }
}
