using Iter0_Backend.Controllers;
using Iter0_Backend.Models;
using Iter0_Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iter0_Test.UnitTests.Controllers
{
    public class KidsControllerTests
    {
        [Fact]
        public async void GetKidsAsync_TwoKidsAdded_ReturnsListWith2Kids()
        {
            // ARRANGE
            var martina = new KidModel()
            {
                Id = 1,
                Name = "Martina",
                BirthDate = new DateTime(2007, 3, 5)
            };
            var tatiana = new KidModel()
            {
                Id = 2,
                Name = "Tatiana",
                BirthDate = new DateTime(2007, 3, 5)
            };
            var enumerable = new List<KidModel>() { martina, tatiana } as IEnumerable<KidModel>;

            var serviceMock = new Mock<IKidService>();
            serviceMock.Setup(r => r.GetKidsAsync()).ReturnsAsync(enumerable);
            var kidContoller = new KidsController(serviceMock.Object);

            // ACT 
            var response = await kidContoller.GetKidsAsync();
            var status = (OkObjectResult)response.Result;
            var kidList = status.Value as List<KidModel>;
            var countKidsList = kidList.Count();

            // ASSERT
            Assert.Equal(2, countKidsList);
            Assert.Equal(200, status.StatusCode);
        }

    }
}
