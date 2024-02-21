using MediatR;

namespace Application.Commands.RatingService
{
    public class DeleteRatingCommand : IRequest
    {
        public int Id { get; set; }
    }
}
