using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using VasilevV.E._KT_31_21.Interfaces.DisciplinesInterfaces;
using VasilevV.E._KT_31_21.Filters.DisciplineFilters;

namespace VasilevV.E._KT_31_21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinesController : ControllerBase
    {
        private readonly ILogger<DisciplinesController> _logger;
        private readonly IDisciplineService _disciplineService;

        public DisciplinesController(ILogger<DisciplinesController> logger, IDisciplineService disciplineService)
        {
            _logger = logger;
            _disciplineService = disciplineService;
        }
        [HttpPost("by-direction", Name = "GetDisciplinesByDirection")]
        public async Task<IActionResult> GetDisciplinesByDirectionAsync(DisciplineDirectionFilter filter, CancellationToken cancellationToken=default)
        {
            var disciplines = await _disciplineService.GetDisciplinesByDirectionAsync(filter, cancellationToken);
            return Ok(disciplines);
        }

        [HttpPost("by-deleted", Name = "GetDisciplinesByDeleted")]
        public async Task<IActionResult> GetDisciplinesByDeletedAsync(DisciplineDeletedFilter filter, CancellationToken cancellationToken = default)
        {
            var disciplines = await _disciplineService.GetDisciplinesByDeletedAsync(filter, cancellationToken);
            return Ok(disciplines);
        }
    }
}
