using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdvertService : IGenericService<Advert>
    {
        public void RestoreDelete(Advert item);
        public void FullDelete(Advert item);
    }
}
