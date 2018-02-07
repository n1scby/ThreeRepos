using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class ResortRepositoryMemory : IResortRepository
    {
        private static List<Resort> _resorts;
        private static int _nextNum = 1;

        public ResortRepositoryMemory()
        {
            if (_resorts == null)
            {
                _resorts = new List<Resort>();
            }
        }

        public void Add(Resort newResort)
        {
            newResort.Id = _nextNum++;
            _resorts.Add(newResort);

        }

        public void Delete(Resort deleteResort)
        {
            Resort removeResort = GetById(deleteResort.Id);
            _resorts.Remove(removeResort);
        }

        public void Edit(Resort updatedResort)
        {
            Resort editResort = GetById(updatedResort.Id);
            editResort.Location = updatedResort.Location;
            editResort.Name = updatedResort.Name;
            editResort.Image = updatedResort.Image;

        }

        public List<Resort> GetList()
        {
            return _resorts;
        }

        public Resort GetById(int id)
        {
            return _resorts.Find(r => r.Id == id);
        }
    }
}
