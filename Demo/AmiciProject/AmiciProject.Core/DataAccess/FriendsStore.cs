using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;

namespace AmiciProject.Core
{
    public class FriendsStore: IFriendsStore
    {
        DbConnection cn;
        public FriendsStore(string cnStr = null)
        {
            if (cnStr == null)
                cnStr = Global.AmiciIConnString;
            cn = new OleDbConnection(cnStr);
        }

        public IEnumerable<Friend> ReadAll()
        {
            cn.Open();
            var dr = cn.CreateCommand()
                .Sql("SELECT 'M', * FROM Ragazzi UNION SELECT 'F', * FROM Ragazze")
                .ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                var friend = new Friend
                {
                    Gender = dr.GetString(0),
                    FullName = dr.GetString(1),
                    City = dr.GetString(2),
                    ZodiacSign = dr.GetString(3),
                    
                };
                
                yield return friend;
            }
            dr.Close();
        }
        public void Add(Friend f)
        {
            cn.Open();
            var tableName = TableNameFromGender(f.Gender);

            cn.CreateCommand()
                .Sql($"INSERT INTO {tableName} (Nome, Città, SegnoZodiacale) VALUES (?, ?, ?)")
                .AddParams(f.FullName, f.City, f.ZodiacSign)
                .ExecuteNonQuery();

            cn.Close();
        }

        public bool Delete(Friend f)
        {
            cn.Open();

            var cmd = cn.CreateCommand()
                .Sql($"DELETE FROM Ragazzi WHERE Nome = ?")
                .AddParams(f.FullName);

            var rowCount = cmd.ExecuteNonQuery();
            if (rowCount == 0)
                rowCount = cmd.Sql($"DELETE FROM Ragazze WHERE Nome = ?").ExecuteNonQuery();

            cn.Close();
            return rowCount > 0;
        }

        public bool Update(Friend f)
        {
            cn.Open();
            var tableName = TableNameFromGender(f.Gender);

            var rowCount = cn.CreateCommand()
                .Sql($"UPDATE {tableName} SET Città = ?, SegnoZodiacale = ? WHERE Nome = ?")
                .AddParams(f.City, f.ZodiacSign, f.FullName)
                .ExecuteNonQuery();

            cn.Close();
            return rowCount > 0;
        }

        private string TableNameFromGender(Gender g)
        {
            return g == Gender.Male ? "Ragazzi" : "Ragazze";
        }

       
    }
}
