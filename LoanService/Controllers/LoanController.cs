using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using LoanService.Models;
using LoanService.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanRepository _loanRepository;
        public LoanController(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        // GET: api/<LoanController>/8
        [HttpGet]
        public IActionResult GetLoans(int userId)
        {
            var loans = _loanRepository.GetLoanDetails(userId);
            return new OkObjectResult(loans);
        }

        // GET api/<LoanController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int loanId)
        {
            var loan = _loanRepository.GetLoanDetailsById(loanId);
            return new OkObjectResult(loan);
        }

        // POST api/<LoanController>
        [HttpPost]
        public IActionResult Post([FromBody] Loan loan)
        {
            using (var scope = new TransactionScope())
            {                
                _loanRepository.CreateLoan(loan);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = loan.Id }, loan);
            }
        }
    }
}
