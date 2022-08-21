using AutoMapper;
using Iter0_Backend.Data;
using Iter0_Backend.Data.Entities;
using Iter0_Backend.Data.Repository;
using Iter0_Backend.Models;
using Iter0_Backend.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Iter0_Test.UnitTests.Services
{
    public class KidServiceTests : BaseTest
    {
        [Fact]
        public async void GetKids_TwoKidsAdded_ReturnsListWith2Kids()
        {
            // ARRANGE
            var martina = new KidEntity()
            {
                Id = 1,
                Name = "Martina",
                BirthDate = new DateTime(2007, 3, 5)
            };
            var tatiana = new KidEntity()
            {
                Id = 2,
                Name = "Tatiana",
                BirthDate = new DateTime(2007, 3, 5)
            };
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>());
            var mapper = config.CreateMapper();
            var enumerable = new List<KidEntity>() { martina, tatiana } as IEnumerable<KidEntity>;
            var repositoryMock = new Mock<IAppRepository>();
            repositoryMock.Setup(r => r.GetKidsAsync()).ReturnsAsync(enumerable);
            var kidService = new KidService(repositoryMock.Object, mapper);

            // ACT 
            var listKids = await kidService.GetKidsAsync();
            var lastKidId = listKids.Last().Id;

            // ASSERT
            Assert.Equal(2, lastKidId);
        }

        [Fact]
        public async void CreateKid_KidAdded_AddsKid()
        {
            // ARRANGE
            var tatianaEntity = new KidEntity()
            {
                Id = 1,
                Name = "Tatiana",
                BirthDate = new DateTime(2007, 3, 5)
            };
            var tatianaModel = new KidModel()
            {
                Name = "Tatiana",
                BirthDate = new DateTime(2007, 3, 5)
            };
            
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>());
            var mapper = config.CreateMapper();

            var repositoryMock = new Mock<IAppRepository>();
            repositoryMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(true);
            repositoryMock.Setup(r => r.CreateKid(It.IsAny<KidEntity>())).Returns(tatianaEntity);
            //https://stackoverflow.com/a/53649215/18366207
            //To understant It.IsAny (min 8 parece) https://docs.microsoft.com/en-us/shows/visual-studio-toolbox/unit-testing-moq-framework

            //Could be util:
            //https://stackoverflow.com/questions/996602/returning-value-that-was-passed-into-a-method
            //https://stackoverflow.com/questions/36345282/mock-a-method-for-test

            //https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test

            //Debugging in UnitTest
            //https://docs.microsoft.com/en-us/visualstudio/test/debug-unit-tests-with-test-explorer?view=vs-2022

            //Expression<Func<IAppRepository,KidEntity>> call = r => r.CreateKid(tatianaEntity);
            //repositoryMock.Setup(call).Returns(tatianaEntity);
            //KidEntity CreateKid(KidEntity kid);
            //kidEntity = _repository.CreateKid(kidEntity);

            var kidService = new KidService(repositoryMock.Object, mapper);

            // ACT 
            var kidModelAdded = await kidService.CreateKidAsync(tatianaModel);
            var kidId = kidModelAdded.Id;
            //var kidName = kidModelAdded.Name;
            //var kidBirthDate = kidModelAdded.BirthDate;

            //// ASSERT
            ////Assert.Equal(1, KidId);
            //Assert.Equal(new DateTime(2007, 3, 5), kidBirthDate);
            //Assert.Equal("Tatiana", kidModelAdded.Name);
        }
    }
}
