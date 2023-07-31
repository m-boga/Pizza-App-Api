using System.Collections.Generic;

namespace PizzaApp.Models
{
    public interface IRestaurantBranchRepository
    {
        List<RestaurantBranch> GetNearestBranches(double latitude, double longitude);
    }
}
