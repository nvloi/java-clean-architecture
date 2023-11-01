namespace MusicManagement.Application.Musics.Commands.Create;

public class CreateMusicCommandValidator : AbstractValidator<CreateMusicCommand>
{
    public CreateMusicCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}
