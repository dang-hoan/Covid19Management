using Covid19Management.Models;
using Covid19Management.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace Covid19Management.Repositories
{
    public class VacxinRepository : IVacxinRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public VacxinRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public IQueryable<Vacxin> GetAllVacxins()
        {
            return _dbContext.Vacxins.AsNoTracking();
        }        

        public Vacxin? Find(string vacxinCode)
        {
            return _dbContext.Vacxins.Where(v => v.VacxinCode.Equals(vacxinCode)).FirstOrDefault();
        }

        public void AddVacxin(Vacxin vacxin)
        {
            _dbContext.Vacxins.Add(vacxin);
            _dbContext.SaveChanges();
        }

        public void UpdateVacxin(Vacxin vacxin)
        {
            _dbContext.Vacxins.Update(vacxin);
            _dbContext.SaveChanges();
        }       

        public void DeleteVacxin(Vacxin vacxin)
        {
            _dbContext.Vacxins.Remove(vacxin);
            _dbContext.SaveChanges();
        }      

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
       
    }
}
