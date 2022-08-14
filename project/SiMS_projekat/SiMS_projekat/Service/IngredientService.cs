using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiMS_projekat.Model;
using SiMS_projekat.Repository;

namespace SiMS_projekat.Service
{
    class IngredientService : IIngredientService
    {
        private IIngredientRepository ingredientRepository = new IngredientRepository();

        public List<Ingredient> GetAll()
        {
            return ingredientRepository.GetAll();
        }

        public Ingredient Add(Ingredient ingredient)
        {
            return ingredientRepository.Add(ingredient);
        }

        public Ingredient Update(Ingredient ingredient)
        {
            return ingredientRepository.Update(ingredient);
        }

        public void Delete(int id)
        {
            ingredientRepository.Delete(id);
        }

        public Ingredient GetById(int id)
        {
            return ingredientRepository.GetById(id);
        }
    }
}
