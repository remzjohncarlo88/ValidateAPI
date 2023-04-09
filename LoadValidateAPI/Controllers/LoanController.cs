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

        public LoanController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpPost("~/CreateApplicant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public string Create(Applicant applicant)
        {
            var app = _repository.ApplicantRepository.CreateApplicant(applicant);

            return app;
        }
    }
}
