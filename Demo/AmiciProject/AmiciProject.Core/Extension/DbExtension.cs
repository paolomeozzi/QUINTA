using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;


namespace AmiciProject.Core
{
    public static class DbExtension
    {
        public static DbCommand Sql(this DbCommand cmd, string text)
        {
            cmd.CommandText = text;
            return cmd;
        }
        public static DbCommand AddParams(this DbCommand cmd, params object[] args)
        {
            foreach (var arg in args)
            {
                DbParameter pa = cmd.CreateParameter();
                pa.ParameterName = "?";
                pa.DbType = DbType.String;
                pa.Value = arg;

                if (arg is DateTime)
                    pa.DbType = DbType.DateTime;
                else if (arg is int)
                    pa.DbType = DbType.Int32;
                else
                    pa.Value = arg.ToString();  //!per gestire i tipi di dati che non sono convertibili
                                                // in stringa (perché non è implementata IConvertible)
                //TODO: aggiungi altri tipi di dati

                cmd.Parameters.Add(pa);
            }
            return cmd;
        }

        public static int GetLastIdentity(this DbConnection cn)
        {
            bool cnOpen = cn.State == ConnectionState.Open;
            if (cnOpen == false)
                cn.Open();

            int identity = (int) cn.CreateCommand().Sql("SELECT @@identity").ExecuteScalar();

            if (cnOpen == false)
                cn.Close();

            return identity;
        }
    }
}
