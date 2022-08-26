using Dapper;
using LegoSetsService.Dal.Providers;
using LegoSetsService.DomainModels;

namespace LegoSetsService.Dal
{
    public class SetsRepository
    {
        private readonly IDbConnectionProvider _dbConnectionProvider;

        public SetsRepository(IDbConnectionProvider dbConnectionProvider)
        {
            _dbConnectionProvider = dbConnectionProvider;
        }

        public async Task<SetDomainModel> Create(SetCreateDomainModel modelToCreate)
        {
            using (var connection = _dbConnectionProvider.GetConnection())
            {
                var idOfInsertedRecord = await connection.QuerySingleAsync<int>(
                    @"INSERT INTO Firms(NameShort, NameFull, Street, City, HomeNumber, ApartmentNumber, Country, ZipCode, NIP, Regon, KRS) 
                        OUTPUT INSERTED.Id 
                        VALUES (@NameShort, @NameFull, @Street, @City, @HomeNumber, @ApartmentNumber, @Country, @ZipCode, @NIP, @Regon, @KRS)",
                    new
                    {
                        modelToCreate.NameShort,
                        modelToCreate.NameFull,
                        modelToCreate.Street,
                        modelToCreate.City,
                        modelToCreate.HomeNumber,
                        modelToCreate.ApartmentNumber,
                        modelToCreate.Country,
                        modelToCreate.ZipCode,
                        modelToCreate.NIP,
                        modelToCreate.Regon,
                        modelToCreate.KRS
                    });

                if (idOfInsertedRecord == 0)
                {
                    throw new InvalidOperationException($"{nameof(FirmCreateDomainModel)} was not created");
                }

                return await Get(idOfInsertedRecord);
            }
        }
    }
}
