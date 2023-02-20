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
    public class EfCityRepository : GenericRepository<City, DataContext>, ICityRepository
    {
        private DataContext context;
        public EfCityRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
