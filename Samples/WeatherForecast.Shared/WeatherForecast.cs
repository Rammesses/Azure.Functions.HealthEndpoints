using System;
using System.Text.Json.Serialization;
using WeatherForecast.Shared.JsonConverters;

namespace WeatherForecast.Shared;

public class WeatherForecast
{
    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}
