using FluentValidation;

namespace MusicManagement.Application.Musics.Queries.GetMusicsWithPagination;

public class GetMusicsWithPaginationQueryValidator : AbstractValidator<GetMusicsWithPaginationQuery>
{
    public GetMusicsWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}
