using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using app_example.DTOs.User;
using app_example.Models;
using Microsoft.AspNetCore.Identity;
using app_example.DTOs;

namespace app_example.Pages.User
{
    public class DashboardModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public List<TransactionResponse> Transactions { get; set; } = new();
        public TodaySummary Summary { get; set; } = new();
        public string Branch { get; set; } = "";

        [BindProperty]
        public TransactionCreateRequest Transaction { get; set; } = new();

        public DashboardModel(
            IHttpClientFactory httpClientFactory,
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task OnGetAsync()
        {
            // Get the signed-in user's Branch
            var user = await _userManager.GetUserAsync(User);
            Branch = user?.Branch ?? "No Branch";

            // Create HttpClient and forward auth cookie
            var client = _httpClientFactory.CreateClient();

            var cookie = _httpContextAccessor.HttpContext.Request.Headers["Cookie"].ToString();
            if (!string.IsNullOrEmpty(cookie))
            {
                client.DefaultRequestHeaders.Add("Cookie", cookie);
            }

            // Fetch the summary and transactions
            var apiUrl = "https://localhost:7254/api/user/transaction"; // Returns TodaySummary
            var summary = await client.GetFromJsonAsync<TodaySummary>(apiUrl);

            if (summary != null)
            {
                Summary = summary;

                if (Summary.Transactions == null)
                    Summary.Transactions = new List<TransactionResponse>();
            }
            else
            {
                Summary = new TodaySummary
                {
                    Date = DateTime.UtcNow,
                    TotalJumpers = 0,
                    TotalSales = 0,
                    Transactions = new List<TransactionResponse>()
                };
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Server-side validation: Discounted must not exceed NumberOfJumpers
            if (Transaction.Discounted > Transaction.NumberOfJumpers)
            {
                ModelState.AddModelError("Transaction.Discounted", "Discounted jumpers cannot exceed total tickets.");
            }

            if (!ModelState.IsValid)
            {
                // Force the modal to open again by setting a flag
                ViewData["ShowCreateModal"] = true;

                await OnGetAsync(); // Rehydrate view model
                return Page();
            }

            var client = _httpClientFactory.CreateClient();

            var cookie = _httpContextAccessor.HttpContext.Request.Headers["Cookie"].ToString();
            if (!string.IsNullOrEmpty(cookie))
            {
                client.DefaultRequestHeaders.Add("Cookie", cookie);
            }

            var apiUrl = "https://localhost:7254/api/user/transaction";
            var response = await client.PostAsJsonAsync(apiUrl, Transaction);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage(); // Success: reload page
            }

            // If API returns a validation error (like from backend logic)
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorMsg = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError("Transaction.Discounted", errorMsg);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to create transaction.");
            }

            // Force the modal to show again after failed submission
            ViewData["ShowCreateModal"] = true;

            await OnGetAsync(); // Rehydrate Summary & Transactions on failure
            return Page();
        }
    }
}
