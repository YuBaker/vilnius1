using MediatR;
using Microsoft.EntityFrameworkCore;
using Vilnius1.Application.Database;
using Vilnius1.Application.Models;

namespace Vilnius1.Application.Handlers;

public class GetFacilityRequest : IRequest<Facility>
{
    public long FacilityId { get; set; }
}

public class GetFacilityHandler : IRequestHandler<GetFacilityRequest, Facility>
{
    private readonly AppDbContext _context;

    public GetFacilityHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Facility> Handle(GetFacilityRequest request,
        CancellationToken cancellationToken = default)
    {
        return await _context.Facilities.AsNoTracking()
            .Include(x => x.FacilityAssignments)
            .ThenInclude(x => x.Assignment)
            .Where(x => x.Id == request.FacilityId)
            .FirstAsync(cancellationToken);

    }
}
