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
    class IngredientRepository : GenericRepository<int, Ingredient>, IIngredientRepository
    {
        public const string IngredientFile = @"..\..\Data\Ingredient.txt";

        public IngredientRepository()
        {
            if (!File.Exists(IngredientFile))
            {
                using (StreamWriter streamWriter = File.CreateText(IngredientFile))
                {
                    streamWriter.WriteLine("[]");
                }
            }
        }

        public void Write(List<Ingredient> ingredients)
        {
            string ingredientSerialized = JsonConvert.SerializeObject(ingredients);
            File.WriteAllText(IngredientFile, ingredientSerialized);
        }

        public override List<Ingredient> GetAll()
        {
            if (!File.Exists(IngredientFile))
            {
                using (StreamWriter streamWriter = File.CreateText(IngredientFile))
                {
                    streamWriter.WriteLine("[]");
                }
            }

            string ingredientSerialized = File.ReadAllText(IngredientFile);
            List<Ingredient> ingredients = JsonConvert.DeserializeObject<List<Ingredient>>(ingredientSerialized);
            return ingredients;
        }

        public override Ingredient Add(Ingredient ingredient)
        {
            List<Ingredient> ingredients = GetAll();
            ingredients.Add(ingredient);
            Write(ingredients);
            return ingredient;
        }

        public override Ingredient Update(Ingredient ingredient)
        {
            List<Ingredient> ingredients = GetAll();
            for (int i = 0; i < ingredients.Count(); i++)
            {
                if (ingredients[i].IngredientId == ingredient.IngredientId)
                {
                    ingredients[i] = ingredient;
                }
            }
            Write(ingredients);
            return ingredient;
        }

        public override void Delete(int id)
        {
            List<Ingredient> ingredients = GetAll();
            for (int i = 0; i < ingredients.Count(); i++)
            {
                if (ingredients[i].IngredientId == id)
                {
                    ingredients.Remove(ingredients[i]);
                }
            }
            Write(ingredients);
        }

        public override Ingredient GetById(int ingredientId)
        {
            Ingredient ingredient = new Ingredient();
            List<Ingredient> ingredients = GetAll();
            for (int i = 0; i < ingredients.Count(); i++)
            {
                if (ingredients[i].IngredientId == ingredientId)
                {
                    ingredient = ingredients[i];
                }
            }
            return ingredient;
        }
    }
}
