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
        public MedicineService medicineService = new MedicineService();

        public MedicineController()
        {

        }

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

        public List<Medicine> sortingAllMedicines(string typeOfSorting, List<Medicine> medicinesForSorting)
        {
            return medicineService.sortingMedicines(typeOfSorting, medicinesForSorting);
        }

        public List<Medicine> sortingAcceptedMedicines(string typeOfSorting, string userType, List<Medicine> acceptedMedicinesForSorting)
        {
            if (userType == "Pharmacist" && typeOfSorting == "No sort")
            {
                return GetAll().Where(m => m.Accepted == true).ToList();
            }
            else if (userType == "Pharmacist")
            {
                return medicineService.sortingMedicines(typeOfSorting, acceptedMedicinesForSorting);
            }
            return acceptedMedicinesForSorting;
        }

        public List<Medicine> sortingRejectedMedicines(string typeOfSorting, string userType, List<Medicine> rejectedMedicinesForSorting)
        {
            if (userType == "Pharmacist" && typeOfSorting == "No sort")
            {
                return GetAll().Where(m => m.Rejected == true).ToList();
            }
            else if (userType == "Pharmacist")
            {
                return medicineService.sortingMedicines(typeOfSorting, rejectedMedicinesForSorting);
            }
            return rejectedMedicinesForSorting;
        }

        public List<Medicine> searchingAllMedicines(string typeOfSearching, string contentForSearch, List<Medicine> medicines, List<Medicine> medicinesForSearching)
        {
            return medicineService.searchingMedicines(typeOfSearching, contentForSearch, medicines, medicinesForSearching);
        }

        public List<Medicine> searchingAcceptedMedicines(string typeOfSearching, string contentForSearch, string userType, List<Medicine> medicines, List<Medicine> acceptedMedicineForSearching)
        {
            if (userType == "Pharmacist" && typeOfSearching == "No search")
            {
                return GetAll().Where(m => m.Accepted == true).ToList();
            }
            else if (userType == "Pharmacist")
            {
                return medicineService.searchingMedicines(typeOfSearching, contentForSearch, medicines, acceptedMedicineForSearching);
            }
            return acceptedMedicineForSearching;
        }

        public List<Medicine> searchingRejectedMedicines(string typeOfSearching, string contentForSearch, string userType, List<Medicine> medicines, List<Medicine> rejectedMedicineForSearching)
        {
            if (userType == "Pharmacist" && typeOfSearching == "No search")
            {
                return GetAll().Where(m => m.Rejected == true).ToList();
            }
            else if (userType == "Pharmacist")
            {
                return medicineService.searchingMedicines(typeOfSearching, contentForSearch, medicines, rejectedMedicineForSearching);
            }
            return rejectedMedicineForSearching;
        }
    }
}
