using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure
{
    public class ResortRepositoryEF : IResortRepository
    {
        private readonly ResortContext _resortRepo;

        public ResortRepositoryEF(ResortContext resortRepo)
        {
            _resortRepo = resortRepo;
        }

        public void Add(Resort newResort)
        {
            _resortRepo.Resorts.Add(newResort);
            _resortRepo.SaveChanges();
        }

        public void Delete(Resort deleteResort)
        {
            _resortRepo.Resorts.Remove(deleteResort);
            _resortRepo.SaveChanges();
        }

        public void Edit(Resort updatedResort)
        {
            _resortRepo.Resorts.Update(updatedResort);
            _resortRepo.SaveChanges();
        }

        public Resort GetById(int id)
        {
            return _resortRepo.Resorts.Single(r => r.Id == id);
        }

        public List<Resort> GetList()
        {
            return _resortRepo.Resorts.ToList();
        }
    }
}
