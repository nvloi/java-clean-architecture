using Microsoft.AspNetCore.Mvc;
using MusicManagement.Application.Common.Models;
using MusicManagement.Application.Musics.Commands.Create;
using MusicManagement.Application.Musics.Commands.Delete;
using MusicManagement.Application.Musics.Commands.Update;
using MusicManagement.Application.Musics.Queries.GetMusicsWithPagination;

namespace MusicManagement.Web.Endpoints;

[Route("Api/[controller]")]
[ApiController]
public class Musics
{
    [HttpGet]
    public async Task<PaginatedList<MusicBriefDto>> GetDataWithPagination(ISender sender, [FromQuery] GetMusicsWithPaginationQuery query)
    {
        return await sender.Send(query);
    }

    [HttpPost]
    public async Task<int> Create(ISender sender, CreateMusicCommand command)
    {
        return await sender.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<IResult> Update(ISender sender, int id, UpdateMusicCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    [HttpPut("UpdateDetail/{id}")]
    public async Task<IResult> UpdateDetail(ISender sender, int id, UpdateMusicDetailCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IResult> Delete(ISender sender, int id)
    {
        await sender.Send(new DeleteMusicCommand(id));
        return Results.NoContent();
    }
}
