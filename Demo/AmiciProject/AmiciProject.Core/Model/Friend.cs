using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmiciProject.Core
{
    public class Friend
    {
        public int FriendId { get; set; }
        public string FullName
        {
            get { return (FirstName + " " + LastName).Trim(); }
            set
            {
                string[] fields = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                FirstName = fields[0];
                if (fields.Length > 1)
                    LastName = fields[1];
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string ZodiacSign { get; set; }
        public Gender Gender { get; set; }
    }
    
}
