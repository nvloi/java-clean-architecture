using AutoMapper;
using MusicManagement.Domain.Entities;

namespace MusicManagement.Application.Musics.Queries.GetMusicsWithPagination;

public class MusicBriefDto
{
    public int Id { get; init; }

    public int ListId { get; init; }

    public string? Title { get; init; }

    public bool Done { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Music, MusicBriefDto>();
        }
    }
}
