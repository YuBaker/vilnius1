using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vilnius1.Api.Contracts;
using Vilnius1.Application.Handlers;

namespace Vilnius1.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacilitiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FacilitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/{id}")]
        public async Task<Facility> GetFacility(int id)
        {
            var facility = await _mediator.Send(new GetFacilityRequest
            {
                FacilityId = id
            });

            return new Facility
            {
                Id = facility.Id,
                Name = facility.Name,
                AssignmentNames = facility.FacilityAssignments.Select(x => x.Assignment.Name!).ToList(),
                Assignments = facility.FacilityAssignments.Select(x => new Assignment
                {
                    Id = x.Assignment.Id,
                    Name = x.Assignment.Name
                }).ToList()
            };
        }

        [HttpPost]
        [Route("/")]
        public IList<Facility> CreateFacility()
        {
            return null;
        }
    }
}