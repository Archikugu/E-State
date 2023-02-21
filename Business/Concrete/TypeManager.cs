using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TypeManager : IGenericService<Entity.Entities.Type>
    {
        ITypeRepository _typeRepository;

        public TypeManager(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public void Add(Entity.Entities.Type item)
        {
            _typeRepository.Add(item);
        }

        public void Delete(Entity.Entities.Type item)
        {
            _typeRepository?.Delete(item);
        }

        public Entity.Entities.Type GetById(int id)
        {
            return _typeRepository.GetById(id);
        }

        public List<Entity.Entities.Type> List()
        {
            return _typeRepository.List();
        }

        public List<Entity.Entities.Type> List(Expression<Func<Entity.Entities.Type, bool>> filter)
        {
            return _typeRepository.List(filter);
        }

        public void Update(Entity.Entities.Type item)
        {
            _typeRepository.Update(item);
        }
    }
}
