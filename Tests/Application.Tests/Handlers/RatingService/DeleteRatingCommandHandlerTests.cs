using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.RatingService;
using Application.Exceptions;
using Application.Handlers.RatingService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.RatingService
{
    public class DeleteRatingCommandHandlerTests
    {
        private readonly Mock<IRatingRepository> _ratingRepository;
        private readonly Mock<ILogger<DeleteRatingCommandHandler>> _logger;

        public DeleteRatingCommandHandlerTests()
        {
            _ratingRepository = new();
            _logger = new();
        }

        [Fact]
        public async Task Handle_ThrowsRatingNotFoundExceptionWhenRatingNotFound()
        {
            // Arrange
            var Id = 123; // Replace with the ID you want to test
            var request = new DeleteRatingCommand { Id = Id }; // Create a request object

            _ratingRepository
                .Setup(r => r.GetByIdAsync(Id))
                .ReturnsAsync((Rating)null); // Mock the repository to return null

            var handler = new DeleteRatingCommandHandler(_ratingRepository.Object, _logger.Object);

            // Act and Assert
            await Assert.ThrowsAsync<RatingNotFoundException>(
                async () => await handler.Handle(request, CancellationToken.None)
            );
        }
    }
}
