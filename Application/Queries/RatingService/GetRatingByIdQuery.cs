using MediatR;
using Application.Responses;

namespace Application.Queries.RatingService
{
    public class GetRatingByIdQuery : IRequest<RatingResponse>
    {
        public int id { get; set; }

        public GetRatingByIdQuery(int _id)
        {
            id = _id;
        }
    }
}
