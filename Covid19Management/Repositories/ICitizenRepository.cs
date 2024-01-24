using Covid19Management.Models;

namespace Covid19Management.Repositories
{
    public interface ICitizenRepository
    {
        IQueryable<Citizen> GetAllCitizens();
        Citizen? Find(string citizenCode);
        void AddCitizen(Citizen citizen);
        void UpdateCitizen(Citizen citizen);
        void DeleteCitizen(Citizen citizen);
        void Dispose();
    }
}
