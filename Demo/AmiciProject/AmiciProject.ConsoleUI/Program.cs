using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmiciProject.ConsoleUI
{
    using Core;
    class Program
    {
        static void Main(string[] args)
        {
            //TestFriendStore();
            TestFriendIIStore();
            //TestFriendMemory();
            //TestFriendManager();
            Console.ReadKey();
        }

        static void TestFriendStore()
        {
            var store = new FriendsStore();
            Visualizza(store.ReadAll());
            
            var friend = new Friend
            {
                FullName = "Giorgio",
                City = "Roma",
                Gender = Gender.Male,
                ZodiacSign = "Gemelli"
            };

            store.Add(friend);
            Console.WriteLine("{0} -> INSERITO", friend.FullName);

            friend.City = "Milano";
            if (store.Update(friend))
            {
                Console.WriteLine("{0} -> MODIFICATO", friend.FullName);
            }            

            if (store.Delete(friend))
            {
                Console.WriteLine("{0} -> ELIMINATO", friend.FullName);
            }
        }

        static void TestFriendIIStore()
        {
            var store = new FriendsStoreII();
            Visualizza(store.ReadAll());

            var friend = new Friend
            {
                FullName = "Giorgio Andreini",
                City = "Roma",
                Gender = Gender.Male,
                ZodiacSign = "Gemelli"
            };

            store.Add(friend);
            Console.WriteLine("{0} -> INSERITO", friend.FullName);

            friend.City = "Milano";            
            if (store.Update(friend))
            {
                Console.WriteLine("{0} -> MODIFICATO", friend.FullName);
            }

            if (store.Delete(friend))
            {
                Console.WriteLine("{0} -> ELIMINATO", friend.FullName);
            }
        }

        static void TestFriendMemory()
        {
            var store = new FriendsStoreMemory();
            Visualizza(store.ReadAll());

            var friend = new Friend
            {
                FullName = "Giorgio",
                City = "Roma",
                Gender = Gender.Male,
                ZodiacSign = "Gemelli"
            };

            store.Add(friend);
            Console.WriteLine("{0} -> INSERITO", friend.FullName);

            friend.City = "Milano";
            if (store.Update(friend))
            {
                Console.WriteLine("{0} -> MODIFICATO", friend.FullName);
            }

            if (store.Delete(friend))
            {
                Console.WriteLine("{0} -> ELIMINATO", friend.FullName);
            }
        }

        static void TestFriendManager()
        {
            var fm = new FriendManager(new FriendsStoreMemory());
            Visualizza(fm.AllFriends());

            var friend = new Friend
            {
                FullName = "Giorgio, Bianchi",
                City = "Roma",
                Gender = Gender.Male,
                ZodiacSign = "Gemelli"
            };

            fm.Add(friend);
            Console.WriteLine("{0} -> INSERITO", friend.FullName);

            friend.City = "Milano";
            if (fm.Update(friend))
            {
                Console.WriteLine("{0} -> MODIFICATO", friend.FullName);
            }

            if (fm.Delete(friend))
            {
                Console.WriteLine("{0} -> ELIMINATO", friend.FullName);
            }

            Console.WriteLine("\nAmici di Milano");
            Visualizza(fm.MaleFriendsOfCity("Milano"));

            Console.WriteLine("\nAmiche dello scorpione");
            Visualizza(fm.FemaleFriendsOfZodiacSign("Scorpione"));

            Console.WriteLine("\nCoppie");
            var couples = fm.CouplesOn((f1, f2) => f1.Gender == Gender.Male && f2.Gender == Gender.Female);
            //var couples = fm.CouplesOn((f1, f2) => f1.ZodiacSign == f2.ZodiacSign);
            Visualizza(couples);

        }

        static void Visualizza(IEnumerable<Friend> friends)
        {
            //Console.WriteLine("{0,-20} {1, -15} {2}\n", "Nominativo", "Città", "Sesso");
            foreach (var f in friends)
                Console.WriteLine("{0,-20} {1, -15} {2}", f.FullName, f.City, f.Gender);
        }

        static void Visualizza(IEnumerable<Couple> couples)
        {
            foreach (var c in couples)
                Console.WriteLine("{0,-20} {1, -20}", c.Friend1.FullName, c.Friend2.FullName);
        }
    }
}
