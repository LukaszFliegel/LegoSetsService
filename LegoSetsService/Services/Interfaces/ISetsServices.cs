using LegoSetsService.DomainModels;

namespace LegoSetsService.Services.Interfaces
{
    public interface ISetsServices
    {
        Task<SetDomainModel> Get(int id);
        Task<SetDomainModel> TrackNewSet(string setNumber);
    }
}