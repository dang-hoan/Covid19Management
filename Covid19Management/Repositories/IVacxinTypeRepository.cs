using Covid19Management.Models;

namespace Covid19Management.Repositories
{
    public interface IVacxinTypeRepository
    {
        IQueryable<VacxinType> GetAllVacxinTypes();
        VacxinType? Find(string vacxinTypeCode);
        void AddVacxinType(VacxinType vacxinType);
        void UpdateVacxinType(VacxinType vacxinType);
        void DeleteVacxinType(VacxinType vacxinType);
        void Dispose();
    }
}
