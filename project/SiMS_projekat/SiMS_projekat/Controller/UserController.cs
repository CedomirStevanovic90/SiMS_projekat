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
        private IUserService userService = new UserService();

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

        public User GetById(int userId)
        {
            return userService.GetById(userId);
        }

        public User FindLoggedUser(string email, string password)
        {
            return userService.FindLoggedUser(email, password);
        }

        public List<User> SortUsersByNameAsc(List<User> users)
        {
            return userService.SortUsersByNameAsc(users);
        }

        public List<User> SortUsersByNameDesc(List<User> users)
        {
            return userService.SortUsersByNameDesc(users);
        }

        public List<User> SortUsersBySurnameAsc(List<User> users)
        {
            return userService.SortUsersBySurnameAsc(users);
        }

        public List<User> SortUsersBySurnameDesc(List<User> users)
        {
            return userService.SortUsersBySurnameDesc(users);
        }

        public List<User> FilterAllManagers(List<User> users)
        {
            return userService.FilterAllManagers(users);
        }

        public List<User> FilterAllPharmacists(List<User> users)
        {
            return userService.FilterAllPharmacists(users);
        }

        public List<User> FilterAllDoctors(List<User> users)
        {
            return userService.FilterAllDoctors(users);
        }

        public bool AreJmbgAndEmailValid(string jmbg, string email)
        {
            return userService.AreJmbgAndEmailValid(jmbg, email);
        }
    }
}
