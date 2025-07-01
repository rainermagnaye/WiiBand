using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using app_example.DTOs;

namespace app_example.Pages.User
{
    public class DashboardModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public List<TransactionResponse> Transactions { get; set; } = new();
        public TodaySummary Summary { get; set; } = new();

        // This property binds to the form fields
        [BindProperty]
        public TransactionCreateRequest Transaction { get; set; } = new();

        public DashboardModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var apiUrl = "https://localhost:7254/api/user/transaction";
            var transactions = await client.GetFromJsonAsync<List<TransactionResponse>>(apiUrl);

            if (transactions != null)
                Transactions = transactions;

            var summaryUrl = "https://localhost:7254/api/user/transaction/today-summary";
            var summary = await client.GetFromJsonAsync<TodaySummary>(summaryUrl);

            if (summary != null)
                Summary = summary;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var client = _httpClientFactory.CreateClient();

            var apiUrl = "https://localhost:7254/api/user/transaction";

            var response = await client.PostAsJsonAsync(apiUrl, Transaction);

            if (response.IsSuccessStatusCode)
            {
                // Optional: redirect to refresh the page
                return RedirectToPage();
            }

            ModelState.AddModelError(string.Empty, "Failed to create transaction.");
            return Page();
        }
    }
}
