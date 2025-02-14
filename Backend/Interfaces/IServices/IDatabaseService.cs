using MeGeneAPI.Models;

namespace MeGeneAPI.Interfaces.IServices
{
    public interface IDatabaseService
    {
        Task<List<string>> GetDatabasesAsync(string connectionString);
        Task<List<string>> GetSchemasAsync(string connectionString, string database);
        Task<List<string>> GetTablesAsync(string connectionString, string database, string schema);
        Task<List<TableColumn>> GetTableStructureAsync(string connectionString, string database, string schema, string table);
    }
}
