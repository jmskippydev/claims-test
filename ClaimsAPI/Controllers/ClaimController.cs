using ClaimsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        public List<Claim> claims = new List<Claim> 
        {
            new Claim
            {
                UCR = 9999,
                AssuredName = "Teddy",
                ClaimDate = DateTime.Now.AddDays(-45),
                Closed = true,
                CompanyId = 21,
                IncurredLoss = 900,
                LossDate = DateTime.Now.AddDays(-30)
            },
            new Claim
            {
                UCR = 9998,
                AssuredName = "Mark",
                ClaimDate = DateTime.Now.AddDays(-31),
                Closed = true,
                CompanyId = 15,
                IncurredLoss = 100,
                LossDate = DateTime.Now.AddDays(-10)
            },
            new Claim
            {
                UCR = 9997,
                AssuredName = "Rudolph",
                ClaimDate = DateTime.Now.AddDays(-11),
                Closed = false,
                CompanyId = 21,
                IncurredLoss = 210,
                LossDate = DateTime.Now.AddDays(-1)
            },
            new Claim
            {
                UCR = 9996,
                AssuredName = "Barry",
                ClaimDate = DateTime.Now.AddDays(-75),
                Closed = false,
                CompanyId = 21,
                IncurredLoss = 1300,
                LossDate = DateTime.Now.AddDays(-60)
            },
            new Claim
            {
                UCR = 9995,
                AssuredName = "Caleb",
                ClaimDate = DateTime.Now.AddDays(-99),
                Closed = false,
                CompanyId = 16,
                IncurredLoss = 11000,
                LossDate = DateTime.Now.AddDays(-22)
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<Claim>>> GetAllClaims()
        {
            if (claims == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(claims);
            }
        }

        [HttpGet("{ucr}")]
        public async Task<ActionResult<Claim>> GetClaim(int ucr)
        {
            var claim = claims.Find(c => c.UCR == ucr);
            if (claim is null)
                return NotFound($"No claim found for UCR {ucr}");
            return Ok(claim);
        }

        [HttpPost]
        public async Task<ActionResult<Claim>> AddClaim(Claim claim)
        {
            claims.Add(claim);
            return Ok(claim);
        }

        [HttpPut("{ucr}")]
        public async Task<ActionResult<Claim>> UpdateClaim(int ucr, Claim claim)
        {
            var claimToUpdate = claims.Find(c => c.UCR == ucr);
            if (claimToUpdate is null)
                return NotFound($"No claim found to update for UCR {ucr}");

            claimToUpdate.ClaimDate = claim.ClaimDate;
            claimToUpdate.LossDate = claim.LossDate;
            claimToUpdate.AssuredName = claim.AssuredName;
            claimToUpdate.IncurredLoss = claim.IncurredLoss;
            claimToUpdate.Closed = claim.Closed;

            return Ok(claim);
        }
    }
}
