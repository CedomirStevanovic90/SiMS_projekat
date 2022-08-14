using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiMS_projekat.Model;

namespace SiMS_projekat.Service
{
    interface IIngredientService
    {
        List<Ingredient> GetAll();
        Ingredient Add(Ingredient ingredient);
        Ingredient Update(Ingredient ingredient);
        void Delete(int id);
        Ingredient GetById(int id);
    }
}
