using MeGeneAPI.Interfaces.IServices;
using MeGeneAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeGeneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly IDatabaseService _databaseService;

        public DatabaseController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetDatabases([FromBody] ConnectionRequest request)
        {
            var databases = await _databaseService.GetDatabasesAsync(request.ConnectionString);
            return Ok(new ApiResponse<List<string>>(true, "Databases retrieved successfully", databases));
        }

        [HttpPost("schemas")]
        public async Task<IActionResult> GetSchemas([FromBody] DatabaseRequest request)
        {
            var schemas = await _databaseService.GetSchemasAsync(request.ConnectionString, request.Database);
            return Ok(new ApiResponse<List<string>>(true, $"Schemas retrieved for database {request.Database}", schemas));
        }

        [HttpPost("tables")]
        public async Task<IActionResult> GetTables([FromBody] SchemaRequest request)
        {
            var tables = await _databaseService.GetTablesAsync(request.ConnectionString, request.Database, request.Schema);
            return Ok(new ApiResponse<List<string>>(true, $"Tables retrieved for schema {request.Schema} in database {request.Database}", tables));
        }

        [HttpPost("table-structure")]
        public async Task<IActionResult> GetTableStructure([FromBody] TableRequest request)
        {
            var structure = await _databaseService.GetTableStructureAsync(request.ConnectionString, request.Database, request.Schema, request.Table);
            return Ok(new ApiResponse<List<TableColumn>>(true, $"Table structure retrieved for {request.Table}", structure));
        }

    }
}
