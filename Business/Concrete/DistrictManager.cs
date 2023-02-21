using Business.Abstract;
using DataAccess.Abstract;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DistrictManager : IGenericService<District>
    {
        IDistrictRepository _districtRepository;

        public DistrictManager(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }

        public void Add(District item)
        {
           _districtRepository.Add(item);
        }

        public void Delete(District item)
        {
            _districtRepository.Delete(item);
        }

        public District GetById(int id)
        {
            return _districtRepository.GetById(id);
        }

        public List<District> List()
        {
            return _districtRepository.List();
        }

        public List<District> List(Expression<Func<District, bool>> filter)
        {
            return _districtRepository.List(filter);
        }

        public void Update(District item)
        {
            _districtRepository.Update(item);
        }
    }
}
