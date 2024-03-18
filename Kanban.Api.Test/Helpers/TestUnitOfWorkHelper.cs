using Kanban.Api.Entities;
using Kanban.Api.Helpers;
using Kanban.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Kanban.Api.Test.Helpers
{
    public static class TestUnitOfWorkHelper
    {
        public static UnitOfWork CreateMockUOW(Mock<DbSet<Candidate>> candidateData,
                                    Mock<DbSet<Status>> statusData,
                                    Mock<DbSet<Job>> jobData)
        {
            var mockContext = new Mock<DataContext>();
            mockContext.Setup(x => x.Candidates).Returns(candidateData.Object);
            mockContext.Setup(x => x.Set<Candidate>()).Returns(candidateData.Object);
            mockContext.Setup(x => x.Status).Returns(statusData.Object);
            mockContext.Setup(x => x.Set<Status>()).Returns(statusData.Object);
            mockContext.Setup(x => x.Jobs).Returns(jobData.Object);
            mockContext.Setup(x => x.Set<Job>()).Returns(jobData.Object);

            var mockCandidateRepo = new CandidateRepository(mockContext.Object);
            var mockStatusRepo = new StatusRepository(mockContext.Object);
            var mockJobRepo = new JobRepository(mockContext.Object);

            return new UnitOfWork(mockContext.Object, mockCandidateRepo, mockStatusRepo, mockJobRepo);
        }
    }
}