using Covid19Management.Models;
using Covid19Management.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace Covid19Management.Repositories
{
    public class VaccinationRepository : IVaccinationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public VaccinationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public IQueryable<Vaccination> GetAllVaccinations()
        {
            return _dbContext.Vaccinations.AsNoTracking();
        }        

        public Vaccination? Find(string vaccinationCode)
        {
            return _dbContext.Vaccinations.Where(v => v.VaccinationCode.Equals(vaccinationCode)).FirstOrDefault();
        }

        public void AddVaccination(Vaccination vaccination)
        {
            _dbContext.Vaccinations.Add(vaccination);
            _dbContext.SaveChanges();
        }

        public void UpdateVaccination(Vaccination vaccination)
        {
            _dbContext.Vaccinations.Update(vaccination);
            _dbContext.SaveChanges();
        }       

        public void DeleteVaccination(Vaccination vaccination)
        {
            _dbContext.Vaccinations.Remove(vaccination);
            _dbContext.SaveChanges();
        }      

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
       
    }
}
