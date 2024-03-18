using AutoMapper;
using Kanban.Api.Entities;
using Kanban.Api.Helpers;
using Kanban.Api.Models;
using Kanban.Api.Services;
using Kanban.Api.Test.Helpers;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;

namespace Kanban.Api.Test.Services
{
    public class CandidateServiceTests
    {
        [Fact]
        public async void CreateCandidate_ShouldReturnError_EmailIsAlreadyExist()
        {
            // Arrange
            var testData = new List<Candidate>
            {
                new Candidate
                {
                    FirstName = "abc",
                    LastName = "abc",
                    PhoneNumber = "1234567890",
                    Email = "abc@abc.com"
                }
            }.BuildMock().BuildMockDbSet();

            var mockUOW = TestUnitOfWorkHelper.CreateMockUOW(testData, new Mock<DbSet<Status>>(), new Mock<DbSet<Job>>());
            var mockMapper = new Mock<IMapper>();

            // Act
            var service = new CandidateService(mockMapper.Object, mockUOW);
            var exception = await Assert.ThrowsAsync<AppException>(() => service.Create(new CandidateRequestDto { Email = "abc@abc.com" }));

            // Assert
            Assert.Equal("Email is already exist! Please choice other email", exception.Message);
        }

        [Fact]
        public async void CreateCandidate_ShouldReturnError_PhoneNumberIsAlreadyExist()
        {
            // Arrange
            var testData = new List<Candidate>
            {
                new Candidate
                {
                    FirstName = "abc",
                    LastName = "abc",
                    PhoneNumber = "1234567890",
                    Email = "abc@abc.com"
                }
            }.BuildMock().BuildMockDbSet();

            var mockUOW = TestUnitOfWorkHelper.CreateMockUOW(testData, new Mock<DbSet<Status>>(), new Mock<DbSet<Job>>());
            var mockMapper = new Mock<IMapper>();

            // Act
            var service = new CandidateService(mockMapper.Object, mockUOW);
            var exception = await Assert.ThrowsAsync<AppException>(() => service.Create(new CandidateRequestDto { Email = "test@test.com", PhoneNumber = "1234567890" }));

            // Assert
            Assert.Equal("Phone number is already exist! Please choice other phone number", exception.Message);
        }

        [Fact]
        public async void UpdateCandidate_ShouldReturnError_NotFoundCandidate()
        {
            // Arrange
            var testData = new List<Candidate>
            {
                new Candidate
                {
                    Id = 1,
                    FirstName = "abc",
                    LastName = "abc",
                    PhoneNumber = "1234567890",
                    Email = "abc@abc.com"
                },
                new Candidate
                {
                    Id = 2,
                    FirstName = "xyz",
                    LastName = "xyz",
                    PhoneNumber = "92189301293",
                    Email = "xyz@xyz.com"
                }
            }.BuildMock().BuildMockDbSet();

            var mockUOW = TestUnitOfWorkHelper.CreateMockUOW(testData, new Mock<DbSet<Status>>(), new Mock<DbSet<Job>>());
            var mockMapper = new Mock<IMapper>();

            // Act
            var service = new CandidateService(mockMapper.Object, mockUOW);
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => service.Update(100, new CandidateRequestDto { Email = "xyz@xyz.com" }));

            // Assert
            Assert.Equal("Candidate not found", exception.Message);
        }

        [Fact]
        public async void UpdateCandidate_ShouldReturnError_EmailIsAlreadyExist()
        {
            // Arrange
            var testData = new List<Candidate>
            {
                new Candidate
                {
                    Id = 1,
                    FirstName = "abc",
                    LastName = "abc",
                    PhoneNumber = "1234567890",
                    Email = "abc@abc.com"
                },
                new Candidate
                {
                    Id = 2,
                    FirstName = "xyz",
                    LastName = "xyz",
                    PhoneNumber = "92189301293",
                    Email = "xyz@xyz.com"
                }
            }.BuildMock().BuildMockDbSet();

            var mockUOW = TestUnitOfWorkHelper.CreateMockUOW(testData, new Mock<DbSet<Status>>(), new Mock<DbSet<Job>>());
            var mockMapper = new Mock<IMapper>();

            // Act
            var service = new CandidateService(mockMapper.Object, mockUOW);
            var exception = await Assert.ThrowsAsync<AppException>(() => service.Update(1, new CandidateRequestDto { Email = "xyz@xyz.com" }));

            // Assert
            Assert.Equal("Email is already exist! Please choice other email", exception.Message);
        }

        [Fact]
        public async void UpdateCandidate_ShouldReturnError_PhoneNumberIsAlreadyExist()
        {
            // Arrange
            var testData = new List<Candidate>
            {
                new Candidate
                {
                    Id = 1,
                    FirstName = "abc",
                    LastName = "abc",
                    PhoneNumber = "1234567890",
                    Email = "abc@abc.com"
                },
                new Candidate
                {
                    Id = 2,
                    FirstName = "xyz",
                    LastName = "xyz",
                    PhoneNumber = "92189301293",
                    Email = "xyz@xyz.com"
                }
            }.BuildMock().BuildMockDbSet();

            var mockUOW = TestUnitOfWorkHelper.CreateMockUOW(testData, new Mock<DbSet<Status>>(), new Mock<DbSet<Job>>());
            var mockMapper = new Mock<IMapper>();

            // Act
            var service = new CandidateService(mockMapper.Object, mockUOW);
            var exception = await Assert.ThrowsAsync<AppException>(() => service.Update(1, new CandidateRequestDto { Email = "test@test.com", PhoneNumber = "92189301293" }));

            // Assert
            Assert.Equal("Phone number is already exist! Please choice other phone number", exception.Message);
        }
    }
}