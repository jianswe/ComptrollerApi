using ComptrollerApi.Data;
using ComptrollerApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ComptrollerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxReportsController : ControllerBase
    {
        private readonly TaxReportRepository _repository;

        // Inject the repository as a service using Dependency Injection (DI), which will allow the repository to persist across requests.
        public TaxReportsController(TaxReportRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxReport>>> GetTaxReports()
        {
            var reports = await _repository.GetAllAsync();
            return Ok(reports);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaxReport>> GetTaxReport(int id)
        {
            var report = await _repository.GetByIdAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            return Ok(report);
        }

        [HttpPost]
        public async Task<ActionResult<TaxReport>> SubmitTaxReport([FromBody] TaxReport report)
        {
            await _repository.AddAsync(report);
            return CreatedAtAction(nameof(GetTaxReport), new { id = report.Id }, report);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaxReport(int id, [FromBody] TaxReport report)
        {
            if (id != report.Id)
            {
                return BadRequest();
            }
            await _repository.UpdateAsync(report);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaxReport(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
