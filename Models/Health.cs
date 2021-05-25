using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTrackerRazorPages.Models
{
    public class HealthRecord
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        public int FoodItemId { get; set; }

        public FoodItem FoodItem { get; set; } // navigation

        public decimal Amount { get; set; }

        public decimal Calories => FoodItem.Calories * Amount;
    }
}
