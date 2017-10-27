using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmiciProject.Core
{
    public interface IFriendsStore
    {
        IEnumerable<Friend> ReadAll();
        void Add(Friend f);
        bool Delete(Friend f);
        bool Update(Friend f);

    }
}
