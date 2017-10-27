using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmiciProject.Core
{
    public class FriendManager
    {
        private IFriendsStore store;
        public FriendManager(IFriendsStore store = null)
        {
            if (store == null)
                store = new FriendsStoreMemory();
            this.store = store;
        }

        public IEnumerable<Friend> AllFriends()
        {
            return store.ReadAll();
        }


        public IEnumerable<Friend> MaleFriendsOfCity(string city)
        {
            return AllFriends().Where(f => f.City == city && f.Gender == Gender.Male);
        }

        public IEnumerable<Friend> FemaleFriendsOfZodiacSign(string sign)
        {
            return AllFriends().Where(f => f.ZodiacSign == sign && f.Gender == Gender.Female);
        }

        public IEnumerable<Couple> CouplesOn(Func<Friend, Friend, bool> predicate)
        {
            var friends = AllFriends().ToList();
            for (int i = 0; i < friends.Count-1; i++)
            {
                for (int j = i+1; j < friends.Count; j++)
                {
                    var f1 = friends[i];
                    var f2 = friends[j];
                    if (predicate(f1, f2))
                        yield return new Couple { Friend1 = f1, Friend2 = f2 };
                }
            }
        }
        public void Add(Friend f)
        {
            store.Add(f);
        }
        public bool Delete(Friend f)
        {
            return store.Delete(f);
        }
        public bool Update(Friend f)
        {
            return store.Update(f);
        }
    }
}
