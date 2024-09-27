// To simulate getting an annual revenue summary
using ComptrollerApi.Data;
using ComptrollerApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ComptrollerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevenueController : ControllerBase
    {
        private readonly TaxReportRepository _repository;

        public RevenueController(TaxReportRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{year}")]
        public async Task<ActionResult<decimal>> GetAnnualRevenue(int year)
        {
            var reports = await _repository.GetAllAsync();
            var totalRevenue = reports
                                          .Where(r => r.SubmittedDate.Year == year)
                                          .Sum(r => r.Revenue);
            return Ok(totalRevenue);
        }
    }
}
