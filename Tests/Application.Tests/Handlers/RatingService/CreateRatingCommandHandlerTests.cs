using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.RatingService;
using Application.Handlers.RatingService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.RatingService
{
    public class CreateRatingCommandHandlerTests
    {
        private readonly Mock<IRatingRepository> _ratingRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ILogger<CreateRatingCommandHandler>> _logger;

        public CreateRatingCommandHandlerTests()
        {
            _ratingRepository = new();
            _mapper = new();
            _logger = new();
        }

        [Fact]
        public async Task Handle_ReturnsId()
        {
            // Arrange
            var request = new CreateRatingCommand(); // Create a request object as needed

            _mapper
                .Setup(m => m.Map<Rating>(request))
                .Returns(new Rating()); 

            _ratingRepository
                .Setup(r => r.AddAsync(It.IsAny<Rating>()))
                .ReturnsAsync(new Rating { Id = 123 }); 

            var loggerMock = new Mock<ILogger<CreateRatingCommandHandler>>();
            var handler = new CreateRatingCommandHandler(_ratingRepository.Object, _mapper.Object, loggerMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(123, result); 
        }
    }
}
