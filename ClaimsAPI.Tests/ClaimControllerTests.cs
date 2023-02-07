using ClaimsAPI.Controllers;
using ClaimsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimsAPI.Tests
{
    [TestClass]
    public class ClaimControllerTests
    {
        [TestMethod]
        public void ClaimController_GetAllClaims_ReturnsSuccess()
        {
            ClaimController _claimController;
            _claimController = new ClaimController();

            _claimController.claims = new List<Claim>()
            {
                new Claim
                {
                    UCR = 2221,
                    AssuredName = "Arthur",
                    ClaimDate = DateTime.Now.AddDays(-200),
                    Closed = true,
                    CompanyId = 21,
                    IncurredLoss = 1200,
                    LossDate = DateTime.Now.AddDays(-180)
                },
                new Claim
                {
                    UCR = 2231,
                    AssuredName = "Benjamin",
                    ClaimDate = DateTime.Now.AddDays(-210),
                    Closed = true,
                    CompanyId = 15,
                    IncurredLoss = 669,
                    LossDate = DateTime.Now.AddDays(-199)
                }
            };

            var result = _claimController.GetAllClaims();

            Assert.IsInstanceOfType(result.Result.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void ClaimController_GetAllClaims_ReturnsNotFound()
        {
            ClaimController _claimController;
            _claimController = new ClaimController();

            _claimController.claims = null;

            var result = _claimController.GetAllClaims();

            Assert.IsInstanceOfType(result.Result.Result, typeof(NotFoundResult));
        }
    }
}