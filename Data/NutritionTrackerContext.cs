using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NutritionTrackerRazorPages.Models;

namespace NutritionTrackerRazorPages.Data
{
    public class NutritionTrackerContext : DbContext
    {
        public NutritionTrackerContext (DbContextOptions<NutritionTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<NutritionTrackerRazorPages.Models.FoodCategory> FoodCategory { get; set; }

        public DbSet<NutritionTrackerRazorPages.Models.FoodItem> FoodItem { get; set; }
    }
}
