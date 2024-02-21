using AutoMapper;
using Moq;
using Application.Handlers.RatingService;
using Application.Queries.RatingService;
using Application.Responses;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.RatingService
{
    public class GetAllRatingsQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsListOfRatingResponses()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Rating, RatingResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var obj = new List<Rating> 
        {
            new Rating { Id = 1 },
            new Rating { Id = 2 }

        };

            var RepositoryMock = new Mock<IRatingRepository>();
            RepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(obj);

            var query = new GetAllRatingsQuery();
            var handler = new GetAllRatingsQueryHandler(RepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<RatingResponse>>(result);
            Assert.Equal(obj.Count, result.Count);
           
        }
    }
}
