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
    public class EfSituationRepository : GenericRepository<Situation, DataContext>, ISituationRepository
    {
        private DataContext context;
        public EfSituationRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
