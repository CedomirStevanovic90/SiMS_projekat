using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiMS_projekat.Model;
using SiMS_projekat.Service;

namespace SiMS_projekat.Controller
{
    class IngredientController
    {
        private IIngredientService ingredientService = new IngredientService();

        public List<Ingredient> GetAll()
        {
            return ingredientService.GetAll();
        }

        public Ingredient Add(Ingredient ingredient)
        {
            return ingredientService.Add(ingredient);
        }

        public Ingredient Update(Ingredient ingredient)
        {
            return ingredientService.Update(ingredient);
        }

        public void Delete(int id)
        {
            ingredientService.Delete(id);
        }
        public Ingredient GetById(int id)
        {
            return ingredientService.GetById(id);
        }
    }
}
