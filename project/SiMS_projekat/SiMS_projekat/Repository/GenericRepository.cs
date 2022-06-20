using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiMS_projekat.Repository
{
    public abstract class GenericRepository<KeyType, Entity>
    {
        public abstract List<Entity> GetAll();
        public abstract Entity Add(Entity entity);
        public abstract Entity Update(Entity entity);
        public abstract void Delete(KeyType keyType);

    }
}
