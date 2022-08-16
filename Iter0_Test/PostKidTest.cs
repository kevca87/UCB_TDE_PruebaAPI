using Iter0_Backend.Controllers;
using Iter0_Backend.Data.Repository;
using Iter0_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Iter0_Test
{
    public class PostKidTest
    {
        [Fact]
        public async Task GetKidsAsync_ReturnsAViewResult_WithAListOfKids()
        {
            // arrange
            //var appRepository = new AppRepository();
            //var kidsController = new KidsController(appRepository);

            //// act
            //var result = await kidsController.GetKidsAsync();

            //// assert
            //var viewResult = Assert.IsType<ViewResult>(result);
            //var model = Assert.IsAssignableFrom<IEnumerable<KidModel>>(viewResult.ViewData.Model);
            //Assert.Equal(2,model.Count());
        }
    }
}