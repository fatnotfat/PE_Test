using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;

namespace Test_PE.Pages.SilverJewelryPage
{
    public class DeleteModel : PageModel
    {
        private readonly BusinessObject.SilverJewelry2024DbContext _context;

        public DeleteModel(BusinessObject.SilverJewelry2024DbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public SilverJewelry SilverJewelry { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.SilverJewelries == null)
            {
                return NotFound();
            }

            var silverjewelry = await _context.SilverJewelries.FirstOrDefaultAsync(m => m.SilverJewelryId == id);

            if (silverjewelry == null)
            {
                return NotFound();
            }
            else 
            {
                SilverJewelry = silverjewelry;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.SilverJewelries == null)
            {
                return NotFound();
            }
            var silverjewelry = await _context.SilverJewelries.FindAsync(id);

            if (silverjewelry != null)
            {
                SilverJewelry = silverjewelry;
                _context.SilverJewelries.Remove(SilverJewelry);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
