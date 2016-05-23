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

                    //serverEvent.InnerHtml = serverEvent.InnerHtml + span + id;
                }
                if (keyval.Key == "isActive") 
                {
                    ReportObject.IsActive = Convert.ToInt32(keyval.Value) ==1;
                    //serverEvent.InnerHtml = serverEvent.InnerHtml + span + id;
                }
                if (keyval.Key == "FinalQCPerson")
                {
                    ReportObject.FinalQCPerson = keyval.Value.ToString();
                    //serverEvent.InnerHtml = serverEvent.InnerHtml + span + id;
                }
                if (keyval.Key == "FinalQCEmail")
                {
                    ReportObject.FinalQCEmail = keyval.Value.ToString();
                    //serverEvent.InnerHtml = serverEvent.InnerHtml + span + id;
                }
                if (keyval.Key == "BadQCPerson")
                {
                    ReportObject.BadQCPerson= keyval.Value.ToString();
                    //serverEvent.InnerHtml = serverEvent.InnerHtml + span + id;
                }
            }
            sfTextboxReportName.Value = reportName;

            //sfGridReports.DataBind();
        }

    
    }
}