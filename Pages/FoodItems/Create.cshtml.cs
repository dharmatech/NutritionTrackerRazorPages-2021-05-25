using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NutritionTrackerRazorPages.Data;
using NutritionTrackerRazorPages.Models;

namespace NutritionTrackerRazorPages.Pages.FoodItems
{
    public class CreateModel : PageModel
    {
        private readonly NutritionTrackerRazorPages.Data.NutritionTrackerContext _context;

        public CreateModel(NutritionTrackerRazorPages.Data.NutritionTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FoodItem FoodItem { get; set; }

        public SelectList FoodCategorySelectList { get; set; }

        public IActionResult OnGet()
        {
            FoodCategorySelectList = new SelectList(
                _context.FoodCategory.OrderBy(food_category => food_category.Name).AsNoTracking(),
                nameof(FoodCategory.Id),
                nameof(FoodCategory.Name));

            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FoodItem.Add(FoodItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
