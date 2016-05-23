using System;
using System.Data;
using System.Data.SqlClient;

namespace ReportAutomation.Models
{
    public class ReportTabManager
    {
        public DataSet GetSQLScript(int ReportID, int TabID)
        {
            try
            {
                string SQL = "ReportAutomationGenerateReportSQLScript";
                using (SqlConnection conn = new SqlConnection(WebAppSettings.Instance.ConnectString))
                {
                    using (SqlCommand cmd = new SqlCommand(SQL, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ReportID", SqlDbType = SqlDbType.Int, Value = ReportID, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@TabID", SqlDbType = SqlDbType.Int, Value = TabID, Direction = ParameterDirection.Input });

                        DataSet dst = new DataSet("Report");
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dst);
                        dst.Tables[0].TableName = "TSQL";
                        dst.Tables[1].TableName = "ReportDetails";

                        return dst;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public string GetXmlData(int ReportID, int TabID)
        {
            try
            {
                string SQL = "ReportAutomationGenerateReportXmlData";
                using (SqlConnection conn = new SqlConnection(WebAppSettings.Instance.ConnectString))
                {
                    using (SqlCommand cmd = new SqlCommand(SQL, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ReportID", SqlDbType = SqlDbType.Int, Value = ReportID, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@TabID", SqlDbType = SqlDbType.Int, Value = TabID, Direction = ParameterDirection.Input });
                        conn.Open();
                        string retVal = (string)cmd.ExecuteScalar();
                        return retVal;
                    }
                }
            }
            catch (Exception e)
            {                
                throw e;
            }            
        }

        public string GetXmlValidData(int ReportID, int TabID)
        {
            try
            {
                string SQL = "ReportAutomationGenerateReportXmlValidData";
                using (SqlConnection conn = new SqlConnection(WebAppSettings.Instance.ConnectString))
                {
                    using (SqlCommand cmd = new SqlCommand(SQL, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ReportID", SqlDbType = SqlDbType.Int, Value = ReportID, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@TabID", SqlDbType = SqlDbType.Int, Value = TabID, Direction = ParameterDirection.Input });
                        conn.Open();
                        object retVal = cmd.ExecuteScalar();
                        return (retVal.ToString() == string.Empty) ? string.Empty : (string)retVal;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public string GetXmlInvalidData(int ReportID, int TabID)
        {
            try
            {
                string SQL = "ReportAutomationGenerateReportXmlInvalidData";
                using (SqlConnection conn = new SqlConnection(WebAppSettings.Instance.ConnectString))
                {
                    using (SqlCommand cmd = new SqlCommand(SQL, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ReportID", SqlDbType = SqlDbType.Int, Value = ReportID, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@TabID", SqlDbType = SqlDbType.Int, Value = TabID, Direction = ParameterDirection.Input });
                        conn.Open();
                        object retVal = cmd.ExecuteScalar();
                        return (retVal.ToString() == string.Empty) ? string.Empty : (string)retVal;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public string GetKeyField(int ReportID, int TabID)
        {
            try
            {
                string SQL = "ReportAutomationGenerateReportKeyFieldGet";
                using (SqlConnection conn = new SqlConnection(WebAppSettings.Instance.ConnectString))
                {
                    using (SqlCommand cmd = new SqlCommand(SQL, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ReportID", SqlDbType = SqlDbType.Int, Value = ReportID, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@TabID", SqlDbType = SqlDbType.Int, Value = TabID, Direction = ParameterDirection.Input });
                        conn.Open();
                        object retVal = cmd.ExecuteScalar();
                        return (retVal.ToString() == string.Empty) ? string.Empty : (string)retVal;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public bool UpdateXmlData(int ReportID, int TabID, string XmlData)
        {
            try
            {
                string SQL = "ReportAutomationGenerateReportXMLDataUpdate";
                using (SqlConnection conn = new SqlConnection(WebAppSettings.Instance.ConnectString))
                {
                    using (SqlCommand cmd = new SqlCommand(SQL, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ReportID", SqlDbType = SqlDbType.Int, Value = ReportID, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@TabID", SqlDbType = SqlDbType.Int, Value = TabID, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@XmlData", SqlDbType = SqlDbType.Xml, Value = XmlData, Direction = ParameterDirection.Input });
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return (rowsAffected != 0);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public bool UpdateXmlValidData(int ReportID, int TabID, string XmlValidData)
        {
            try
            {
                string SQL = "ReportAutomationGenerateReportXMLValidDataUpdate";
                using (SqlConnection conn = new SqlConnection(WebAppSettings.Instance.ConnectString))
                {
                    using (SqlCommand cmd = new SqlCommand(SQL, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ReportID", SqlDbType = SqlDbType.Int, Value = ReportID, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@TabID", SqlDbType = SqlDbType.Int, Value = TabID, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@XmlValidData", SqlDbType = SqlDbType.Xml, Value = XmlValidData, Direction = ParameterDirection.Input });
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return (rowsAffected != 0);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public bool UpdateXmlInvalidData(int ReportID, int TabID, string XmlInvalidData)
        {
            try
            {
                string SQL = "ReportAutomationGenerateReportXMLInvalidDataUpdate";
                using (SqlConnection conn = new SqlConnection(WebAppSettings.Instance.ConnectString))
                {
                    using (SqlCommand cmd = new SqlCommand(SQL, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ReportID", SqlDbType = SqlDbType.Int, Value = ReportID, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@TabID", SqlDbType = SqlDbType.Int, Value = TabID, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@XmlInvalidData", SqlDbType = SqlDbType.Xml, Value = XmlInvalidData, Direction = ParameterDirection.Input });
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return (rowsAffected != 0);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public void CreateTable(SqlConnection sqlcon, DataTable dt)
        {
            string exists = null;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM sysobjects where name = '" + dt.TableName + "'", sqlcon);
                exists = cmd.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                exists = null;
            }


            // if does not exist


            if (exists == null)
            {
                // selecting each column of the datatable to create a table in the database


                foreach (DataColumn dc in dt.Columns)
                {
                    if (exists == null)
                    {
                        SqlCommand createtable = new SqlCommand("CREATE TABLE " + dt.TableName + " (" + dc.ColumnName + " varchar(MAX))", sqlcon);
                        createtable.ExecuteNonQuery();
                        exists = dt.TableName;
                    }
                    else
                    {
                        SqlCommand addcolumn = new SqlCommand("ALTER TABLE " + dt.TableName + " ADD " + dc.ColumnName + " varchar(MAX)", sqlcon);
                        addcolumn.ExecuteNonQuery();
                    }
                }


                // copying the data from datatable to database table


                using (SqlBulkCopy bulkcopy = new SqlBulkCopy(sqlcon))
                {
                    bulkcopy.DestinationTableName = dt.TableName;
                    bulkcopy.WriteToServer(dt);
                }
            }
            // if table exists, just copy the data to the destination table in the database
            else
            {
                using (SqlBulkCopy bulkcopy = new SqlBulkCopy(sqlcon))
                {
                    bulkcopy.DestinationTableName = dt.TableName;
                    bulkcopy.WriteToServer(dt);
                }
            }
        }

    }
}
