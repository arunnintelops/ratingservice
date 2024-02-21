using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.RatingService;
using Core.Entities;
using Core.Repositories;

namespace Application.Handlers.RatingService
{
    public class CreateRatingCommandHandler : IRequestHandler<CreateRatingCommand, int>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateRatingCommandHandler> _logger;

        public CreateRatingCommandHandler(IRatingRepository ratingRepository, IMapper mapper, ILogger<CreateRatingCommandHandler> logger)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateRatingCommand request, CancellationToken cancellationToken)
        {
            var ratingEntity = _mapper.Map<Rating>(request);

            /*****************************************************************************/
            var generatedRating = await _ratingRepository.AddAsync(ratingEntity);
            /*****************************************************************************/
            _logger.LogInformation($" {generatedRating} successfully created.");
            return generatedRating.Id;
        }
    }
}
