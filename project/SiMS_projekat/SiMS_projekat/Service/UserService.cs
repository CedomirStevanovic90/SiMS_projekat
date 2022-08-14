using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SiMS_projekat.Model;
using SiMS_projekat.Repository;
using SiMS_projekat.View;

namespace SiMS_projekat.Service
{
    class UserService : IUserService
    {
        private IUserRepository userRepository = new UserRepository();

        public List<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public User Add(User user)
        {
            return userRepository.Add(user);
        }

        public User Update(User user)
        {
            return userRepository.Update(user);
        }

        public void Delete(int id)
        {
            userRepository.Delete(id);
        }

        public User GetById(int userId)
        {
            return userRepository.GetById(userId);
        }

        public User FindLoggedUser(string email, string password)
        {
            List<User> users = GetAll();
            return users.FirstOrDefault(u => u.Email.Equals(email) && u.Password.Equals(password));
        }

        public List<User> SortUsersByNameAsc(List<User> users)
        {
            return users.OrderBy(u => u.Name).ToList();
        }

        public List<User> SortUsersByNameDesc(List<User> users)
        {
            return users.OrderByDescending(u => u.Name).ToList();
        }

        public List<User> SortUsersBySurnameAsc(List<User> users)
        {
            return users.OrderBy(u => u.Surname).ToList();
        }

        public List<User> SortUsersBySurnameDesc(List<User> users)
        {
            return users.OrderByDescending(u => u.Surname).ToList();
        }

        public List<User> FilterAllManagers(List<User> users)
        {
            return users.Where(u => u.UserType.Equals("Manager")).ToList();
        }

        public List<User> FilterAllDoctors(List<User> users)
        {
            return users.Where(u => u.UserType.Equals("Doctor")).ToList();
        }

        public List<User> FilterAllPharmacists(List<User> users)
        {
            return users.Where(u => u.UserType.Equals("Pharmacist")).ToList();
        }

        public bool AreJmbgAndEmailValid(string jmbg, string email)
        {
            List<User> users = GetAll();
            bool isValid = false;
            for (int i = 0; i < users.Count(); i++)
            {
                if (users[i].Jmbg.Equals(jmbg) || users[i].Email.Equals(email))
                {
                    isValid = true;
                    break;
                }
            }
            return isValid;
        }
    }
}
