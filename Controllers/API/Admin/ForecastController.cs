using Microsoft.AspNetCore.Mvc;
using MLModel_ConsoleApp1;

namespace app_example.Controllers.API.Admin
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForecastController : ControllerBase
    {
        [HttpGet("daily")]
        public IActionResult GetDailyForecast([FromQuery] int days = 30)
        {
            var prediction = MLModel.Predict(horizon: days);
            var result = prediction.OverallPaxAmount?.ToList() ?? new List<float>();
            return Ok(result);
        }

        [HttpGet("summary")]
        public IActionResult GetForecastSummary()
        {
            var prediction = MLModel.Predict(horizon: 365);
            var values = prediction.OverallPaxAmount?.ToList() ?? new List<float>();

            var weekly = values.Chunk(7).Select(c => c.Sum(x => (decimal)x)).ToList();
            var monthly = values.Chunk(30).Select(c => c.Sum(x => (decimal)x)).ToList();
            var quarterly = values.Chunk(90).Select(c => c.Sum(x => (decimal)x)).ToList();
            var annual = values.Sum(x => (decimal)x);

            return Ok(new
            {
                Daily = values,
                Weekly = weekly,
                Monthly = monthly,
                Quarterly = quarterly,
                Annual = annual
            });
        }
    }
}
