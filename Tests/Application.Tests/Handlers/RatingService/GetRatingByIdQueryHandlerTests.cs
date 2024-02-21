using AutoMapper;
using Moq;
using Application.Handlers.RatingService;
using Application.Queries.RatingService;
using Application.Responses;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.RatingService
{
    public class GetRatingByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsRatingResponse()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Rating, RatingResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var Id = 1; 
            var obj = new Rating { Id = Id, /* other properties */ };

            var RepositoryMock = new Mock<IRatingRepository>();
            RepositoryMock.Setup(repo => repo.GetByIdAsync(Id)).ReturnsAsync(obj);

            var query = new GetRatingByIdQuery(Id);
            var handler = new GetRatingByIdQueryHandler(RepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<RatingResponse>(result);
            // Add assertions to check the mapping and properties 
            Assert.Equal(Id, result.Id);
            // Add more assertions as needed
        }
    }
}
