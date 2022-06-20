using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiMS_projekat.DTO;

namespace SiMS_projekat.Model
{
    class Medicine
    {
        public string MedicineCode { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public List<IngredientDTO> Ingredients { get; set; }
        public bool Accepted { get; set; }
        public bool Rejected { get; set; }
        public int CountDoctors { get; set; }
        public int CountPharmacists { get; set; }
        public string AcceptedDetails { get; set; }
        public string RejectedDetails { get; set; }
        public List<MedicineDTO> MedicinesPurchase { get; set; }
    }
}
