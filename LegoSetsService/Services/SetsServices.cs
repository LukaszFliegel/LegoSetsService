using HtmlAgilityPack;
using LegoSetsService.Configuration;
using LegoSetsService.Dal.Interfaces;
using LegoSetsService.DomainModels;
using LegoSetsService.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace LegoSetsService.Services
{
    public class SetsServices : ISetsServices
    {
        private readonly ISetsRepository _setsRepository;
        private readonly ExternalSitesUrls _externalSitesUrls;
        private string ManufacturersSetsUrl(string setNumber) => $"/product/{setNumber}";

        public SetsServices(ISetsRepository setsRepository, IOptions<ExternalSitesUrls> externalSitesUrls)
        {
            _setsRepository = setsRepository;
            _externalSitesUrls = externalSitesUrls.Value;
        }

        public async Task<SetDomainModel> Get(int id)
        {
            return await _setsRepository.Get(id);
        }

        public async Task<SetDomainModel> TrackNewSet(string setNumber)
        {
            var setCreateDomainModel = new SetCreateDomainModel()
            {
                SetNumber = setNumber,
            };

            var web = new HtmlWeb()
            {
                CaptureRedirect = true,
            };

            var manufacturerDoc = web.Load($"{_externalSitesUrls.ManufacturerPage}{ManufacturersSetsUrl(setNumber)}");
            var priceSpan = manufacturerDoc.DocumentNode.SelectNodes("//span[@data-test='product - price']");

            return await _setsRepository.Create(setCreateDomainModel);
        }
    }
}
