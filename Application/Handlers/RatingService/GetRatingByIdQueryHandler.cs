using AutoMapper;
using MediatR;
using Application.Queries.RatingService;
using Application.Responses;
using Core.Repositories;

namespace Application.Handlers.RatingService
{
    public class GetRatingByIdQueryHandler : IRequestHandler<GetRatingByIdQuery, RatingResponse>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;
        public GetRatingByIdQueryHandler(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }
        public async Task<RatingResponse> Handle(GetRatingByIdQuery request, CancellationToken cancellationToken)
        {
            var generatedRating = await _ratingRepository.GetByIdAsync(request.id);
            var ratingEntity = _mapper.Map<RatingResponse>(generatedRating);
            return ratingEntity;
        }
    }
}
