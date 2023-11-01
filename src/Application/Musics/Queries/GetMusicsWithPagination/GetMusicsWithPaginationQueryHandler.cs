using MusicManagement.Application.Common.Interfaces;
using MusicManagement.Application.Common.Mappings;
using MusicManagement.Application.Common.Models;

namespace MusicManagement.Application.Musics.Queries.GetMusicsWithPagination;

public record GetMusicsWithPaginationQuery : IRequest<PaginatedList<MusicBriefDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetMusicsWithPaginationQueryHandler : IRequestHandler<GetMusicsWithPaginationQuery, PaginatedList<MusicBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMusicsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<MusicBriefDto>> Handle(GetMusicsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Musics
            .OrderBy(x => x.Title)
            .ProjectTo<MusicBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
