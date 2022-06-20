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
    }
}
