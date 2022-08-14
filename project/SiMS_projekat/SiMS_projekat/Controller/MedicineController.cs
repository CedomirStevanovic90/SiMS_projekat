using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiMS_projekat.Model;
using SiMS_projekat.Service;

namespace SiMS_projekat.Controller
{
    class MedicineController
    {
        public IMedicineService medicineService = new MedicineService();

        public List<Medicine> GetAll()
        {
            return medicineService.GetAll();
        }

        public Medicine Add(Medicine medicine)
        {
            return medicineService.Add(medicine);
        }

        public Medicine Update(Medicine medicine)
        {
            return medicineService.Update(medicine);
        }

        public void Delete(string id)
        {
            medicineService.Delete(id);
        }

        public Medicine GetById(string medicineCode)
        {
            return medicineService.GetById(medicineCode);
        }

        public List<Medicine> SortMedicinesByNameAsc(List<Medicine> medicines)
        {
            return medicineService.SortMedicinesByNameAsc(medicines);
        }

        public List<Medicine> SortMedicinesByNameDesc(List<Medicine> medicines)
        {
            return medicineService.SortMedicinesByNameDesc(medicines);
        }

        public List<Medicine> SortMedicinesByPriceAsc(List<Medicine> medicines)
        {
            return medicineService.SortMedicinesByPriceAsc(medicines);
        }

        public List<Medicine> SortMedicinesByPriceDesc(List<Medicine> medicines)
        {
            return medicineService.SortMedicinesByPriceDesc(medicines);
        }

        public List<Medicine> SortMedicinesByQuantityAsc(List<Medicine> medicines)
        {
            return medicineService.SortMedicinesByQuantityAsc(medicines);
        }

        public List<Medicine> SortMedicinesByQuantityDesc(List<Medicine> medicines)
        {
            return medicineService.SortMedicinesByQuantityDesc(medicines);
        }

        public List<Medicine> SearchMedicinesByMedicineCode(string contentForSearch, List<Medicine> medicines)
        {
            return medicineService.SearchMedicinesByMedicineCode(contentForSearch, medicines);
        }

        public List<Medicine> SearchMedicinesByName(string contentForSearch, List<Medicine> medicines)
        {
            return medicineService.SearchMedicinesByName(contentForSearch, medicines);
        }

        public List<Medicine> SearchMedicinesByProducer(string contentForSearch, List<Medicine> medicines)
        {
            return medicineService.SearchMedicinesByProducer(contentForSearch, medicines);
        }

        public List<Medicine> SearchMedicinesByQuantity(string contentForSearch, List<Medicine> medicines)
        {
            return medicineService.SearchMedicinesByQuantity(contentForSearch, medicines);
        }

        public List<Medicine> SearchMedicinesByPriceRange(string contentForSearch, List<Medicine> medicines)
        {
            return medicineService.SearchMedicinesByPriceRange(contentForSearch, medicines);
        }

        public List<Medicine> SearchMedicinesByIngredients(string contentForSearch, List<Medicine> medicines)
        {
            return medicineService.SearchMedicinesByIngredients(contentForSearch, medicines);
        }

        public List<Ingredient> GetMedicineIngredients(string code, List<Ingredient> ingredients)
        {
            return medicineService.GetMedicineIngredients(code, ingredients);
        }

        public void SetReasonForRejectingMedicine(string reason, string medicineCode, User user)
        {
            medicineService.SetReasonForRejectingMedicine(reason, medicineCode, user);
        }

        public void PurchaseMedicine(int quantity, string medicineCode)
        {
            medicineService.PurchaseMedicine(quantity, medicineCode);
        }

        public void PurchaseMedicineAtSpecificTime(int quantity, DateTime dateOfPurchase, string medicineCode)
        {
            medicineService.PurchaseMedicineAtSpecificTime(quantity, dateOfPurchase, medicineCode);
        }

        public void OrderMedicine()
        {
            medicineService.OrderMedicine();
        }

        public bool IsMedicineAccepted(string jmbg, Medicine medicine)
        {
            return medicineService.IsMedicineAccepted(jmbg, medicine);
        }

        public Medicine AcceptMedicineByDoctor(Medicine medicine)
        {
            return medicineService.AcceptMedicineByDoctor(medicine);
        }

        public Medicine AcceptMedicineByPharmacist(Medicine medicine)
        {
            return medicineService.AcceptMedicineByPharmacist(medicine);
        }

        public Medicine AcceptMedicine(Medicine medicine)
        {
            return medicineService.AcceptMedicine(medicine);
        }
    }
}
