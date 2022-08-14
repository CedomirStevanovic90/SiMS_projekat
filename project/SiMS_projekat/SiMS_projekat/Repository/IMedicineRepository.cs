using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiMS_projekat.Model;

namespace SiMS_projekat.Repository
{
    interface IMedicineRepository : IGenericRepository<string, Medicine>
    {
    }
}
