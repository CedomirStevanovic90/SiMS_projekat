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
    }
}
