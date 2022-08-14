using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiMS_projekat.Repository
{
    interface IGenericRepository<KeyType, Entity>
    {
        List<Entity> GetAll();
        Entity Add(Entity entity);
        Entity Update(Entity entity);
        void Delete(KeyType keyType);
        Entity GetById(KeyType keyType);
    }
}
