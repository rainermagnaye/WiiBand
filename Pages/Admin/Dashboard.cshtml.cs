using app_example.Data;
using app_example.DTOs;
using app_example.DTOs.Admin;
using app_example.DTOs.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Json;

namespace app_example.Pages.Admin
{
    public class DashboardModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApplicationDbContext _context;

        public DashboardModel(IHttpClientFactory httpClientFactory, ApplicationDbContext context)
        {
            _httpClientFactory = httpClientFactory;
            _context = context;
        }

        // For summaries
        public List<SummaryResponse> Summaries { get; set; } = new();

        // For today transactions
        public TodaySummary TodayTransactions { get; set; } = new TodaySummary { Transactions = new List<TransactionResponse>() };

        [BindProperty(SupportsGet = true)]
        public string Type { get; set; } = "Daily";

        [BindProperty(SupportsGet = true)]
        public string Branch { get; set; } = "";

        // Separate filter for transactions
        [BindProperty(SupportsGet = true)]
        public string TransactionBranch { get; set; } = "";

        public List<SelectListItem> BranchOptions { get; set; } = new();

        public async Task OnGetAsync()
        {
            // Branch dropdown (hardcoded options)
            BranchOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "SM Fairview, Quezon City", Text = "SM Fairview" },
                new SelectListItem { Value = "Fiesta Carnival Cubao, Quezon City", Text = "Fiesta Carnival Cubao" },
                new SelectListItem { Value = "Festival Mall, Alabang", Text = "Festival Mall" },
                new SelectListItem { Value = "Venice Grand Canal Mall, Taguig City", Text = "Venice Grand Canal" }
            };
            BranchOptions.Insert(0, new SelectListItem { Value = "", Text = "All Branches" });

            var client = _httpClientFactory.CreateClient();

            // Fetch summaries
            var summaryUrl = $"https://localhost:7254/api/admin/summary?type={Type}";
            if (!string.IsNullOrWhiteSpace(Branch))
                summaryUrl += $"&branch={Uri.EscapeDataString(Branch)}";

            var summaries = await client.GetFromJsonAsync<List<SummaryResponse>>(summaryUrl);
            Summaries = summaries ?? new();

            // Fetch today's transactions (separate filter)
            if (!string.IsNullOrWhiteSpace(TransactionBranch))
            {
                var transactionUrl = $"https://localhost:7254/api/admin/transaction/today?branch={Uri.EscapeDataString(TransactionBranch)}";
                var todaySummary = await client.GetFromJsonAsync<TodaySummary>(transactionUrl);
                TodayTransactions = todaySummary ?? new TodaySummary { Transactions = new List<TransactionResponse>() };
            }
            else
            {
                // Important: set to null, not an empty list
                TodayTransactions = null;
            }
        }
    }
}
