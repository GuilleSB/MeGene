using MeGeneAPI.Models;

namespace MeGeneAPI.Interfaces.IRepositories
{
    public interface IDatabaseRepository
    {
        Task<List<string>> GetDatabasesAsync(string connectionString);
        Task<List<string>> GetSchemasAsync(string connectionString);
        Task<List<string>> GetTablesAsync(string connectionString, string schemaName);
        Task<List<TableColumn>> GetTableStructureAsync(string connectionString, string schemaName, string tableName);
    }
}
