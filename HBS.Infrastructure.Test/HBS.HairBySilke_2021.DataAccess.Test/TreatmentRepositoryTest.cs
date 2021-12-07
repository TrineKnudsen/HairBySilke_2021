using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EntityFrameworkCore.Testing.Moq;
using HBS.Domain.IRepositories;
using HBS.HairBySilke_2021.Core.Models;
using HBS.HairBySilke_2021.DataAccess.Entities;
using HBS.HairBySilke_2021.DataAccess.Repositories;
using Itenso.TimePeriod;
using Xunit;

namespace HBS.HairBySilke_2021.DataAccess.Test
{
    public class TreatmentRepositoryTest
    {
        [Fact]
        public void TreatmentRepository_IsTreatmentRepository()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new TreatmentRepository(fakeContext);
            Assert.IsAssignableFrom<ITreatmentsRepository>(repository);
        }

        [Fact]
        public void TreatmentRepository_WithNullDbContext_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new TreatmentRepository(null));
        }
        
        [Fact]
        public void TreatmentRepository_WithNullDbContext_ThrowsExceptionWithMessage()
        {
            var exception = Assert
                .Throws<InvalidDataException>(() => new TreatmentRepository(null));
            Assert.Equal("Treatment repository must have a DbContext", exception.Message);
        }

        [Fact]
        public void FindAll_GetAllTreatmentEntitiesInDbContext_AsListOfTreatments()
        {
            //Arrange
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new TreatmentRepository(fakeContext);
            var list = new List<TreatmentEntity>
            {
                new TreatmentEntity {Duration = 120, Id = 1, Price = 500, TreatmentName = "Bundfarve"},
                new TreatmentEntity {Duration = 45, Id = 2, Price = 350, TreatmentName = "Dameklip"},
                new TreatmentEntity {Duration = 30, Id = 3, Price = 200, TreatmentName = "Herreklip"}
            };
            fakeContext.Set<TreatmentEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var expectedList = list.Select(te => new Treatment
            {
                Id = te.Id,
                TreatmentName = te.TreatmentName,
                Price = te.Price,
                Duration = te.Duration
            }).ToList();
            
            //Act
            var actualResult = repository.ReadAllTreatments();
            
            //Assert
            Assert.Equal(expectedList, actualResult, new Comparer());
        }
    }
    
    public class Comparer: IEqualityComparer<Treatment>
    {
        public bool Equals(Treatment x, Treatment y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Id == y.Id && x.TreatmentName == y.TreatmentName && x.Price == y.Price && x.Id == y.Id && x.Duration == y.Duration;
        }

        public int GetHashCode(Treatment obj)
        {
            return HashCode.Combine(obj.Id, obj.TreatmentName, obj.Price, obj.Id, obj.Duration);
        }
    }
}