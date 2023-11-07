using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicManagement.Application.Common.Models;
using MusicManagement.Application.Musics.Commands.Create;
using MusicManagement.Application.Musics.Commands.Delete;
using MusicManagement.Application.Musics.Commands.Update;
using MusicManagement.Application.Musics.Queries.GetMusicsWithPagination;

namespace MusicManagement.Web.Controllers;

[Route("Api/[controller]")]
[ApiController]
public class MusicsController : ControllerBase
{
    private readonly IMediator _mediator;

    public MusicsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<PaginatedList<MusicBriefDto>> GetDataWithPagination([FromQuery] GetMusicsWithPaginationQuery query)
    {
        return await _mediator.Send(query);
    }

    [HttpPost]
    public async Task<int> Create(CreateMusicCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<IResult> Update(int id, UpdateMusicCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await _mediator.Send(command);
        return Results.NoContent();
    }

    [HttpPut("UpdateDetail/{id}")]
    public async Task<IResult> UpdateDetail(int id, UpdateMusicDetailCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await _mediator.Send(command);
        return Results.NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id)
    {
        await _mediator.Send(new DeleteMusicCommand(id));
        return Results.NoContent();
    }
}
