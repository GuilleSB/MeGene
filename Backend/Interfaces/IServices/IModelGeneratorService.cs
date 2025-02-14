using MeGeneAPI.Models;

namespace MeGeneAPI.Interfaces.IServices
{
    public interface IModelGeneratorService
    {
        Task<string> GenerateCSharpModelAsync(List<TableColumn> columns, string tableName);
    }
}
