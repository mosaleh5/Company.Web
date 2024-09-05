using Company.Repository.Interfaces;
using Company.Data.Entities;
using Company.Service.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services
{
    public class DeprtmentService : IDepartmentService
    {
        public IUnitOfWork _UnitOfWork { get; }

        public DeprtmentService(IUnitOfWork unitOfWork)
        {
            
            _UnitOfWork = unitOfWork;
        }


        public void Add(Department department)
        {
            var mappedDepartment = new Department
            {
                code = department.code,
                Name = department.Name,
                CreateAt = DateTime.Now,
                Employees = department.Employees,
            };
            _UnitOfWork.DepartmentRepository.Add(mappedDepartment);
            _UnitOfWork.Complete();
        }

        public void Delete(Department department)
        {
            _UnitOfWork.DepartmentRepository.Delete(department);
            _UnitOfWork.Complete();
        }

        public IEnumerable<Department> GetAll()
        {
            var departments = _UnitOfWork.DepartmentRepository.GetAll();
            return departments;
        }

        public Department GetById(int? id)
        {
            if (id is null)
             
                throw new Exception("id is Null");
            var department = _UnitOfWork.DepartmentRepository.GetById(id.Value);

            if (department == null)
                return null;
            return department;

        }

        public void Update(Department department)
        {
            /*  var dept = GetById(department.Id);
               if(dept.Name != department.Name)
               {
                   if (GetAll().Any(x => x.Name == department.Name))
                       throw new Exception("Duplicate Department Name");
               }
               dept.Name = department.Name;
               dept.code = department.code;*/
            _UnitOfWork.DepartmentRepository.Update(department);
            _UnitOfWork.Complete();
        }



    }
}
