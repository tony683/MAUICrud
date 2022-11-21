

using Microsoft.Data.SqlClient;
using System.Data;

namespace MauiCRUD.DataServices
{
    public class DataConnector
    {
        public List<Model.Department> GetDepartments()
        {
            List<Model.Department> depts=new List<Model.Department>();
            
            try
            {
                string sql = "Select * from Department";

                using (var con = new SqlConnection("data source=192.168.1.37\\sqlexpress;initial catalog=InoutsDev;user id=inouts;password=bhupsiii@39;Connect Timeout=60;Encrypt=False;"))
                {
                    con.Open();

                    using (SqlCommand comando = new SqlCommand(sql, con))
                    {

                        using (var reader = comando.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Model.Department tbl = new Model.Department();
                                tbl.Id = (int)reader["Id"];
                               
                                tbl.DepartmentName = Convert.IsDBNull(reader["DepartmentName"]) ? null : (string)reader["DepartmentName"];
                                depts.Add(tbl);
                            }
                        }
                    }

                    con.Close();
                }
            }
            catch (SqlException ex)
            {

            }
            catch (InvalidOperationException ex)
            {

            }
            finally
            {
                // conne.Close();
            }
            return depts;
        }
        public List<Model.DefectCategory> GetDefectCateogires()
        {
            List<Model.DefectCategory> defects = new List<Model.DefectCategory>();

            try
            {
                string sql = "Select * from DefectCategory";

                using (var con = new SqlConnection("data source=192.168.1.37\\sqlexpress;initial catalog=InoutsDev;user id=inouts;password=bhupsiii@39;Connect Timeout=60;Encrypt=False;"))
                {
                    con.Open();

                    using (SqlCommand comando = new SqlCommand(sql, con))
                    {

                        using (var reader = comando.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Model.DefectCategory tbl = new Model.DefectCategory();
                                tbl.DefectID = (int)reader["DefectID"];

                                tbl.Category = Convert.IsDBNull(reader["Category"]) ? null : (string)reader["Category"];
                                defects.Add(tbl);
                            }
                        }
                    }

                    con.Close();
                }
            }
            catch (SqlException ex)
            {

            }
            catch (InvalidOperationException ex)
            {

            }
            finally
            {
                // conne.Close();
            }
            return defects;
        }

        public List<Model.Reason> GetReasons()
        {
            List<Model.Reason> reasons = new List<Model.Reason>();

            try
            {
                string sql = "Select * from Reason";

                using (var con = new SqlConnection("data source=192.168.1.37\\sqlexpress;initial catalog=InoutsDev;user id=inouts;password=bhupsiii@39;Connect Timeout=60;Encrypt=False;"))
                {
                    con.Open();

                    using (SqlCommand comando = new SqlCommand(sql, con))
                    {

                        using (var reader = comando.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Model.Reason tbl = new Model.Reason();
                                tbl.ReasonId = (int)reader["ReasonId"];

                                tbl.ReasonText = Convert.IsDBNull(reader["ReasonText"]) ? null : (string)reader["ReasonText"];
                                reasons.Add(tbl);
                            }
                        }
                    }

                    con.Close();
                }
            }
            catch (SqlException ex)
            {

            }
            catch (InvalidOperationException ex)
            {

            }
            finally
            {
                // conne.Close();
            }
            return reasons;
        }

        public List<Model.DefectQuantity> GetDefectQuantities()
        {
            List<Model.DefectQuantity> reasons = new List<Model.DefectQuantity>();

            try
            {
                string sql = "Select * from DefectQuantity";

                using (var con = new SqlConnection("data source=192.168.1.37\\sqlexpress;initial catalog=InoutsDev;user id=inouts;password=bhupsiii@39;Connect Timeout=60;Encrypt=False;"))
                {
                    con.Open();

                    using (SqlCommand comando = new SqlCommand(sql, con))
                    {

                        using (var reader = comando.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Model.DefectQuantity tbl = new Model.DefectQuantity();
                                tbl.Id = (int)reader["Id"];

                                tbl.Quantity = Convert.IsDBNull(reader["Quantity"]) ? null : (string)reader["Quantity"];
                                reasons.Add(tbl);
                            }
                        }
                    }

                    con.Close();
                }
            }
            catch (SqlException ex)
            {

            }
            catch (InvalidOperationException ex)
            {

            }
            finally
            {
                // conne.Close();
            }
            return reasons;
        }

        public List<Model.CorrctiveAction> GetCorrctiveAction()
        {
            List<Model.CorrctiveAction> reasons = new List<Model.CorrctiveAction>();

            try
            {
                string sql = "Select * from CorrctiveAction";

                using (var con = new SqlConnection("data source=192.168.1.37\\sqlexpress;initial catalog=InoutsDev;user id=inouts;password=bhupsiii@39;Connect Timeout=60;Encrypt=False;"))
                {
                    con.Open();

                    using (SqlCommand comando = new SqlCommand(sql, con))
                    {

                        using (var reader = comando.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Model.CorrctiveAction tbl = new Model.CorrctiveAction();
                                tbl.Id = (int)reader["Id"];

                                tbl.Action = Convert.IsDBNull(reader["Action"]) ? null : (string)reader["Action"];
                                reasons.Add(tbl);
                            }
                        }
                    }

                    con.Close();
                }
            }
            catch (SqlException ex)
            {

            }
            catch (InvalidOperationException ex)
            {

            }
            finally
            {
                // conne.Close();
            }
            return reasons;
        }

        public bool InsertPartRecord(Model.Part task)
        {
            try
            {

                string sql = "INSERT INTO Part (PartID,FoundDeptID,SourceDeptID,DefectID,DefectQTY,Reason,CorrectActID,Comments) VALUES(@PartID,@FoundDeptID,@SourceDeptID,@DefectID,@DefectQTY,@Reason,@CorrectActID,@Comments)";

                using (var con = new SqlConnection("data source=192.168.1.37\\sqlexpress;initial catalog=InoutsDev;user id=inouts;password=bhupsiii@39;Connect Timeout=60;Encrypt=False;"))
                {
                    con.Open();

                    using (SqlCommand comando = new SqlCommand(sql, con))
                    {
                        comando.Parameters.Add("@PartID", SqlDbType.Int, 1000).Value = task.PartID;
                        comando.Parameters.Add("@FoundDeptID", SqlDbType.Int, 1000).Value = task.FoundDeptID;
                        comando.Parameters.Add("@SourceDeptID", SqlDbType.Int, 1000).Value = task.SourceDeptID;
                        comando.Parameters.Add("@DefectID", SqlDbType.Int, 255).Value = task.DefectID;
                        comando.Parameters.Add("@DefectQTY", SqlDbType.Int, 800).Value = task.DefectQTY;
                        comando.Parameters.Add("@Reason", SqlDbType.Int, 100).Value = task.Reason;
                        comando.Parameters.Add("@CorrectActID", SqlDbType.Int, 500).Value = task.CorrectActID;
                        comando.Parameters.Add("@Comments", SqlDbType.VarChar, 500).Value = task.Comments;

                        comando.CommandType = CommandType.Text;
                        comando.ExecuteNonQuery();
                    }

                    con.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
