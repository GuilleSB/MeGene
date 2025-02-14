using MeGeneAPI.Interfaces.IRepositories;
using MeGeneAPI.Interfaces.IServices;
using MeGeneAPI.Models;

namespace MeGeneAPI.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly IDatabaseRepository _databaseRepository;

        public DatabaseService(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        public async Task<List<string>> GetDatabasesAsync(string connectionString)
        {
            return await _databaseRepository.GetDatabasesAsync(connectionString);
        }

        public async Task<List<string>> GetSchemasAsync(string connectionString, string database)
        {
            var formattedConnectionString = $"{connectionString};Initial Catalog={database}";
            return await _databaseRepository.GetSchemasAsync(formattedConnectionString);
        }

        public async Task<List<string>> GetTablesAsync(string connectionString, string database, string schema)
        {
            var formattedConnectionString = $"{connectionString};Initial Catalog={database}";
            return await _databaseRepository.GetTablesAsync(formattedConnectionString, schema);
        }

        public async Task<List<TableColumn>> GetTableStructureAsync(string connectionString, string database, string schema, string table)
        {
            var formattedConnectionString = $"{connectionString};Initial Catalog={database}";
            return await _databaseRepository.GetTableStructureAsync(formattedConnectionString, schema, table);
        }
    }
}
