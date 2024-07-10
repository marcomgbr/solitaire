using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire
{
    [Serializable]
    class UserCollection
    {
        private int userSequence;
        private List<User> users = new List<User>();

        public User CreateUser()
        {
            User response = new User(++this.userSequence);
            return response;
        }

        public bool AddUser(User u)
        {
            if(u.Username == null || u.Username.Length < 1 
                || u.Alias == null || u.Alias.Length < 1)
            {
                return false;
            }

            if (FindByUsername(u.Username) != null)
            {
                return false;
            }

            this.users.Add(u);

            return true;
        }

        public User FindByUsername(string username)
        {
            return this.users.SingleOrDefault(user => user.Username == username);
        }

        public List<User> GetUsers()
        {
            return this.users;
        }
    }
}
