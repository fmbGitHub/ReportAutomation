using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ReportAutomation.Models
{
    public class ReportManager
    {
        public List<Report> Select()
        {
            string SQL = "ReportAutomationReportSelect";
            try
            {
                using (SqlConnection conn = new SqlConnection(WebAppSettings.Instance.ConnectString))
                {
                    using (SqlCommand cmd = new SqlCommand(SQL, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        //Console.WriteLine( Convert.ToDateTime(["04/05/2016 12:00:00 a.m."]));

                        var query =
                          (from dr in dt.AsEnumerable()
                           select new Report
                           {
                               ReportID = Convert.ToInt32(dr["ReportID"]),
                               ReportName = dr["ReportName"].ToString(),
                               FinalQCPerson = dr["FinalQCPerson"].ToString(),
                               FinalQCEmail = dr["FinalQCEmail"].ToString(),
                               BadQCPerson = dr["BadQCPerson"].ToString(),
                               BadQCEmail = dr["BadQCEmail"].ToString(),
                               ExecutionInterval = Convert.ToInt32(dr["ExecutionInterval"]),
                               NextExecution = Convert.ToDateTime(dr["NextExecution"]), //Convert.ToDateTime(dr["NextExecution"]),
                               LastExecution = Convert.ToDateTime(dr["LastExecution"]),
                               LastExecutionStatus = dr["LastExecutionStatus"].ToString(),
                               IsActive = Convert.ToInt32(dr["IsActive"]) == 1,
                               ServerName = dr["ServerName"].ToString(),
                               RetCode = true,
                               RetMessage = "Data loaded successfully"
                           });

                        return query.ToList();
                    }
                }
            }
            catch (Exception e)
            {
                List<Report> list = new List<Report>();
                Report entity = new Report();
                entity.RetCode = false;
                entity.RetMessage = e.Message;
                list.Add(entity);
                return list;
            }
           
        }

        public Report SelectByPK(int ReportID)
        {
            string SQL = "ReportAutomationReportSelectByPK";
            try
            {
                using (SqlConnection conn = new SqlConnection(WebAppSettings.Instance.ConnectString))
                {
                    using (SqlCommand cmd = new SqlCommand(SQL, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ReportID", SqlDbType = SqlDbType.Int, Value = ReportID, Direction = ParameterDirection.Input });
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        Report entity =
                          (from dr in dt.AsEnumerable()
                           select new Report
                           {
                               ReportID = Convert.ToInt32(dr["ReportID"]),
                               ReportName = dr["ReportName"].ToString(),
                               FinalQCPerson = dr["FinalQCPerson"].ToString(),
                               FinalQCEmail = dr["FinalQCEmail"].ToString(),
                               BadQCPerson = dr["BadQCPerson"].ToString(),
                               BadQCEmail = dr["BadQCEmail"].ToString(),
                               ExecutionInterval = Convert.ToInt32(dr["ExecutionInterval"]),
                               NextExecution = Convert.ToDateTime(dr["NextExecution"]),
                               LastExecution = Convert.ToDateTime(dr["LastExecution"]),
                               LastExecutionStatus = dr["LastExecutionStatus"].ToString(),
                               IsActive = Convert.ToInt32(dr["IsActive"]) == 1,
                               ServerName = dr["ServerName"].ToString(),
                               RetCode = true,
                               RetMessage = "Data loaded successfully"
                           }).FirstOrDefault();

                        return entity;
                    }
                }
            }
            catch (Exception e)
            {
                Report entity = new Report();
                entity.RetCode = false;
                entity.RetMessage = e.Message;
                return entity;
            }
            
        }

        public void Insert(Report entity)
        {
            string SQL = "ReportAutomationReportInsert";
            try
            {
                using (SqlConnection conn = new SqlConnection(WebAppSettings.Instance.ConnectString))
                {
                    using (SqlCommand cmd = new SqlCommand(SQL, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ReportName", SqlDbType = SqlDbType.NVarChar, Size = 400, Value = entity.ReportName, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@FinalQCPerson", SqlDbType = SqlDbType.NVarChar, Size = 100, Value = entity.FinalQCPerson, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@FinalQCEmail", SqlDbType = SqlDbType.NVarChar, Size = 100, Value = entity.FinalQCEmail, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@BadQCPerson", SqlDbType = SqlDbType.NVarChar, Size = 100, Value = entity.BadQCPerson, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@BadQCEmail", SqlDbType = SqlDbType.NVarChar, Size = 100, Value = entity.BadQCEmail, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ExecutionInterval", SqlDbType = SqlDbType.Int, Value = entity.ExecutionInterval, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@NextExecution", SqlDbType = SqlDbType.DateTime, Value = entity.NextExecution, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@LastExecution", SqlDbType = SqlDbType.DateTime, Value = entity.LastExecution, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@LastExecutionStatus", SqlDbType = SqlDbType.NVarChar, Size = 50, Value = entity.LastExecutionStatus, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@IsActive", SqlDbType = SqlDbType.Bit, Value = entity.IsActive ? 1 : 0, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ServerName", SqlDbType = SqlDbType.NVarChar, Size = 50, Value = entity.ServerName, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ReportID", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@RetCode", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@RetMessage", SqlDbType = SqlDbType.NVarChar, Size = 255, Direction = ParameterDirection.Output });

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        entity.ReportID = (int)cmd.Parameters["@ReportID"].Value;
                        entity.RetCode = ((int)(cmd.Parameters["@RetCode"].Value)) == 1;
                        entity.RetMessage = cmd.Parameters["@RetMessage"].Value.ToString();
                    }
                }
            }
            catch (Exception e)
            {
                entity.RetCode = false;
                entity.RetMessage = e.Message;
            }
            
        }

        public void Update(Report entity)
        {
            string SQL = "ReportAutomationReportUpdate";
            try
            {
                using (SqlConnection conn = new SqlConnection(WebAppSettings.Instance.ConnectString))
                {
                    using (SqlCommand cmd = new SqlCommand(SQL, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ReportID", SqlDbType = SqlDbType.Int, Value = entity.ReportID, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ReportName", SqlDbType = SqlDbType.NVarChar, Size = 400, Value = entity.ReportName, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@FinalQCPerson", SqlDbType = SqlDbType.NVarChar, Size = 100, Value = entity.FinalQCPerson, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@FinalQCEmail", SqlDbType = SqlDbType.NVarChar, Size = 100, Value = entity.FinalQCEmail, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@BadQCPerson", SqlDbType = SqlDbType.NVarChar, Size = 100, Value = entity.BadQCPerson, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@BadQCEmail", SqlDbType = SqlDbType.NVarChar, Size = 100, Value = entity.BadQCEmail, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ExecutionInterval", SqlDbType = SqlDbType.Int, Value = entity.ExecutionInterval, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@NextExecution", SqlDbType = SqlDbType.DateTime, Value = entity.NextExecution, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@LastExecution", SqlDbType = SqlDbType.DateTime, Value = entity.LastExecution, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@LastExecutionStatus", SqlDbType = SqlDbType.NVarChar, Size = 50, Value = entity.LastExecutionStatus, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@IsActive", SqlDbType = SqlDbType.Bit, Value = entity.IsActive ? 1 : 0, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ServerName", SqlDbType = SqlDbType.NVarChar, Size = 50, Value = entity.ServerName, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@RetCode", SqlDbType = SqlDbType.Int, Size = 255, Direction = ParameterDirection.Output });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@RetMessage", SqlDbType = SqlDbType.NVarChar, Size = 255, Direction = ParameterDirection.Output });
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        entity.RetCode = ((int)(cmd.Parameters["@RetCode"].Value)) == 1;
                        entity.RetMessage = cmd.Parameters["@RetMessage"].Value.ToString();
                    }
                }
            }
            catch (Exception e)
            {
                entity.RetCode = false;
                entity.RetMessage = e.Message;
            }            
        }

        public void Delete(Report entity)
        {
            string SQL = "ReportAutomationReportDelete";

            try
            {
                using (SqlConnection conn = new SqlConnection(WebAppSettings.Instance.ConnectString))
                {
                    using (SqlCommand cmd = new SqlCommand(SQL, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ReportID", SqlDbType = SqlDbType.Int, Value = entity.ReportID, Direction = ParameterDirection.Input });
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        entity.RetCode = ((int)(cmd.Parameters["@RetCode"].Value)) == 1;
                        entity.RetMessage = cmd.Parameters["@RetMessage"].Value.ToString();
                    }
                }
            }
            catch (Exception e)
            {
                entity.RetCode = false;
                entity.RetMessage = e.Message;                
            }            
        }
    }
}
