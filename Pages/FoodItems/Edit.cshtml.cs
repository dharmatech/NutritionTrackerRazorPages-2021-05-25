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
    public class EditModel : PageModel
    {
        private readonly NutritionTrackerRazorPages.Data.NutritionTrackerContext _context;

        public EditModel(NutritionTrackerRazorPages.Data.NutritionTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FoodItem FoodItem { get; set; }

        public SelectList FoodCategorySelectList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            FoodCategorySelectList = new SelectList(
                _context.FoodCategory.OrderBy(food_category => food_category.Name).AsNoTracking(),
                nameof(FoodCategory.Id),
                nameof(FoodCategory.Name));

            if (id == null)
            {
                return NotFound();
            }

            FoodItem = await _context.FoodItem
                .Include(f => f.FoodCategory).FirstOrDefaultAsync(m => m.Id == id);

            if (FoodItem == null)
            {
                return NotFound();
            }
           ViewData["FoodCategoryId"] = new SelectList(_context.FoodCategory, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FoodItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodItemExists(FoodItem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FoodItemExists(int id)
        {
            return _context.FoodItem.Any(e => e.Id == id);
        }
    }
}
