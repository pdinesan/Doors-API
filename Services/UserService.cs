using Doors_API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Doors_API.Services
{
    public class UserService
    {
        private List<User> _users = new List<User>
        {
            new User { Id = 1, UserName = "user1", Password = "password1", Role = "admin"},
            new User { Id = 2, UserName = "user2", Password = "password2", Role = "guest"}
        };

        public string Login(string userName, string password)
        {
            var user = _users.SingleOrDefault(x => x.UserName == userName && x.Password == password);

            // return null if user not found
            if (user == null)
            {
                return string.Empty;
            }

            TokenService tokenSvc = new TokenService();
            return tokenSvc.GenerateToken(user.UserName);
        }

    }
}