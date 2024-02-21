using AutoMapper;
using MediatR;
using Application.Queries.RatingService;
using Application.Responses;
using Core.Repositories;

namespace Application.Handlers.RatingService
{
    public class GetAllRatingsQueryHandler : IRequestHandler<GetAllRatingsQuery, List<RatingResponse>>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;
        public GetAllRatingsQueryHandler(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }
        public async Task<List<RatingResponse>> Handle(GetAllRatingsQuery request, CancellationToken cancellationToken)
        {
            var generatedRating = await _ratingRepository.GetAllAsync();
            var ratingEntity = _mapper.Map<List<RatingResponse>>(generatedRating);
            return ratingEntity;
        }
    }
}
