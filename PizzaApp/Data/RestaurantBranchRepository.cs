using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaApp.Models;

namespace PizzaApp.Data
{
    public class RestaurantBranchRepository : IRestaurantBranchRepository
    {
        private readonly PizzaAppContext _context;
        private const double EARTH_RADIUS = 6371; // Yarıçap km cinsinden

        public RestaurantBranchRepository(PizzaAppContext context)
        {
            _context = context;
        }

        public List<RestaurantBranch> GetNearestBranches(double latitude, double longitude)
        {
            var branches = _context.RestaurantBranches.AsEnumerable();

            //  Haversine
            var nearestBranches = branches
                .Select(branch => new
                {
                    branch,
                    distance = CalculateDistance(latitude, longitude, branch.Latitude, branch.Longitude)
                })
                .Where(branchWithDistance => branchWithDistance.distance <= 10)
                .OrderBy(branchWithDistance => branchWithDistance.distance)
                .Take(5)
                .Select(branchWithDistance => branchWithDistance.branch)
                .ToList();

            return nearestBranches;
        }

        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            double dLat = ToRadians(lat2 - lat1);
            double dLon = ToRadians(lon2 - lon1);

            lat1 = ToRadians(lat1);
            lat2 = ToRadians(lat2);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return EARTH_RADIUS * c;
        }

        private double ToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}
