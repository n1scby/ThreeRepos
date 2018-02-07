using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IResortRepository
    {
        void Add(Resort newResort);
        void Delete(Resort deleteResort);
        Resort GetById(int id);
        void Edit(Resort updatedResort);
        List<Resort> GetList();

    }
}
