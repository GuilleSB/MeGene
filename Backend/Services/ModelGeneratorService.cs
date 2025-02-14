using MeGeneAPI.Interfaces.IRepositories;
using MeGeneAPI.Interfaces.IServices;
using MeGeneAPI.Models;
using System.Text;

namespace MeGeneAPI.Services
{
    public class ModelGeneratorService : IModelGeneratorService
    {
        private readonly IDatabaseRepository _tableRepository;
        public ModelGeneratorService(IDatabaseRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }
        public async Task<string> GenerateCSharpModelAsync(List<TableColumn> columns, string tableName)
        {
            var className = tableName;
            var sb = new StringBuilder();

            sb.AppendLine("using System;");
            sb.AppendLine("using System.ComponentModel.DataAnnotations;");
            sb.AppendLine("using System.ComponentModel.DataAnnotations.Schema;");
            sb.AppendLine();
            sb.AppendLine($"public class {className}");
            sb.AppendLine("{");

            foreach (var column in columns)
            {
                if (column.IsNullable)
                    sb.AppendLine($"    public {GetCSharpType(column.DataType, true)} {column.ColumnName} {{ get; set; }}");
                else
                    sb.AppendLine($"    [Required]\n    public {GetCSharpType(column.DataType, false)} {column.ColumnName} {{ get; set; }}");
            }

            sb.AppendLine("}");

            return await Task.FromResult(sb.ToString());
        }

        private string GetCSharpType(string sqlType, bool isNullable)
        {
            var typeMap = new Dictionary<string, string>
        {
            { "int", "int" },
            { "bigint", "long" },
            { "varchar", "string" },
            { "nvarchar", "string" },
            { "text", "string" },
            { "decimal", "decimal" },
            { "numeric", "decimal" },
            { "float", "double" },
            { "datetime", "DateTime" },
            { "bit", "bool" }
        };

            if (typeMap.ContainsKey(sqlType.ToLower()))
                return isNullable && sqlType != "string" ? $"{typeMap[sqlType]}?" : typeMap[sqlType];

            return "object"; // Default para tipos desconocidos
        }
    }
}
