using Covid19Management.Models;
using Covid19Management.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace Covid19Management.Repositories
{
    public class VacxinTypeRepository : IVacxinTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public VacxinTypeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public IQueryable<VacxinType> GetAllVacxinTypes()
        {
            return _dbContext.VacxinTypes.AsNoTracking();
        }        

        public VacxinType? Find(string vacxinTypeCode)
        {
            return _dbContext.VacxinTypes.Where(v => v.VacxinTypeCode.Equals(vacxinTypeCode)).FirstOrDefault();
        }

        public void AddVacxinType(VacxinType vacxinType)
        {
            _dbContext.VacxinTypes.Add(vacxinType);
            _dbContext.SaveChanges();
        }

        public void UpdateVacxinType(VacxinType vacxinType)
        {
            _dbContext.VacxinTypes.Update(vacxinType);
            _dbContext.SaveChanges();
        }       

        public void DeleteVacxinType(VacxinType vacxinType)
        {
            _dbContext.VacxinTypes.Remove(vacxinType);
            _dbContext.SaveChanges();
        }      

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
       
    }
}
