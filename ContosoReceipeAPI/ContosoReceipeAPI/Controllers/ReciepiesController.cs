using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContosoReceipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReciepiesController : ControllerBase
    {
        [HttpGet] //It's gonna response with http request.
        public string[] GetDishes()
        {
            string[] dishes = { "Oxtail", "Chicken", "Tacoshack" };
            return dishes;
        }
    }
}
