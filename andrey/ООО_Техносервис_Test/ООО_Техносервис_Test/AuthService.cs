using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ООО_Техносервис_Test
{
    internal class AuthService
    {
        private Dictionary<string, string> users = new Dictionary<string, string>
        {
            { "user1", "password1"},
            { "user2", "password2"},
            { "user3", "password3"},
            { "user4", "password4"},
            { "user5", "password5"}
        };

        public bool Authntificate(string login, string password)
        {
            return users.ContainsKey(login) && users[login] == password;
        }

    }
}
