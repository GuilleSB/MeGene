using MeGeneAPI.Interfaces.IServices;
using MeGeneAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/model")]
public class ModelGeneratorController : ControllerBase
{
    private readonly IDatabaseService _databaseService;
    private readonly IModelGeneratorService _modelGeneratorService;

    public ModelGeneratorController(IDatabaseService databaseService, IModelGeneratorService modelGeneratorService)
    {
        _databaseService = databaseService;
        _modelGeneratorService = modelGeneratorService;
    }

    [HttpPost("generate")]
    public async Task<IActionResult> GenerateModel([FromBody] TableRequest request)
    {
        var tableStructure = await _databaseService.GetTableStructureAsync(request.ConnectionString, request.Database, request.Schema, request.Table);
        var modelCode = await _modelGeneratorService.GenerateCSharpModelAsync(tableStructure, request.Table);
        return Ok(new ApiResponse<string>(true, $"Model generated for table {request.Table}", modelCode));
    }
}
