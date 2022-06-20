using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiMS_projekat.Model;
using SiMS_projekat.Service;

namespace SiMS_projekat.Controller
{
    class UserController
    {
        private UserService userService = new UserService();

        public UserController()
        {

        }

        public List<User> GetAll()
        {
            return userService.GetAll();
        }

        public User Add(User user)
        {
            return userService.Add(user);
        }

        public User Update(User user)
        {
            return userService.Update(user);
        }

        public void Delete(int id)
        {
            userService.Delete(id);
        }
    }
}
