using Microsoft.AspNetCore.Mvc;
using CandidateFinder.Models;
using MediatR;
using CandidateFinder.MediatRService.CandidateService;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CandidateFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateFinderController : ControllerBase
    {
      
        private readonly IMediator _mediator;

        public CandidateFinderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create Candidate
        /// </summary>
        /// <param name="Candidate"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpsertAsync([FromBody] CandidateDTO Candidate)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new UpsertCandidateCommand(Candidate));

                return Ok(result);
            }
            return BadRequest("There is error in the request");
        }
    }
}
