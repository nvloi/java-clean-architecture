using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicManagement.Domain.Entities;

namespace MusicManagement.Persistance.Data.Seeds;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    private async Task TrySeedAsync()
    {

        // Default data
        // Seed, if necessary
        if (!_context.Albums.Any())
        {
            _context.Albums.Add(new Album
            {
                Title = "Todo List",
                Musics =
                {
                    new Music { Title = "Make a todo list" },
                    new Music { Title = "Check off the first item" },
                    new Music { Title = "Realise you've already done two things on the list!"},
                    new Music { Title = "Reward yourself with a nice, long nap" },
                }
            });

            await _context.SaveChangesAsync();
        }
    }
}
