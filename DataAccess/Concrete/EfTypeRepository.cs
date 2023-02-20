using DataAccess.Abstract;
using DataAccess.Data;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfTypeRepository : GenericRepository<Entity.Entities.Type, DataContext>, ITypeRepository
    {
        private DataContext context;
        public EfTypeRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
