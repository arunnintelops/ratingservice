using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.RatingService;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;


namespace Application.Handlers.RatingService
{
    public class UpdateRatingCommandHandler : IRequestHandler<UpdateRatingCommand>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateRatingCommandHandler> _logger;

        public UpdateRatingCommandHandler(IRatingRepository ratingRepository, IMapper mapper, ILogger<UpdateRatingCommandHandler> logger)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(UpdateRatingCommand request, CancellationToken cancellationToken)
        {
            var ratingToUpdate = await _ratingRepository.GetByIdAsync(request.Id);
            if (ratingToUpdate == null)
            {
                throw new RatingNotFoundException(nameof(Rating), request.Id);
            }

            _mapper.Map(request, ratingToUpdate, typeof(UpdateRatingCommand), typeof(Rating));
            await _ratingRepository.UpdateAsync(ratingToUpdate);
            _logger.LogInformation($"Rating is successfully updated");
        }
    }
}
