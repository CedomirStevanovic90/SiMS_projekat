using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiMS_projekat.Model;
using SiMS_projekat.Repository;

namespace SiMS_projekat.Service
{
    class UserService
    {
        private UserRepository userRepository = new UserRepository();
        public UserService()
        {

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
    }
}
