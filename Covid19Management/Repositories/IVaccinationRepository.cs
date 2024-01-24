using Covid19Management.Models;

namespace Covid19Management.Repositories
{
    public interface IVaccinationRepository
    {
        IQueryable<Vaccination> GetAllVaccinations();
        Vaccination? Find(string vaccinationCode);
        void AddVaccination(Vaccination vaccination);
        void UpdateVaccination(Vaccination vaccination);
        void DeleteVaccination(Vaccination vaccination);
        void Dispose();
    }
}
