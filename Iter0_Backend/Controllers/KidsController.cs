using Iter0_Backend.Models;
using Iter0_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Iter0_Backend.Controllers
{
    [Route("api/[controller]")]
    public class KidsController : Controller
    {
        IKidService _kidService;
        public KidsController(IKidService kidService)
        {
            _kidService = kidService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KidModel>>> GetKidsAsync()
        {
            ActionResult<IEnumerable<KidModel>> response;
            try
            {
                var kids = await _kidService.GetKidsAsync();
                response = Ok(kids);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return response;
        }
    }
}
