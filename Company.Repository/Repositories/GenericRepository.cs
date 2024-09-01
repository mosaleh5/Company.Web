using Company.Data.Contexts;
using Company.Data.Entities;
using Company.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositoriest
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly CompanyDbContext companyDbContext;
        public GenericRepository(CompanyDbContext _companyDbContext)
        {
            companyDbContext = _companyDbContext;
        }
        public void Add(T Entity)
        {
            companyDbContext.Set<T>().Add(Entity);
        }

        public void Delete(T Entity)
        {
            companyDbContext.Set<T>().Remove(Entity);

        }

        public IEnumerable<T> GetAll()
        {
            return companyDbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return companyDbContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }
        public void Update(T Entity)
        => companyDbContext.Update(Entity);
    }
}
