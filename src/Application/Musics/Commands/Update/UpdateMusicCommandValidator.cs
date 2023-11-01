namespace MusicManagement.Application.Musics.Commands.Update;

public class UpdateMusicCommandValidator : AbstractValidator<UpdateMusicCommand>
{
    public UpdateMusicCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}
