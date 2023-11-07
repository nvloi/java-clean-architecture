using AutoMapper;
using MusicManagement.Domain.Entities;

namespace MusicManagement.Application.Common.Models;

public class LookupDto
{
    public int Id { get; init; }

    public string? Title { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Music, LookupDto>();
            CreateMap<Album, LookupDto>();
        }
    }
}
