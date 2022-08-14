using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiMS_projekat.Model;

namespace SiMS_projekat.Service
{
    interface IUserService
    {
        List<User> GetAll();
        User Add(User user);
        User Update(User user);
        void Delete(int id);
        User GetById(int userId);
        User FindLoggedUser(string email, string password);
        List<User> SortUsersByNameAsc(List<User> users);
        List<User> SortUsersByNameDesc(List<User> users);
        List<User> SortUsersBySurnameAsc(List<User> users);
        List<User> SortUsersBySurnameDesc(List<User> users);
        List<User> FilterAllManagers(List<User> users);
        List<User> FilterAllDoctors(List<User> users);
        List<User> FilterAllPharmacists(List<User> users);
        bool AreJmbgAndEmailValid(string jmbg, string email);
    }
}
