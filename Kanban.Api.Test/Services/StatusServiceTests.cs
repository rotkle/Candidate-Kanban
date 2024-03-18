using AutoMapper;
using Kanban.Api.Entities;
using Kanban.Api.Helpers;
using Kanban.Api.Services;
using Kanban.Api.Test.Helpers;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;

namespace Kanban.Api.Test.Services
{
    public class StatusServiceTests
    {
        [Fact]
        public async void GetAllStatus_ShouldReturnEmpty_NoStatusData()
        {
            // Arrange
            var testData = new List<Status>().BuildMock().BuildMockDbSet();

            var mockUOW = TestUnitOfWorkHelper.CreateMockUOW(new Mock<DbSet<Candidate>>(), testData, new Mock<DbSet<Job>>());

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            var mapper = mockMapper.CreateMapper();

            // Act
            var service = new StatusService(mapper, mockUOW);
            var result = await service.GetAllStatus();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async void GetAllStatus_ShouldReturnAllStatus()
        {
            // Arrange
            var testData = new List<Status>
            {
                new Status
                {
                    Id = 1,
                    Name = "Test",
                }
            }.BuildMock().BuildMockDbSet();

            var mockUOW = TestUnitOfWorkHelper.CreateMockUOW(new Mock<DbSet<Candidate>>(), testData, new Mock<DbSet<Job>>());

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            var mapper = mockMapper.CreateMapper();

            // Act
            var service = new StatusService(mapper, mockUOW);
            var result = await service.GetAllStatus();

            // Assert
            Assert.Single(result);
            Assert.Equal("Test", result.First().Name);
        }
    }
}
