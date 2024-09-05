using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Utilitarios.Modelo
{
    public class DbConection
    {
        private SqlConnection _conn;
        public bool OnTransaction = false;
        public SqlTransaction Transaction;
        String connString = "Server=192.168.0.103\\SQLEXPRESS;Database=GestorFinanceiro;User Id=sa;Password=Le@09052018";

        public DbConection()
        {
            _conn = new SqlConnection(connString);
        }

        public bool TestConnection()
        {
            try
            {
                DataTable dt;
                dt = GetDataTable("SELECT GETDATE()");
                return true;
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetDataSet(SqlCommand cmd)
        {
            try
            {
                var ds = new DataSet();

                OpenConnection(cmd);

                var dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(ds);

                CloseConnection();

                dataAdapter = null;

                return ds;
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetDataTable(SqlCommand cmd)
        {
            try
            {
                DataTable dt = null;
                var ds = GetDataSet(cmd);
                if (ds.Tables.Count > 0)
                    dt = ds.Tables[0];

                return dt;
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetDataSet(string query, Hashtable param, bool isProcedure)
        {
            try
            {
                var cmd = FromQueryToSqlCommand(query, isProcedure);
                AddParamsToSqlCommand(cmd, param);
                return GetDataSet(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDataTable(string query)
        {
            return GetDataTable(query, null, false);
        }

        public DataTable GetDataTable(string query, bool isProcedure)
        {
            return GetDataTable(query, null, isProcedure);
        }

        public DataTable GetDataTable(string query, Hashtable param, bool isProcedure)
        {
            try
            {
                var cmd = FromQueryToSqlCommand(query, isProcedure);
                AddParamsToSqlCommand(cmd, param);
                return GetDataTable(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object ExecuteScalar(string query, Hashtable param)
        {
            return ExecuteScalar(query, param, false);
        }

        public object ExecuteScalar(string query, Hashtable param, bool isProcedure)
        {
            try
            {
                var cmd = FromQueryToSqlCommand(query, isProcedure);
                AddParamsToSqlCommand(cmd, param);
                return ExecuteScalar(cmd);
            }
            catch
            {
                throw;
            }
        }

        public object ExecuteScalar(SqlCommand cmd)
        {
            try
            {
                object result = null;

                OpenConnection(cmd);
                result = cmd.ExecuteScalar();
                CloseConnection();

                return result;
            }
            catch
            {
                throw;
            }
        }

        public int ExecuteNonQueryProcedure(string query, Hashtable param)
        {
            try
            {
                var cmd = FromQueryToSqlCommand(query, true);
                AddParamsToSqlCommand(cmd, param);
                return ExecuteNonQuery(cmd);
            }
            catch
            {
                throw;
            }
        }

        private int ExecuteNonQuery(SqlCommand cmd)
        {
            try
            {
                int result = 0;

                OpenConnection(cmd);
                result = cmd.ExecuteNonQuery();
                CloseConnection();

                return result;
            }
            catch
            {
                throw;
            }
        }


        public void OpenTransaction()
        {
            try
            {
                if (_conn.State == ConnectionState.Closed) _conn.Open();
                Transaction = _conn.BeginTransaction();
                OnTransaction = true;
                // Set_xact_abort_on_database();
            }
            catch
            {
                throw;
            }
        }

        public void CommitTransaction()
        {
            try
            {
                if (OnTransaction) Transaction.Commit();
                OnTransaction = false;
                CloseConnection();
            }
            catch
            {
                throw;
            }
        }

        public void AbortTransaction()
        {
            try
            {
                if (OnTransaction) Transaction.Rollback();
                OnTransaction = false;
                CloseConnection();
            }
            catch
            {
                throw;
            }
        }

        public void DestroyConnection()
        {
            AbortTransaction();
            _conn.Dispose();
            _conn = null;
        }

        #region Private methods

        private void CloseConnection()
        {
            if (!OnTransaction && _conn.State == ConnectionState.Open) _conn.Close();
        }

        private void OpenConnection(SqlCommand cmd)
        {
            if (cmd == null) throw new ArgumentNullException("cmd");
            if (OnTransaction) cmd.Transaction = Transaction;
            if (_conn.State == ConnectionState.Closed) _conn.Open();

            cmd.Connection = _conn;
        }

        private SqlCommand FromQueryToSqlCommand(string query, bool isProc)
        {
            return isProc ? new SqlCommand(query) { CommandType = CommandType.StoredProcedure } : new SqlCommand(query) { CommandType = CommandType.Text };
        }

        private void AddParamsToSqlCommand(SqlCommand cmd, Hashtable param)
        {
            if (param != null && cmd != null)
            {
                foreach (DictionaryEntry item in param)
                {
                    object paramValue = item.Value;
                    if (paramValue == null)
                        paramValue = DBNull.Value;

                    cmd.Parameters.Add(new SqlParameter(item.Key.ToString(), paramValue));
                }
            }
        }

        #endregion
    }
}
