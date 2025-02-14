using MeGeneAPI.Interfaces.IRepositories;
using MeGeneAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MeGeneAPI.Repositories
{
    public class DatabaseRepository : IDatabaseRepository
    {
        public async Task<List<string>> GetDatabasesAsync(string connectionString)
        {
            var databases = new List<string>();

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SELECT name FROM sys.databases WHERE state_desc = 'ONLINE' AND database_id > 4", connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        databases.Add(reader.GetString(0));
                    }
                }
            }

            return databases;
        }

        public async Task<List<string>> GetSchemasAsync(string connectionString)
        {
            var schemas = new List<string>();

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SELECT name FROM sys.schemas", connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        schemas.Add(reader.GetString(0));
                    }
                }
            }

            return schemas;
        }

        public async Task<List<string>> GetTablesAsync(string connectionString, string schemaName)
        {
            var tables = new List<string>();

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = @SchemaName", connection))
                {
                    command.Parameters.AddWithValue("@SchemaName", schemaName);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            tables.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return tables;
        }

        public async Task<List<TableColumn>> GetTableStructureAsync(string connectionString, string schemaName, string tableName)
        {
            var columns = new List<TableColumn>();

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(@"
                SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE, IS_NULLABLE 
                FROM INFORMATION_SCHEMA.COLUMNS 
                WHERE TABLE_SCHEMA = @SchemaName AND TABLE_NAME = @TableName", connection))
                {
                    command.Parameters.AddWithValue("@SchemaName", schemaName);
                    command.Parameters.AddWithValue("@TableName", tableName);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            columns.Add(new TableColumn
                            {
                                ColumnName = reader["COLUMN_NAME"].ToString(),
                                DataType = reader["DATA_TYPE"].ToString(),
                                MaxLength = reader["CHARACTER_MAXIMUM_LENGTH"] as int?,
                                Precision = reader["NUMERIC_PRECISION"] as int?,
                                Scale = reader["NUMERIC_SCALE"] as int?,
                                IsNullable = reader["IS_NULLABLE"].ToString() == "YES"
                            });
                        }
                    }
                }
            }

            return columns;
        }
    }
}
