using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SiMS_projekat.DTO;
using SiMS_projekat.Model;
using SiMS_projekat.Repository;
using SiMS_projekat.View;

namespace SiMS_projekat.Service
{
    class MedicineService : IMedicineService
    {
        private IMedicineRepository medicineRepository = new MedicineRepository();
        private IngredientService ingredientService = new IngredientService();

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

        public Medicine GetById(string medicineCode)
        {
            return medicineRepository.GetById(medicineCode);
        }

        public List<Medicine> SortMedicinesByNameAsc(List<Medicine> medicines)
        {
            return medicines.OrderBy(m => m.Name).ToList();
        }

        public List<Medicine> SortMedicinesByNameDesc(List<Medicine> medicines)
        {
            return medicines.OrderByDescending(m => m.Name).ToList();
        }

        public List<Medicine> SortMedicinesByPriceAsc(List<Medicine> medicines)
        {
            return medicines.OrderBy(m => m.Price).ToList();
        }

        public List<Medicine> SortMedicinesByPriceDesc(List<Medicine> medicines)
        {
            return medicines.OrderByDescending(m => m.Price).ToList();
        }

        public List<Medicine> SortMedicinesByQuantityAsc(List<Medicine> medicines)
        {
            return medicines.OrderBy(m => m.Quantity).ToList();
        }

        public List<Medicine> SortMedicinesByQuantityDesc(List<Medicine> medicines)
        {
            return medicines.OrderByDescending(m => m.Quantity).ToList();
        }


        public List<Medicine> SearchMedicinesByMedicineCode(string contentForSearch, List<Medicine> medicines)
        {
            return medicines.Where(i => i.MedicineCode.ToLower().Contains(contentForSearch.ToLower())).ToList();
        }

        public List<Medicine> SearchMedicinesByName(string contentForSearch, List<Medicine> medicines)
        {
            return medicines.Where(i => i.Name.ToLower().Contains(contentForSearch.ToLower())).ToList();
        }

        public List<Medicine> SearchMedicinesByProducer(string contentForSearch, List<Medicine> medicines)
        {
            return medicines.Where(i => i.Producer.ToLower().Contains(contentForSearch.ToLower())).ToList();
        }

        public List<Medicine> SearchMedicinesByQuantity(string contentForSearch, List<Medicine> medicines)
        {
            int quantity;
            if(int.TryParse(contentForSearch, out quantity))
                return medicines.Where(i => i.Quantity == quantity).ToList();
            return medicines;
        }

        public List<Medicine> SearchMedicinesByPriceRange(string contentForSearch, List<Medicine> medicines)
        {
            string[] splittedRange = contentForSearch.Split('-');
            int priceFrom;
            int priceTo;
            if(splittedRange.Count() == 2 && int.TryParse(splittedRange[0], out priceFrom) && int.TryParse(splittedRange[1], out priceTo))
                return medicines.Where(i => i.Price >= priceFrom && i.Price <= priceTo).ToList();
            return medicines;
        }

        public List<Medicine> SearchMedicinesByIngredients(string contentForSearch, List<Medicine> medicines)
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

        public List<Ingredient> GetMedicineIngredients(string code, List<Ingredient> ingredients)
        {
            Medicine medicine = GetAll().FirstOrDefault(m => m.MedicineCode.Equals(code));
            List<Ingredient> medicineIngredients = new List<Ingredient>();
            foreach (var i in ingredients)
            {
                foreach (var im in medicine.Ingredients)
                {
                    if (i.IngredientId == im.IngredientId)
                    {
                        medicineIngredients.Add(i);
                    }
                }
            }
            return medicineIngredients;
        }

        public void SetReasonForRejectingMedicine(string reason, string medicineCode, User user)
        {
            Medicine medicine = GetById(medicineCode);
            string details = user.Name + " " + user.Surname + " " + reason + ".";
            medicine.RejectedDetails = medicine.RejectedDetails + details;
            medicine.Rejected = true;
            Update(medicine);
        }

        public void PurchaseMedicine(int quantity, string medicineCode)
        {
            Medicine medicine = GetById(medicineCode);
            medicine.Quantity += quantity;
            Update(medicine);
        }

        public void PurchaseMedicineAtSpecificTime(int quantity, DateTime dateOfPurchase, string medicineCode)
        {
            Medicine medicine = GetById(medicineCode);
            MedicineDTO medicineDTO = new MedicineDTO();
            medicineDTO.Quantity = quantity;
            medicineDTO.Date = dateOfPurchase;
            if (medicine.MedicinesPurchase == null)
            {
                medicine.MedicinesPurchase = new List<MedicineDTO>();
            }
            medicine.MedicinesPurchase.Add(medicineDTO);
            Update(medicine);
        }

        public void OrderMedicine()
        {
            foreach (var medicine in GetAll())
            {
                if (medicine.MedicinesPurchase != null)
                {
                    CheckOrderedMedicine(medicine);
                }
            }
        }

        private void CheckOrderedMedicine(Medicine medicine)
        {
            for (int i = 0; i < medicine.MedicinesPurchase.Count; i++)
            {
                if (medicine.MedicinesPurchase[i].Date < DateTime.Now)
                {
                    medicine.Quantity += medicine.MedicinesPurchase[i].Quantity;
                    medicine.MedicinesPurchase.Remove(medicine.MedicinesPurchase[i]);
                    Update(medicine);
                }
            }
        }

        public bool IsMedicineAccepted(string jmbg, Medicine medicine)
        {
            string[] detailsAccepted = null;
            if (medicine.AcceptedDetails != null)
            {
                detailsAccepted = medicine.AcceptedDetails.Split(';');
            }
            if (detailsAccepted != null && detailsAccepted.Length > 0)
            {
                foreach (var m in detailsAccepted)
                {
                    if (jmbg == m)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Medicine AcceptMedicineByDoctor(Medicine medicine)
        {
            medicine.DoctorCounter++;
            return medicine;
        }

        public Medicine AcceptMedicineByPharmacist(Medicine medicine)
        {
            medicine.PharmacistCounter++;
            return medicine;
        }

        public Medicine AcceptMedicine(Medicine medicine)
        {
            medicine.Accepted = true;
            medicine.Rejected = false;
            medicine.RejectedDetails = null;
            return medicine;
        }
    }
}
