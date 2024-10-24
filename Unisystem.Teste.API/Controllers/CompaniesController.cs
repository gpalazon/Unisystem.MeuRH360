using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unisystem.Teste.Application.DTO;
using Unisystem.Teste.Application.Interfaces;

namespace Unisystem.Teste.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICompanyService _companyService;

        public CompaniesController(ILogger<WeatherForecastController> logger, ICompanyService companyService)
        {
            _logger = logger;
            _companyService = companyService;
        }


        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetAllCompanies()
        {
            var users = await _companyService.GetAllCompanysAsync();
            return Ok(users);
        }

        // GET: api/Companies/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDTO>> GetCompanyById(int id)
        {
            var user = await _companyService.GetCompanyByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CompanyDTO companyDto)
        {
            await _companyService.AddCompanyAsync(companyDto);
            //if (!result.Succeeded)
            //    return BadRequest(result.Errors);

            return Ok();
        }
    }
}
