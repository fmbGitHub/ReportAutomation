using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ReportAutomation.Models
{
    public class ValidationRuleManager
    {
        public List<ValidationRule> Select()
        {
            try
            {
                string SQL = "ReportAutomationValidationRuleSelect";
                using (SqlConnection conn = new SqlConnection(WebAppSettings.Instance.ConnectString))
                {
                    using (SqlCommand cmd = new SqlCommand(SQL, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        var query =
                          (from dr in dt.AsEnumerable()
                           select new ValidationRule
                           {
                               ReportID = Convert.ToInt32(dr["ReportID"]),
                               TabID = Convert.ToInt32(dr["TabID"]),
                               ValidationRuleID = Convert.ToInt32(dr["ValidationRuleID"]),
                               FieldName = dr["FieldName"].ToString(),
                               ValidationType = dr["ValidationType"].ToString(),
                               RuleText = dr["RuleText"].ToString(),
                               IsActive = Convert.ToInt32(dr["IsActive"]) == 1 ? true : false,
                               PosOrder = Convert.ToInt32(dr["PosOrder"]),
                               RetCode = true,
                               RetMessage = "Data loaded successfully"
                           });

                        return query.ToList();
                    }
                }
            }
            catch (Exception e)
            {
                List<ValidationRule> list = new List<ValidationRule>();
                ValidationRule entity = new ValidationRule();
                entity.RetCode = false;
                entity.RetMessage = e.Message;
                list.Add(entity);
                return list;
            }
        }

        public List<ValidationRule> SelectByReportIDTabID(int ReportID, int TabID)
        {
            try
            {
                string SQL = "ReportAutomationValidationRuleSelectByReportIDTabID";
                using (SqlConnection conn = new SqlConnection(WebAppSettings.Instance.ConnectString))
                {
                    using (SqlCommand cmd = new SqlCommand(SQL, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ReportID", SqlDbType = SqlDbType.Int, Value = ReportID, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@TabID", SqlDbType = SqlDbType.Int, Value = TabID, Direction = ParameterDirection.Input });
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        var query =
                          (from dr in dt.AsEnumerable()
                           select new ValidationRule
                           {
                               ReportID = Convert.ToInt32(dr["ReportID"]),
                               TabID = Convert.ToInt32(dr["TabID"]),
                               ValidationRuleID = Convert.ToInt32(dr["ValidationRuleID"]),
                               FieldName = dr["FieldName"].ToString(),
                               ValidationType = dr["ValidationType"].ToString(),
                               RuleText = dr["RuleText"].ToString(),
                               IsActive = Convert.ToInt32(dr["IsActive"]) == 1 ? true : false,
                               PosOrder = Convert.ToInt32(dr["PosOrder"]),
                               RetCode = true,
                               RetMessage = "Data loaded successfully"
                           });

                        return query.ToList();
                    }
                }
            }
            catch (Exception e)
            {
                List<ValidationRule> list = new List<ValidationRule>();
                ValidationRule entity = new ValidationRule();
                entity.RetCode = false;
                entity.RetMessage = e.Message;
                list.Add(entity);
                return list;
            }            
        }

        public ValidationRule SelectByPK(int ReportID, int TabID, int ValidationRuleID)
        {
            try
            {
                string SQL = "ReportAutomationValidationRuleSelectByReportIDTabID";
                using (SqlConnection conn = new SqlConnection(WebAppSettings.Instance.ConnectString))
                {
                    using (SqlCommand cmd = new SqlCommand(SQL, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ReportID", SqlDbType = SqlDbType.Int, Value = ReportID, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@TabID", SqlDbType = SqlDbType.Int, Value = TabID, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ValidationRuleID", SqlDbType = SqlDbType.Int, Value = ValidationRuleID, Direction = ParameterDirection.Input });
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        ValidationRule entity =
                          (from dr in dt.AsEnumerable()
                           select new ValidationRule
                           {
                               ReportID = Convert.ToInt32(dr["ReportID"]),
                               TabID = Convert.ToInt32(dr["TabID"]),
                               ValidationRuleID = Convert.ToInt32(dr["ValidationRuleID"]),
                               FieldName = dr["FieldName"].ToString(),
                               ValidationType = dr["ValidationType"].ToString(),
                               RuleText = dr["RuleText"].ToString(),
                               IsActive = Convert.ToInt32(dr["IsActive"]) == 1 ? true : false,
                               PosOrder = Convert.ToInt32(dr["PosOrder"]),
                               RetCode = true,
                               RetMessage = "Data loaded successfully"
                           }).FirstOrDefault();

                        return entity;
                    }
                }
            }
            catch (Exception e)
            {
                ValidationRule entity = new ValidationRule();
                entity.RetCode = false;
                entity.RetMessage = e.Message;
                return entity;
            }
        }

        public void Insert(ValidationRule entity)
        {
            string SQL = "ReportAutomationValidationRuleInsert";
            try
            {
                using (SqlConnection conn = new SqlConnection(WebAppSettings.Instance.ConnectString))
                {
                    using (SqlCommand cmd = new SqlCommand(SQL, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ReportID", SqlDbType = SqlDbType.Int, Value = entity.ReportID, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@TabID", SqlDbType = SqlDbType.Int, Value = entity.TabID, Direction = ParameterDirection.Input });                        
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@FieldName", SqlDbType = SqlDbType.VarChar, Size = 50, Value = entity.FieldName, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ValidationType", SqlDbType = SqlDbType.VarChar, Size = 50, Value = entity.ValidationType, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@RuleText", SqlDbType = SqlDbType.VarChar, Size = 50, Value = entity.RuleText, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@IsActive", SqlDbType = SqlDbType.Bit, Value = entity.IsActive, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PosOrder", SqlDbType = SqlDbType.Int, Value = entity.PosOrder, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ValidationRuleID", SqlDbType = SqlDbType.Int, Value = entity.ValidationRuleID, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@RetCode", SqlDbType = SqlDbType.Int, Value = entity.RetCode, Direction = ParameterDirection.Output });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@RetMessage", SqlDbType = SqlDbType.NVarChar, Size = 255, Value = entity.RetCode, Direction = ParameterDirection.Output });
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

        public void Update(ValidationRule entity)
        {
            string SQL = "ReportAutomationValidationRuleUpdate";
            try
            {
                using (SqlConnection conn = new SqlConnection(WebAppSettings.Instance.ConnectString))
                {
                    using (SqlCommand cmd = new SqlCommand(SQL, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ReportID", SqlDbType = SqlDbType.Int, Value = entity.ReportID, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@TabID", SqlDbType = SqlDbType.Int, Value = entity.TabID, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ValidationRuleID", SqlDbType = SqlDbType.Int, Value = entity.ValidationRuleID, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@FieldName", SqlDbType = SqlDbType.VarChar, Size = 50, Value = entity.FieldName, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ValidationType", SqlDbType = SqlDbType.VarChar, Size = 50, Value = entity.ValidationType, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@RuleText", SqlDbType = SqlDbType.VarChar, Size = 50, Value = entity.RuleText, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@IsActive", SqlDbType = SqlDbType.Bit, Value = entity.IsActive, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PosOrder", SqlDbType = SqlDbType.Int, Value = entity.PosOrder, Direction = ParameterDirection.Input });                        
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@RetCode", SqlDbType = SqlDbType.Int, Value = entity.RetCode, Direction = ParameterDirection.Output });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@RetMessage", SqlDbType = SqlDbType.NVarChar, Size = 255, Value = entity.RetCode, Direction = ParameterDirection.Output });
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

        public void Delete(ValidationRule entity)
        {
            string SQL = "ReportAutomationValidationRuleDelete";

            try
            {
                using (SqlConnection conn = new SqlConnection(WebAppSettings.Instance.ConnectString))
                {
                    using (SqlCommand cmd = new SqlCommand(SQL, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ReportID", SqlDbType = SqlDbType.Int, Value = entity.ReportID, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@TabID", SqlDbType = SqlDbType.Int, Value = entity.TabID, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ValidationRuleID", SqlDbType = SqlDbType.Int, Value = entity.ValidationRuleID, Direction = ParameterDirection.Input });
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
