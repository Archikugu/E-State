using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract {
    public interface IAdvertRepository : IRepository<Advert> {
        public void FullDelete(Advert item);
    }
}
