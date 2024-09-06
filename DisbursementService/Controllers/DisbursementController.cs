using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using DisbursementService.Models;
using DisbursementService.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DisbursementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisbursementController : ControllerBase
    {
        private readonly IDisbursementRepository _disbursementRepository;
        public DisbursementController(IDisbursementRepository disbursementRepository)
        {
            _disbursementRepository = disbursementRepository;
        }

        // GET api/<DisbursementController>/5
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            var loan = _disbursementRepository.GetDisbursementDetails(Id);
            return new OkObjectResult(loan);
        }

        // GET api/<DisbursementController>/5
        [HttpGet("{loanId}")]
        public IActionResult GetDetailsByLoanId(int loanId)
        {
            var loan = _disbursementRepository.GetDetailsByLoanId(loanId);
            return new OkObjectResult(loan);
        }

        // GET api/<DisbursementController>/5
        [HttpGet("{userId}")]
        public IActionResult GetUserLoans(int userId)
        {
            var loan = _disbursementRepository.GetUserLoans(userId);
            return new OkObjectResult(loan);
        }

        // POST api/<DisbursementController>
        [HttpPost]
        public IActionResult Post([FromBody] Disbursement loan)
        {
            using (var scope = new TransactionScope())
            {
                _disbursementRepository.UpdateDisbursementStatus(loan);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = loan.Id }, loan);
            }
        }
    }
}
