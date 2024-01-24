using Covid19Management.Models;
using Covid19Management.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace Covid19Management.Repositories
{
    public class CitizenRepository : ICitizenRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CitizenRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public IQueryable<Citizen> GetAllCitizens()
        {
            return _dbContext.Citizens.AsNoTracking();
        }        

        public Citizen? Find(string citizenCode)
        {
            return _dbContext.Citizens.Where(v => v.CitizenCode.Equals(citizenCode)).FirstOrDefault();
        }

        public void AddCitizen(Citizen citizen)
        {
            _dbContext.Citizens.Add(citizen);
            _dbContext.SaveChanges();
        }

        public void UpdateCitizen(Citizen citizen)
        {
            _dbContext.Citizens.Update(citizen);
            _dbContext.SaveChanges();
        }       

        public void DeleteCitizen(Citizen citizen)
        {
            _dbContext.Citizens.Remove(citizen);
            _dbContext.SaveChanges();
        }      

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
       
    }
}
