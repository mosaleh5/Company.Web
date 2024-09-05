using Company.Data.Contexts;
using Company.Data.Entities;
using Company.Repository.Interfaces;


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
                =>companyDbContext.Set<T>().Add(Entity);
        

        public void Delete(T Entity)
           => companyDbContext.Set<T>().Remove(Entity);
        

        public IEnumerable<T> GetAll()
           =>  companyDbContext.Set<T>().ToList();
        

        public T GetById(int id)
           => companyDbContext.Set<T>().FirstOrDefault(x => x.Id == id);
        
        public void Update(T Entity)
            =>companyDbContext.Update(Entity);
        
        
    }
}
