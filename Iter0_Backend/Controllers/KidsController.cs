using Iter0_Backend.Models;
using Iter0_Backend.Services;
using Microsoft.AspNetCore.Identity;
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
        [HttpPost]
        public async Task<ActionResult<KidModel>> CreateKidAsync([FromBody] KidModel kid)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var newKid = await _kidService.CreateKidAsync(kid);
                return Created($"/api/kids/{newKid.Id}", newKid);
            }
            //catch (NotFoundElementException ex)
            //{
            //    return NotFound(ex.Message);
            //}
            //catch (InvalidDateTimeException ex)
            //{
            //    return Conflict(ex.Message);
            //}
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something happened.");
            }
        }
    }
}
