using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;
using app_example.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace app_example.Pages.User
{
    public class EventModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public List<Event> Events { get; set; } = new();

        // The current month being viewed
        public DateTime ViewDate { get; set; } = DateTime.Today;

        public EventModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync(int? month, int? year)
        {
            var client = _httpClientFactory.CreateClient();

            var apiUrl = "https://localhost:7254/api/user/event";

            try
            {
                var events = await client.GetFromJsonAsync<List<Event>>(apiUrl);
                if (events != null)
                    Events = events;

                if (month.HasValue && year.HasValue)
                    ViewDate = new DateTime(year.Value, month.Value, 1);
                else
                    ViewDate = DateTime.Today;
            }
            catch
            {
                ViewDate = DateTime.Today; // fallback if API call fails
            }
        }
    }
}
