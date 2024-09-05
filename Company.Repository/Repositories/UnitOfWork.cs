using Company.Data.Contexts;
using Company.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public CompanyDbContext _Context;
        public UnitOfWork(CompanyDbContext Context)
        {
            _Context = Context;
            DepartmentRepository = new DepartmentRepository(Context);
            EmployeeRepository = new EmployeeRepository(Context);   
        }
        public IDepartmentRepository DepartmentRepository { get  ; set ; }
        public IEmployeeRepository EmployeeRepository { get; set; }
       

        public int Complete()
           => _Context.SaveChanges();
        
    }
}
