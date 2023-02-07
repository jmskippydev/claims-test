using ClaimsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private static List<Company> companies = new List<Company>
        {
                    new Company
                    {
                        Id = 21,
                        Name = "Arts Inc",
                        Address1 = "33 Zool Road",
                        Address2 = "Camden",
                        Address3 = "London",
                        PostCode = "NW1 0EG",
                        Country = "England",
                        Active = true,
                        InsuranceEndDate = DateTime.Today.AddMonths(4)
                    },
                    new Company
                    {
                        Id = 15,
                        Name = "Teslamania",
                        Address1 = "55 Turnpike Road",
                        Address2 = "",
                        Address3 = "Stockholm",
                        PostCode = "SWE DEN",
                        Country = "Sweden",
                        Active = true,
                        InsuranceEndDate = DateTime.Today.AddMonths(-2)
                    },
                    new Company
                    {
                        Id = 16,
                        Name = "Industrial Burger",
                        Address1 = "4 Pounds Avenue",
                        Address2 = "Bavaria",
                        Address3 = "Munchen",
                        PostCode = "BU0 GUR",
                        Country = "Germany",
                        Active = true,
                        InsuranceEndDate = DateTime.Today.AddMonths(22)
                    },
                    new Company
                    {
                        Id = 44,
                        Name = "Marco van Basten",
                        Address1 = "10 Silk Shoe Road",
                        Address2 = "Ijmuiden",
                        Address3 = "Amsterdam",
                        PostCode = "AJA 11M",
                        Country = "Nederland",
                        Active = false,
                        InsuranceEndDate = DateTime.Today.AddYears(-12)
                    }
        };

        [HttpGet]
        public async Task<ActionResult<List<Company>>> GetAllCompanies()
        {
            return Ok(companies);
        }

        [HttpGet("{companyName}")]
        public async Task<ActionResult<Company>> GetCompany(string companyName)
        {
            var company = companies.Find(c => c.Name.ToLower().Contains(companyName.ToLower()));
            if (company is null)
                return NotFound($"No company found for {companyName}");

            return Ok(company);
        }
    }
}
