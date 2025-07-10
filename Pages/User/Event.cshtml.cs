using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;
using app_example.Models.User;

namespace app_example.Pages.User
{
    public class EventModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EventModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Properties used in Razor
        public List<Event> Events { get; set; } = new List<Event>();

        [BindProperty]
        public Event NewEvent { get; set; } = new Event();

        public DateTime ViewDate { get; set; }

        private string ApiUrl => "https://localhost:7254/api/Event"; // change to match your actual API

        /// <summary>
        /// OnGetAsync: supports optional month & year (for calendar navigation)
        /// </summary>
        public async Task OnGetAsync(int? month = null, int? year = null)
        {
            // decide what month/year to show
            if (month.HasValue && year.HasValue)
            {
                ViewDate = new DateTime(year.Value, month.Value, 1);
            }
            else
            {
                ViewDate = DateTime.Today;
            }

            // load events from API
            var client = _httpClientFactory.CreateClient();
            try
            {
                var response = await client.GetFromJsonAsync<List<Event>>(ApiUrl);
                Events = response ?? new List<Event>();
            }
            catch
            {
                Events = new List<Event>(); // fallback on error
            }
        }

        /// <summary>
        /// OnPostAsync: creates a new event via API
        /// </summary>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync(); // reload data
                return Page();
            }

            var client = _httpClientFactory.CreateClient();
            try
            {
                var response = await client.PostAsJsonAsync(ApiUrl, NewEvent);

                if (response.IsSuccessStatusCode)
                {
                    TempData["ShowAddToast"] = true;  // ✅ set flag
                    return RedirectToPage(); // refresh page after successful add
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to create event.");
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Error connecting to server.");
            }

            await OnGetAsync(); // reload events even if failed
            return Page();
        }

    }
}