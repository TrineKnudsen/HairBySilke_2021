using EntityFrameworkCore.Testing.Moq;
using HBS.HairBySilke_2021.Core.Models;
using HBS.HairBySilke_2021.DataAccess.Entities;
using HBS.HairBySilke_2021.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace HBS.HairBySilke_2021.DataAccess.Test
{
    public class MainDbContextTest
    {
        [Fact]
        public void DbContext_WithDbContextOptions_IsAvailable()
        {
            var mockDbContext = Create.MockedDbContextFor<MainDbContext>();
            Assert.NotNull(mockDbContext);
        }
        
        [Fact]
        public void DbContext_DbSets_MustHaveDbSetWithTypeTreatmentEntity()
        {
            var mockedObject = Create.MockedDbContextFor<MainDbContext>();
            Assert.True(mockedObject.Treatments is DbSet<TreatmentEntity>);
        }
    }
}