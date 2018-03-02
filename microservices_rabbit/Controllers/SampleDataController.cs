namespace Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Abstractions.Messages.Command;
    using Abstractions.Messages.Command.Responses;

    using Contracts.Commands;
    using Contracts.Events;

    using MassTransit;

    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly IRequestClient<IGetSomeDataCommand, IGetSomeDataCommandResponse> _getSomeDataClient;

        private readonly IBusControl _bus;

        public SampleDataController(IBusControl bus, IRequestClient<IGetSomeDataCommand, IGetSomeDataCommandResponse> getSomeDataClient)
        {
            _bus = bus;
            _getSomeDataClient = getSomeDataClient;
        }


        [HttpGet("[action]")]
        public async Task<IEnumerable<WeatherForecast>> WeatherForecasts()
        {
            var result = await _getSomeDataClient.Request(new GetSomeDataCommand { SomeParam = "some parameters" });

            await _bus.Publish(new UserRegistredEvent { Name = $"name={Guid.NewGuid()}" });

            var rng = new Random();
            return Enumerable.Range(1, 5)
                .Select(
                    index => new WeatherForecast
                                 {
                                     DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                                     TemperatureC = rng.Next(-20, 55),
                                     Summary = result.Summaries[rng.Next(result.Summaries.Length)]
                                 });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }

            public int TemperatureC { get; set; }

            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}