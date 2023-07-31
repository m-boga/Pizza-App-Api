using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models;

namespace PizzaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantBranchesController : ControllerBase
    {
        private readonly IRestaurantBranchRepository _restaurantBranchRepository;

        public RestaurantBranchesController(IRestaurantBranchRepository restaurantBranchRepository)
        {
            _restaurantBranchRepository = restaurantBranchRepository;
        }

        [HttpGet]
        public ActionResult<List<RestaurantBranch>> GetNearestBranches([FromQuery] double latitude, [FromQuery] double longitude)
        {
            var nearestBranches = _restaurantBranchRepository.GetNearestBranches(latitude, longitude);
            return Ok(nearestBranches);
        }
    }
}
