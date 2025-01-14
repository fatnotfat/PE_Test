﻿using BusinessObject.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using Test_PE.Pages.SessionHelpers;

namespace Test_PE.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string? ErrorMessage { get; set; } = default!;
        public string? Token { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            using (var httpClient = new HttpClient())
            {
                AccountLoginDTO account = new AccountLoginDTO()
                {
                    Email = Email,
                    Password = Password,
                };
                var json = JsonConvert.SerializeObject(account);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                using (HttpResponseMessage response = await httpClient.PostAsync("https://localhost:7046/api/accounts/login", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode)
                    {
                        ModelState.AddModelError(nameof(ErrorMessage), "Login fail! Wrong email or password!");
                        ErrorMessage = "Login fail! Wrong email or password!";
                        return Page();
                    }
                    else
                    {
                        Token = apiResponse;
                        SessionHelper.SetObjectAsJson(HttpContext.Session, "token", Token);
                        return RedirectToPage("/SilverJewelryPage/Index", new { Token = apiResponse });
                    }
                }
            }
        }
    }
}
