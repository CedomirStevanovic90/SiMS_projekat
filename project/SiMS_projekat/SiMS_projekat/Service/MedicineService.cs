using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiMS_projekat.Model;
using SiMS_projekat.Repository;

namespace SiMS_projekat.Service
{
    class MedicineService
    {
        private MedicineRepository medicineRepository = new MedicineRepository();
        private IngredientService ingredientService = new IngredientService();

        public MedicineService()
        {

        }

        public List<Medicine> GetAll()
        {
            return medicineRepository.GetAll();
        }

        public Medicine Add(Medicine medicine)
        {
            return medicineRepository.Add(medicine);
        }

        public Medicine Update(Medicine medicine)
        {
            return medicineRepository.Update(medicine);
        }

        public void Delete(string id)
        {
            medicineRepository.Delete(id);
        }

        public List<Medicine> sortingMedicines(string typeOfSorting, List<Medicine> sortedMedicines)
        {
            if (typeOfSorting == "Sort by name (A-Z)")
            {
                sortedMedicines = sortedMedicines.OrderBy(m => m.Name).ToList();
            }
            else if (typeOfSorting == "Sort by name (Z-A)")
            {
                sortedMedicines = sortedMedicines.OrderByDescending(m => m.Name).ToList();
            }
            else if (typeOfSorting == "Sort by price (Low - High)")
            {
                sortedMedicines = sortedMedicines.OrderBy(m => m.Price).ToList();
            }
            else if (typeOfSorting == "Sort by price (High - Low)")
            {
                sortedMedicines = sortedMedicines.OrderByDescending(m => m.Price).ToList();
            }
            else if (typeOfSorting == "Sort by quantity (Low - High)")
            {
                sortedMedicines = sortedMedicines.OrderBy(m => m.Quantity).ToList();
            }
            else if (typeOfSorting == "Sort by quantity (High - Low)")
            {
                sortedMedicines = sortedMedicines.OrderByDescending(m => m.Quantity).ToList();
            }
            return sortedMedicines;
        }

        public List<Medicine> searchingMedicines(string typeOfSearching, string contentForSearch, List<Medicine> medicines, List<Medicine> searchedMedicines)
        {
            if (typeOfSearching == "Search by Medicine Code")
            {
                searchedMedicines = searchedMedicines.Where(i => i.MedicineCode.ToLower().Contains(contentForSearch.ToLower())).ToList();
            }
            else if (typeOfSearching == "Search by Name")
            {
                searchedMedicines = searchedMedicines.Where(i => i.Name.ToLower().Contains(contentForSearch.ToLower())).ToList();
            }
            else if (typeOfSearching == "Search by Producer")
            {
                searchedMedicines = searchedMedicines.Where(i => i.Producer.ToLower().Contains(contentForSearch.ToLower())).ToList();
            }
            else if (typeOfSearching == "Search by Quantity")
            {
                searchedMedicines = searchedMedicines.Where(i => i.Quantity == int.Parse(contentForSearch)).ToList();
            }
            else if (typeOfSearching == "Search by Price range")
            {
                string[] splittedRange = contentForSearch.Split('-');
                int priceFrom = int.Parse(splittedRange[0]);
                int priceTo = int.Parse(splittedRange[1]);
                searchedMedicines = searchedMedicines.Where(i => i.Price >= priceFrom && i.Price < priceTo).ToList();
            }
            else if (typeOfSearching == "Search by Ingredients")
            {
                return searchingByIngredients(searchedMedicines, contentForSearch);
            }
            else if (typeOfSearching == "No search")
            {
                searchedMedicines = GetAll();
            }
            return searchedMedicines;
        }

        private List<Medicine> searchingByIngredients(List<Medicine> medicines, string contentForSearch)
        {
            List<Medicine> searchedMedicine = new List<Medicine>();
            List<string> ingredientAND = new List<string>();
            string[] splittedOR;
            string[] splittedAND = contentForSearch.Split('&');
            List<string> ingredientsOR = new List<string>();
            List<Medicine> finalMedicines = new List<Medicine>();
            for (int i = 0; i < splittedAND.Length; i++)
            {
                if (splittedAND[i].Contains('|') == true)
                {
                    splittedOR = splittedAND[i].Split('|');
                    for (int s = 0; s < splittedOR.Length; s++)
                    {
                        ingredientsOR.Add(splittedOR[s].Replace("(", string.Empty).Replace(")", string.Empty));
                    }
                }
                else
                {
                    ingredientAND.Add(splittedAND[i]);
                }
            }
            for (int i = 0; i < medicines.Count(); i++)
            {
                List<string> ingredientsMedicine = new List<string>();
                foreach (var ins in ingredientService.GetAll())
                {
                    foreach (var im in medicines[i].Ingredients)
                    {
                        if (ins.IngredientId == im.IngredientId)
                        {
                            ingredientsMedicine.Add(ins.Name);
                        }
                    }
                }

                if (ingredientAND.All(ingredientsMedicine.Contains))
                {
                    searchedMedicine.Add(medicines[i]);
                }
            }
            for (int im = 0; im < searchedMedicine.Count(); im++)
            {
                List<string> ingredientMedicine = new List<string>();
                foreach (var ins in ingredientService.GetAll())
                {
                    foreach (var iss in searchedMedicine[im].Ingredients)
                    {
                        if (ins.IngredientId == iss.IngredientId)
                        {
                            ingredientMedicine.Add(ins.Name);
                        }
                    }
                }
                if (ingredientsOR.Any(ingredientMedicine.Contains))
                {
                    finalMedicines.Add(searchedMedicine[im]);
                }

            }
            if (finalMedicines.Count() == 0)
            {
                return searchedMedicine;
            }
            else
            {
                return finalMedicines;
            }
        }
    }
}
