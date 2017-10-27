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
    public class FriendsStoreII: IFriendsStore
    {
        DbConnection cn;
        public FriendsStoreII(string cnStr = null)
        {
            if (cnStr == null)
                cnStr = Global.AmiciIIConnString;
            cn = new OleDbConnection(cnStr);
        }

        public IEnumerable<Friend> ReadAll()
        {
            cn.Open();
            var dr = cn.CreateCommand()
                .Sql("SELECT * FROM Iscritti")
                .ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                var friend = new Friend
                {
                    FriendId = dr.GetInt32(0),
                    FirstName = dr.GetString(1),
                    LastName = dr.GetString(2),
                    City = dr.GetString(3),
                    ZodiacSign = dr.GetString(4),
                    Gender = dr.GetString(5)
                };
                
                yield return friend;
            }
            dr.Close();
        }
        public void Add(Friend f)
        {
            cn.Open();

            cn.CreateCommand()
                .Sql($"INSERT INTO Iscritti (Nome, Cognome, Città, SegnoZodiacale, Sesso) VALUES (?, ?, ?, ?, ?)")
                .AddParams(f.FirstName, f.LastName, f.City, f.ZodiacSign, f.Gender)
                .ExecuteNonQuery();

            f.FriendId = cn.GetLastIdentity();
            cn.Close();
        }

        public bool Delete(Friend f)
        {
            cn.Open();

            var rowCount = cn.CreateCommand()
                .Sql($"DELETE FROM Iscritti WHERE IscrittoId = ?")
                .AddParams(f.FriendId)
                .ExecuteNonQuery();

            cn.Close();
            return rowCount > 0;
        }

        public bool Update(Friend f)
        {
            cn.Open();

            var rowCount = cn.CreateCommand()
                .Sql($"UPDATE Iscritti SET Nome = ?, Cognome = ?, Città = ?, SegnoZodiacale = ?, Sesso = ? WHERE IscrittoId = ?")
                .AddParams(f.FirstName, f.LastName, f.City, f.ZodiacSign, f.Gender, f.FriendId)
                .ExecuteNonQuery();

            cn.Close();
            return rowCount > 0;
        }
        
    }
}
