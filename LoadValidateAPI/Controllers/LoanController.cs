using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using Entities.Models;

namespace LoadValidateAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private readonly IConfiguration _configuration;

        public LoanController(IRepositoryWrapper repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        [HttpPost("~/CreateApplicant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Result Create(Applicant applicant)
        {
            Dictionary<string, string> conditionalDict = new Dictionary<string, string>();
            conditionalDict.Add("TradingLow", _configuration["TimeTrading:Low"]);
            conditionalDict.Add("TradingHigh", _configuration["TimeTrading:High"]);
            conditionalDict.Add("LoanLow", _configuration["LoanAmount:Low"]);
            conditionalDict.Add("LoanHigh", _configuration["LoanAmount:High"]);

            var rt = applicant;

            Result app = _repository.ApplicantRepository.CreateApplicant(applicant, conditionalDict);

            return app;
        }
    }
}
