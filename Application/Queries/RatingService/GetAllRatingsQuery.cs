using MediatR;
using Application.Responses;

namespace Application.Queries.RatingService
{
    public class GetAllRatingsQuery : IRequest<List<RatingResponse>>
    {

    }
}
