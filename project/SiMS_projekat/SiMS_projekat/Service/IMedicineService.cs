using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiMS_projekat.Model;

namespace SiMS_projekat.Service
{
    interface IMedicineService
    {
        List<Medicine> GetAll();
        Medicine Add(Medicine medicine);
        Medicine Update(Medicine medicine);
        void Delete(string id);
        Medicine GetById(string medicineCode);
        List<Medicine> SortMedicinesByNameAsc(List<Medicine> medicines);
        List<Medicine> SortMedicinesByNameDesc(List<Medicine> medicines);
        List<Medicine> SortMedicinesByPriceAsc(List<Medicine> medicines);
        List<Medicine> SortMedicinesByPriceDesc(List<Medicine> medicines);
        List<Medicine> SortMedicinesByQuantityAsc(List<Medicine> medicines);
        List<Medicine> SortMedicinesByQuantityDesc(List<Medicine> medicines);
        List<Medicine> SearchMedicinesByMedicineCode(string contentForSearch, List<Medicine> medicines);
        List<Medicine> SearchMedicinesByName(string contentForSearch, List<Medicine> medicines);
        List<Medicine> SearchMedicinesByProducer(string contentForSearch, List<Medicine> medicines);
        List<Medicine> SearchMedicinesByQuantity(string contentForSearch, List<Medicine> medicines);
        List<Medicine> SearchMedicinesByPriceRange(string contentForSearch, List<Medicine> medicines);
        List<Medicine> SearchMedicinesByIngredients(string contentForSearch, List<Medicine> medicines);
        List<Ingredient> GetMedicineIngredients(string code, List<Ingredient> ingredients);
        void SetReasonForRejectingMedicine(string reason, string medicineCode, User user);
        void PurchaseMedicine(int quantity, string medicineCode);
        void PurchaseMedicineAtSpecificTime(int quantity, DateTime dateOfPurchase, string medicineCode);
        void OrderMedicine();
        bool IsMedicineAccepted(string jmbg, Medicine medicine);
        Medicine AcceptMedicineByDoctor(Medicine medicine);
        Medicine AcceptMedicineByPharmacist(Medicine medicine);
        Medicine AcceptMedicine(Medicine medicine);
    }
}
