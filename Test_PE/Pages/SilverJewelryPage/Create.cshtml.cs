using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using Repository.Interface;
using NuGet.Common;
using Newtonsoft.Json;

namespace Test_PE.Pages.SilverJewelryPage
{
    public class CreateModel : PageModel
    {
        private readonly IHelper _helper;

        public CreateModel(IHelper helper)
        {
            _helper = helper;
        }

        public async Task<IActionResult> OnGetAsync(string token)
        {
            Token = token;
            string baseUrl2 = "https://localhost:7046/api/categories";
            var responseString1 = await _helper.GetAPI(baseUrl2, token);
            var categories = JsonConvert.DeserializeObject<List<Category>>(responseString1)!;

            ViewData["CategoryId"] = new SelectList(categories, "CategoryId", "CategoryName");
            return Page();
        }


        [BindProperty]
        public SilverJewelry SilverJewelry { get; set; } = default!;
        public IList<SilverJewelry> SilverJewelrys { get; set; } = default!;
        public string? Token { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string token)
        {
            Token = token;
            string baseUrl = "https://localhost:7046/api/silverjewelries";
            var responseString = await _helper.GetAPI(baseUrl, token);


            SilverJewelrys = JsonConvert.DeserializeObject<List<SilverJewelry>>(responseString)!;
            if (!ModelState.IsValid || SilverJewelrys == null || SilverJewelry == null)
            {
                return Page();
            }
            SilverJewelry.CreatedDate = DateTime.Now;
            var responseString2 = await _helper.PostAPI(baseUrl, token, SilverJewelry);
            return RedirectToPage("./Index", new { Token = token });
        }
    }
}
