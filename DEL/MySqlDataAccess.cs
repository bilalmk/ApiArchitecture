using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Del
{
    public static class ConnectionString
    {
        public static string connectionString = string.Empty;
    }
    public class MySqlDataAccess:IDataAccess
    {
        //public static string connectionString = string.Empty;
        //private static MySqlConnection sqlConn = new MySqlConnection();
        //public Hashtable CurrentSqlParameters = new Hashtable();


        public string connectionString { get; set; }
        public Hashtable CurrentSqlParameters { get; set; }
        
        public MySqlDataAccess(string connectionString)
        {
            CurrentSqlParameters = new Hashtable();
            this.connectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            
            return new MySqlConnection(connectionString);
        }

        public object GetSingle(string sqlQuery)
        {
            object result = null;
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(sqlQuery, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        result = cmd.ExecuteScalar();
                    }
                    conn.Close();
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return result;
        }


        public DataTable GetData(string sqlQuery)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(sqlQuery, conn))
                    {
                        cmd.CommandType = CommandType.Text;

                        foreach (DictionaryEntry entry in CurrentSqlParameters)
                            cmd.Parameters.AddWithValue(entry.Key.ToString(), entry.Value);

                        using (var dataAdapter = new MySqlDataAdapter(cmd))
                        {
                            dataAdapter.Fill(dataTable);
                        }
                    }
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                 throw new Exception(ex.Message,ex);
            }
            finally
            {
                CurrentSqlParameters.Clear();
            }

            return dataTable;
        }

        public DataTable GetDataSP(string storedProcedureName)
        {
            DataTable dataTable = new DataTable();
            try
            { 
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(storedProcedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach(DictionaryEntry entry in CurrentSqlParameters)
                            cmd.Parameters.AddWithValue(entry.Key.ToString(), entry.Value);
                        using (var dataAdapter = new MySqlDataAdapter(cmd))
                        {
                            dataAdapter.Fill(dataTable);
                        }
                    }
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                CurrentSqlParameters.Clear();
            }

            return dataTable;
        }

        public bool ExecuteNonQuery(string sqlQuery)
        {
            bool success = false;
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using(var cmd = new MySqlCommand(sqlQuery, conn))
                    {
                        foreach (DictionaryEntry entry in CurrentSqlParameters)
                            cmd.Parameters.AddWithValue(entry.Key.ToString(), entry.Value);

                        cmd.CommandType = CommandType.Text;
                        if (cmd.ExecuteNonQuery() > 0)
                            success = true;
                    }
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                CurrentSqlParameters.Clear();
            }
            return success;
        }


        public bool InsertNewRecord(string sqlQuery)
        {
            bool success = false;
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(sqlQuery, conn))
                    {
                        foreach (DictionaryEntry entry in CurrentSqlParameters)
                            cmd.Parameters.AddWithValue(entry.Key.ToString(), entry.Value);

                        cmd.CommandType = CommandType.Text;
                        if (cmd.ExecuteNonQuery() > 0)
                            success = true;
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                CurrentSqlParameters.Clear();
            }
            return success;
        }


        public IDataReader ExecuteReader(string sqlQuery)
        {
            IDataReader dataReader = null;
            try
            {
                using(var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(sqlQuery, conn))
                    {
                        foreach (DictionaryEntry entry in CurrentSqlParameters)
                            cmd.Parameters.AddWithValue(entry.Key.ToString(), entry.Value);

                        dataReader = cmd.ExecuteReader();
                    }
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                CurrentSqlParameters.Clear();
            }
            return dataReader;
        }

        public string GetLastInsertedID()
        {
            string result = string.Empty;
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand())
                    {
                        cmd.CommandText = "Select LAST_INSERT_ID() as 'id'";
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = conn;
                        result = cmd.ExecuteScalar().ToString();
                    }
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public DataTable SelectRecords(string sqlQuery)
        {
            throw new NotImplementedException();
        }
    }
}