using Business.Abstract;
using DataAccess.Abstract;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete {
    public class AdvertManager : IAdvertService {
        IAdvertRepository _advertRepository;

        public AdvertManager(IAdvertRepository advertRepository) {
            _advertRepository = advertRepository;
        }

        public void Add(Advert item) {
            item.Status = true;
            item.AdvertDate = DateTime.Now;
            _advertRepository.Add(item);
        }

        public void Delete(Advert item) {
            var delete = _advertRepository.GetById(item.AdvertId);
            item.Status = false;
            _advertRepository.Update(delete);
        }

        public void FullDelete(Advert item) {
            var delete = _advertRepository.GetById(item.AdvertId);
            _advertRepository.FullDelete(delete);

        }

        public Advert GetById(int id) {
            return _advertRepository.GetById(id);
        }

        public List<Advert> List() {
            return _advertRepository.List();
        }

        public List<Advert> List(Expression<Func<Advert, bool>> filter) {
            return _advertRepository.List(filter);
        }

        public void RestoreDelete(Advert item) {
            var delete = _advertRepository.GetById(item.AdvertId);
            item.Status = true;
            _advertRepository.Update(delete);
        }

        public void Update(Advert item) {
            _advertRepository.Update(item);
        }
    }
}
