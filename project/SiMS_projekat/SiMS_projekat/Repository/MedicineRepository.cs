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
    class MedicineRepository : GenericRepository<string, Medicine>, IMedicineRepository
    {
        public const string MedicineFile = @"..\..\Data\Medicine.txt";

        public MedicineRepository()
        {
            if (!File.Exists(MedicineFile))
            {
                using (StreamWriter streamWriter = File.CreateText(MedicineFile))
                {
                    streamWriter.WriteLine("[]");
                }
            }
        }

        public void Write(List<Medicine> medicines)
        {
            string medicineSerialized = JsonConvert.SerializeObject(medicines);
            File.WriteAllText(MedicineFile, medicineSerialized);
        }

        public override List<Medicine> GetAll()
        {
            if (!File.Exists(MedicineFile))
            {
                using (StreamWriter streamWriter = File.CreateText(MedicineFile))
                {
                    streamWriter.WriteLine("[]");
                }
            }
            string medicineSerialized = File.ReadAllText(MedicineFile);
            List<Medicine> medicines = JsonConvert.DeserializeObject<List<Medicine>>(medicineSerialized);
            return medicines;
        }

        public override Medicine Add(Medicine medicine)
        {
            List<Medicine> medicines = GetAll();
            medicines.Add(medicine);
            Write(medicines);
            return medicine;
        }

        public override Medicine Update(Medicine medicine)
        {
            List<Medicine> medicines = GetAll();
            for (int i = 0; i < medicines.Count(); i++)
            {
                if (medicines[i].MedicineCode == medicine.MedicineCode)
                {
                    medicines[i] = medicine;
                }
            }
            Write(medicines);
            return medicine;
        }

        public override void Delete(string id)
        {
            List<Medicine> medicines = GetAll();
            for (int i = 0; i < medicines.Count(); i++)
            {
                if (medicines[i].MedicineCode == id)
                {
                    medicines.Remove(medicines[i]);
                }
            }
            Write(medicines);
        }

        public override Medicine GetById(string medicineCode)
        {
            Medicine medicine = new Medicine();
            List<Medicine> medicines = GetAll();
            for (int i = 0; i < medicines.Count(); i++)
            {
                if (medicines[i].MedicineCode == medicineCode)
                {
                    medicine = medicines[i];
                }
            }
            return medicine;
        }
    }
}
