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
    class UserService
    {
        private UserRepository userRepository = new UserRepository();
        private List<User> users;
        private int counter = 3;
        public UserService()
        {
            users = GetAll();
        }

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

        public string SignIn(string email, string password)
        {
            User user = users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                int number = counter - 1;
                if (number == 0)
                {
                    MessageBox.Show("Iskoristili ste moguci broj pokusaja!");
                    return "Close";
                }
                MessageBox.Show("Niste uneli dobre kredencijale!\n Preostali broj pokusaja: " + number);
                counter--;
                return "Continue";
            }
            if (user.Blocked == true)
            {
                MessageBox.Show("Korisnik sa unetim e-mailom i passwordom je blokiran!");
                return "Continue";
            }
            if (user.UserType.Equals("Manager"))
            {
                UpravnikHomepage upravnikHomepage = new UpravnikHomepage();
                upravnikHomepage.Show();

            }
            else if (user.UserType.Equals("Doctor"))
            {
                LekarHomepage lekarHomepage = new LekarHomepage(user.Jmbg, "Doctor");
                lekarHomepage.Show();
            }
            else if (user.UserType.Equals("Pharmacist"))
            {
                FarmaceutHomepage farmaceutHomepage = new FarmaceutHomepage(user.Jmbg, "Pharmacist");
                farmaceutHomepage.Show();
            }
            return "Hide";
        }

        public List<User> sortingUsers(string typeOfSorting, List<User> sortedUsers)
        {
            if (typeOfSorting == "Sort by name (A-Z)")
            {
                sortedUsers = sortedUsers.OrderBy(u => u.Name).ToList();
            }
            else if (typeOfSorting == "Sort by name (Z-A)")
            {
                sortedUsers = sortedUsers.OrderByDescending(u => u.Name).ToList();
            }
            else if (typeOfSorting == "Sort by surname (A-Z)")
            {
                sortedUsers = sortedUsers.OrderBy(u => u.Surname).ToList();
            }
            else if (typeOfSorting == "Sort by surname (Z-A)")
            {
                sortedUsers = sortedUsers.OrderByDescending(u => u.Surname).ToList();
            }
            return sortedUsers;
        }

        public List<User> filteringUsers(string typeOfFiltering, List<User> filteredUsers)
        {
            if (typeOfFiltering == "Filter by Manager")
            {
                filteredUsers = filteredUsers.Where(u => u.UserType == "Manager").ToList();
            }
            else if (typeOfFiltering == "Filter by Doctor")
            {
                filteredUsers = filteredUsers.Where(u => u.UserType == "Doctor").ToList();
            }
            else if (typeOfFiltering == "Filter by Pharmacist")
            {
                filteredUsers = filteredUsers.Where(u => u.UserType == "Pharmacist").ToList();
            }
            else if (typeOfFiltering == "No filter")
            {
                filteredUsers = GetAll();
            }
            return filteredUsers;
        }
    }
}
