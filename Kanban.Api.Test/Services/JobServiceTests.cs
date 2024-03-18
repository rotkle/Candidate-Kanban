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
    public class JobServiceTests
    {
        [Fact]
        public async void GetAllJobs_ShouldReturnEmpty_NoJobsData()
        {
            // Arrange
            var testData = new List<Job>().BuildMock().BuildMockDbSet();

            var mockUOW = TestUnitOfWorkHelper.CreateMockUOW(new Mock<DbSet<Candidate>>(), new Mock<DbSet<Status>>(), testData);

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            var mapper = mockMapper.CreateMapper();

            // Act
            var service = new JobService(mapper, mockUOW);
            var result = await service.GetAllJobs();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async void GetAllJobs_ShouldReturnAllJobs()
        {
            // Arrange
            var testData = new List<Job>
            {
                new Job
                {
                    Id = 1,
                    Name = "Test",
                }
            }.BuildMock().BuildMockDbSet();

            var mockUOW = TestUnitOfWorkHelper.CreateMockUOW(new Mock<DbSet<Candidate>>(), new Mock<DbSet<Status>>(), testData);

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            var mapper = mockMapper.CreateMapper();

            // Act
            var service = new JobService(mapper, mockUOW);
            var result = await service.GetAllJobs();

            // Assert
            Assert.Single(result);
            Assert.Equal("Test", result.First().Name);
        }
    }
}
