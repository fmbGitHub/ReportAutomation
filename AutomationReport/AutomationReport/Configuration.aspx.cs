using System;
using System.Collections.Generic;
using ReportAutomation.Models;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutomationReport
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void LoadData()
        {
            ReportAutomation.Models.ReportManager rpm = new ReportAutomation.Models.ReportManager();
            sfGridReports.DataSource = rpm.Select();
            sfGridReports.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            } 
        }

        

        protected void sfGridReports_ServerRowSelected(object sender, Syncfusion.JavaScript.Web.GridEventArgs e)
        {
            //e.Arguments[; 

            int selectedrowindex = Convert.ToInt32(e.Arguments["rowIndex"]);
            Report ReportObject = new Report(); 

            Dictionary<string, object> data = e.Arguments["data"] as Dictionary<string, object>;
            foreach (KeyValuePair<string, object> keyval in data)
            {
                if (keyval.Key == "ReportName")
                {
                    ReportObject.ReportName = keyval.Value.ToString();
                }
                if (keyval.Key == "IsActive") 
                {
                    ReportObject.IsActive = Convert.ToBoolean( keyval.Value);
                }
                if (keyval.Key == "FinalQCPerson")
                {
                    ReportObject.FinalQCPerson = keyval.Value.ToString();
                }
                if (keyval.Key == "FinalQCEmail")
                {
                    ReportObject.FinalQCEmail = keyval.Value.ToString();
                }
                if (keyval.Key == "BadQCPerson")
                {
                    ReportObject.BadQCPerson= keyval.Value.ToString();
                }
                if (keyval.Key == "BadQCEmail")
                {
                    ReportObject.BadQCEmail = keyval.Value.ToString();
                }
                if (keyval.Key == "ExecutionInterval")
                {
                    ReportObject.ExecutionInterval = Convert.ToInt32( keyval.Value);
                }
                if (keyval.Key == "NextExecution")
                {
                    ReportObject.NextExecution = Convert.ToDateTime(keyval.Value.ToString());
                }
                if (keyval.Key == "LastExecution")
                {
                    ReportObject.LastExecution = Convert.ToDateTime(keyval.Value.ToString());
                }
                if (keyval.Key == "LastExecutionStatus")
                {
                    ReportObject.LastExecutionStatus = (keyval.Value.ToString());
                }
                if (keyval.Key == "ServerName")
                {
                    ReportObject.ServerName = (keyval.Value.ToString());
                }
            }
            //Sets the Textboxes
            sfCheckboxActive.Checked = ReportObject.IsActive;
            sfTextboxReportName.Value = ReportObject.ReportName;
            sfTextboxGoodQCPerson.Value = ReportObject.FinalQCPerson;
            sfGoodQCEmail.Value = ReportObject.FinalQCEmail;
            sfBadQCPerson.Value = ReportObject.BadQCPerson;
            sfBadQCEmail.Value = ReportObject.BadQCEmail;
            sfTextboxExecutionInteval.Value = ReportObject.ExecutionInterval.ToString();
            sfTextboxNextExecution.Value = ReportObject.NextExecution.ToString();
            sfTextboxLastExecution.Value = ReportObject.LastExecution.ToString();
            sfTextboxLastExecutionStatus.Value = ReportObject.LastExecutionStatus.ToString();
            sfCheckboxActive.Value = ReportObject.IsActive.ToString();

            //sets the 
            lblCurrentReport.Text = ReportObject.ReportName;

            //sfGridReports.DataBind();

            // this is a test
        }

    
    }
}