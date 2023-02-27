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
    public class SituationManager : ISituationService
    {
        ISituationRepository _situationRepository;

        public SituationManager(ISituationRepository situationRepository)
        {
            _situationRepository = situationRepository;
        }

        public void Add(Situation item)
        {
            _situationRepository.Add(item);
        }

        public void Delete(Situation item)
        {
            _situationRepository.Delete(item);
        }

        public Situation GetById(int id)
        {
            return _situationRepository.GetById(id);
        }

        public List<Situation> List()
        {
            return _situationRepository.List();
        }

        public List<Situation> List(Expression<Func<Situation, bool>> filter)
        {
            return _situationRepository.List(filter);
        }

        public void Update(Situation item)
        {
            _situationRepository.Update(item);
        }
    }
}
