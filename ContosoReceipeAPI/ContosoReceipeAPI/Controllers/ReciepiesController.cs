using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContosoReceipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReciepiesController : ControllerBase
    {
        [HttpGet] //It's gonna response with http request.
        //public string[] GetDishes()
        //{
        //    string[] dishes = { "Oxtail", "Chicken", "Tacoshack" };
        //    return dishes;
        //}
        public ActionResult GetRecipes()
        {
            string[] dishes = { "Oxtail", "Chicken", "Tacoshack" };
            if (dishes.Any())
            {
                return NotFound();
            }
            else
            {
                return Ok(dishes);
            }

        }
        public ActionResult CreateNewRecipes()
        {

        }
        public ActionResult DeleteRecipes()
        {
            bool badThingsHappened = false;
            if (badThingsHappened)
            {
                return BadRequest();
            }
            else
            {
                return NoContent();
            }
        }
    }
}
