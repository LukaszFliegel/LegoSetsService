using Dapper;
using LegoSetsService.Dal.Interfaces;
using LegoSetsService.Dal.Providers;
using LegoSetsService.DomainModels;
using LegoSetsService.Exceptions;

namespace LegoSetsService.Dal
{
    public class SetsRepository : ISetsRepository
    {
        private readonly IDbConnectionProvider _dbConnectionProvider;

        public SetsRepository(IDbConnectionProvider dbConnectionProvider)
        {
            _dbConnectionProvider = dbConnectionProvider;
        }

        public async Task<SetDomainModel> Get(int id)
        {
            using (var connection = _dbConnectionProvider.GetConnection())
            {
                var entity = await connection.QueryFirstOrDefaultAsync<SetDomainModel>(@$"
                    SELECT * FROM Sets WHERE Id = @id",
                    new { id }
                );

                if (entity == null)
                {
                    throw new ResourceNotFoundException("Sets");
                }

                return entity;
            }
        }

        public async Task<SetDomainModel> Create(SetCreateDomainModel modelToCreate)
        {
            using (var connection = _dbConnectionProvider.GetConnection())
            {
                var idOfInsertedRecord = await connection.QuerySingleAsync<int>(
                    @"INSERT INTO Set(SetNumber, Name, ManufacturerPrice, ReleaseDate, RetireDate, FigsCount, UniqeFigsCount) 
                        OUTPUT INSERTED.Id 
                        VALUES (@SetNumber, @Name, @ManufacturerPrice, @ReleaseDate, @RetireDate, @FigsCount, @UniqeFigsCount)",
                    new
                    {
                        modelToCreate.SetNumber,
                        modelToCreate.Name,
                        modelToCreate.ManufacturerPrice,
                        modelToCreate.ReleaseDate,
                        modelToCreate.RetireDate,
                        modelToCreate.FigsCount,
                        modelToCreate.UniqeFigsCount,
                    });

                if (idOfInsertedRecord == 0)
                {
                    throw new InvalidOperationException($"{nameof(SetCreateDomainModel)} was not created");
                }

                return await Get(idOfInsertedRecord);
            }
        }
    }
}
