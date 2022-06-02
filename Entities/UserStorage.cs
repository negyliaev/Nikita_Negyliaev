using System;
using System.Collections.Generic;
using System.Text;

namespace WebUI.Entities
{
    class UserStorage
    {
        private string _username;
        private string _password;

        public string Username { get { return _username; } set { _username = value; } }
        public string Password { get { return _password; } set { _password = value; } }

        public UserStorage(string username, string password)
        {
            this._username = username;
            this._password = password;
        }
    }
}
