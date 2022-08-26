using LegoSetsService.DomainModels;

namespace LegoSetsService.Dal.Interfaces
{
    public interface ISetsRepository
    {
        Task<SetDomainModel> Create(SetCreateDomainModel modelToCreate);
        Task<SetDomainModel> Get(int id);
    }
}