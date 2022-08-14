using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SiMS_projekat.Model;

namespace SiMS_projekat.Repository
{
    class UserRepository : GenericRepository<int, User>, IUserRepository
    {
        private const string UserFile = @"..\..\Data\User.txt";

        public UserRepository()
        {
            if (!File.Exists(UserFile))
            {
                using (StreamWriter streamWriter = File.CreateText(UserFile))
                {
                    streamWriter.WriteLine("[]");
                }
            }
        }

        public void Write(List<User> users)
        {
            string userSerialized = JsonConvert.SerializeObject(users);
            File.WriteAllText(UserFile, userSerialized);
        }

        public override List<User> GetAll()
        {
            if (!File.Exists(UserFile))
            {
                using (StreamWriter streamWriter = File.CreateText(UserFile))
                {
                    streamWriter.WriteLine("[]");
                }
            }

            string userSerialized = File.ReadAllText(UserFile);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(userSerialized);
            return users;
        }

        public override User Add(User user)
        {
            List<User> users = GetAll();
            users.Add(user);
            Write(users);
            return user;
        }

        public override User Update(User user)
        {
            List<User> users = GetAll();
            for (int i = 0; i < users.Count(); i++)
            {
                if (users[i].UserId == user.UserId)
                {
                    users[i] = user;
                }
            }
            Write(users);
            return user;
        }

        public override void Delete(int id)
        {
            List<User> users = GetAll();
            for (int i = 0; i < users.Count(); i++)
            {
                if (users[i].UserId == id)
                {
                    users.Remove(users[i]);
                }
            }
            Write(users);
        }

        public override User GetById(int userId)
        {
            User user = new User();
            List<User> users = GetAll();
            for (int i = 0; i < users.Count(); i++)
            {
                if (users[i].UserId == userId)
                {
                    user = users[i];
                }
            }
            return user;
        }
    }
}
