using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Repository.Interface;
using Newtonsoft.Json;

namespace Test_PE.Pages.SilverJewelryPage
{
    public class IndexModel : PageModel
    {
        private readonly IHelper _helper;
        private readonly IConfiguration _configuration;

        public IndexModel(IHelper helper, IConfiguration configuration)
        {
            _helper = helper;
            _configuration = configuration;
        }

        public IList<SilverJewelry> SilverJewelry { get;set; } = default!;
        public string? Token { get; set; }
        public string CurrentFilter { get; set; }


        public async Task OnGetAsync(string token, string currentFilter, string searchString)
        {

            if (currentFilter != null)
            {
                searchString = currentFilter;
            }
            CurrentFilter = searchString;

            Token = token;
            string baseUrl = "https://localhost:7046/api/silverjewelries";
            var responseString = await _helper.GetAPI(baseUrl, token);

            List<SilverJewelry> silverJewelry = JsonConvert.DeserializeObject<List<SilverJewelry>>(responseString)!;
            SilverJewelry = silverJewelry;
            if(!String.IsNullOrEmpty(responseString))
            {
                if (silverJewelry == null)
                {
                    silverJewelry = new List<SilverJewelry>();
                }
                IQueryable<SilverJewelry> silverJewelriesIQ = silverJewelry.AsQueryable();



                if (!String.IsNullOrEmpty(searchString))
                {
                    silverJewelriesIQ = silverJewelriesIQ.Where(s => s.SilverJewelryName!.ToUpper().Contains(searchString.Trim().ToUpper()));
                }

                SilverJewelry = silverJewelriesIQ.ToList();
            }
        }
    }
}
