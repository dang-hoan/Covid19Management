using Covid19Management.Models;

namespace Covid19Management.Repositories
{
    public interface IVacxinRepository
    {
        IQueryable<Vacxin> GetAllVacxins();
        Vacxin? Find(string vacxinCode);
        void AddVacxin(Vacxin vacxin);
        void UpdateVacxin(Vacxin vacxin);
        void DeleteVacxin(Vacxin vacxin);
        void Dispose();
    }
}
