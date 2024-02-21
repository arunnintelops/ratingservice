using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.RatingService;
using Application.Exceptions;
using Application.Handlers.RatingService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.RatingService
{
    public class UpdateRatingCommandHandlerTests
    {
        private readonly Mock<IRatingRepository> _ratingRepository;
        private readonly Mock<ILogger<UpdateRatingCommandHandler>> _logger;
        private readonly Mock<IMapper> _mapper;

        public UpdateRatingCommandHandlerTests()
        {
            _ratingRepository = new();
            _logger = new();
            _mapper = new();
        }

        [Fact]
        public async Task Handle_ThrowsRatingNotFoundExceptionWhenRatingNotFound()
        {
            // Arrange
            var Id = 123; // Replace with the ID you want to test
            var request = new UpdateRatingCommand { Id = Id }; // Create a request object

            _ratingRepository
               .Setup(r => r.GetByIdAsync(Id))
                .ReturnsAsync((Rating)null); // Mock the repository to return null

            var handler = new UpdateRatingCommandHandler(_ratingRepository.Object, _mapper.Object, _logger.Object);

            // Act and Assert
            await Assert.ThrowsAsync<RatingNotFoundException>(
                async () => await handler.Handle(request, CancellationToken.None)
            );
        }
    }
}
