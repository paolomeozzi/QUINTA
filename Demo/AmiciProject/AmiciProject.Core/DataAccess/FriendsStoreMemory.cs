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
    public class FriendsStoreMemory : IFriendsStore
    {
        static List<Friend> data = new List<Friend>();
        static int generatedId = 0;
        public FriendsStoreMemory()
        {
            GenerateFriends();
        }
        public IEnumerable<Friend> ReadAll()
        {
            return data;
        }
        public void Add(Friend f)
        {
            f.FriendId = ++generatedId;
            data.Add(f);
        }

        public bool Delete(Friend friend)
        {
            var index = data.FindIndex(f => f.FriendId == friend.FriendId);
            if (index == -1)
                return false;
            data.RemoveAt(index);
            return true;
        }

        public bool Update(Friend friend)
        {
            var index = data.FindIndex(f => f.FriendId == friend.FriendId);
            if (index == -1)
                return false;
            data[index] = friend;
            return true;
        }

        private void Add(string fn, string ln, string city, string zs, Gender g)
        {
            var f = new Friend
            {
                FirstName = fn,
                LastName = ln,
                City = city,
                ZodiacSign = zs,
                Gender = g
            };
            Add(f);
        }

        private void GenerateFriends()
        {
            Add("Giorgio", "Rossi", "Roma", "Scorpione", Gender.Male);
            Add("Andrea", "Verdi", "Firenze", "Gemelli", Gender.Male);
            Add("Filippo", "Bianchi", "Firenze", "Ariete", Gender.Male);
            Add("Francesco", "Bardi", "Milano", "Pesci", Gender.Male);
            Add("Stefano", "Poggioli", "Napoli", "Gemelli", Gender.Male);
            Add("Gianni", "Andreini", "Pesaro", "Capricorno", Gender.Male);
            Add("Sonia", "Neri", "Milano", "Leone", Gender.Female);
            Add("Donatella", "Milani", "Catania", "Ariete", Gender.Female);
            Add("Sara", "Boschi", "Torino", "Gemelli", Gender.Female);
            Add("Katia", "Sassoli", "Roma", "Capricorno", Gender.Female);
            Add("Gianna", "Nannini", "Roma", "Scorpione", Gender.Female);



        }

    }
}
