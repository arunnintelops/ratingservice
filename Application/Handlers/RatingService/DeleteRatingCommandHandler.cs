using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.RatingService;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;

namespace Application.Handlers.RatingService
{
    public class DeleteRatingCommandHandler : IRequestHandler<DeleteRatingCommand>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly ILogger<DeleteRatingCommandHandler> _logger;

        public DeleteRatingCommandHandler(IRatingRepository ratingRepository, ILogger<DeleteRatingCommandHandler> logger)
        {
            _ratingRepository = ratingRepository;
            _logger = logger;
        }
        public async Task Handle(DeleteRatingCommand request, CancellationToken cancellationToken)
        {
            var ratingToDelete = await _ratingRepository.GetByIdAsync(request.Id);
            if (ratingToDelete == null)
            {
                throw new RatingNotFoundException(nameof(Rating), request.Id);
            }

            await _ratingRepository.DeleteAsync(ratingToDelete);
            _logger.LogInformation($" Id {request.Id} is deleted successfully.");
        }
    }
}
