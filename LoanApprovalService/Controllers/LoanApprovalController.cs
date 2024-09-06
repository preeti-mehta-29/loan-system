using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using LoanApprovalService.Models;
using LoanApprovalService.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanApprovalService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanApprovalController : ControllerBase
    {
        private readonly ILoanApprovalRepository _loanRepository;
        public LoanApprovalController(ILoanApprovalRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        // GET api/<LoanApprovalController>/5
        [HttpGet("{loanId}")]
        public IActionResult Get(int loanId)
        {
            var loan = _loanRepository.GetLoanStatus(loanId);
            return new OkObjectResult(loan);
        }

        // POST api/<LoanController>
        [HttpPost]
        public IActionResult Post([FromBody] LoanApproval loan)
        {
            using (var scope = new TransactionScope())
            {
                _loanRepository.UpdateLoanStatus(loan);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = loan.Id }, loan);
            }
        }
    }
}
