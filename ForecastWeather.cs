using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public partial class ForecastWeather
    {
        // Root class representing the entire weather forecast response
        public class Root
        {
            [JsonProperty("cod")]
            public string Cod { get; set; } // HTTP response code (e.g., "200" for success)

            [JsonProperty("message")]
            public double Message { get; set; } // Internal parameter, may contain error messages

            [JsonProperty("cnt")]
            public int Cnt { get; set; } // Count of forecast items returned in the list

            [JsonProperty("list")]
            public List<ListItem> List { get; set; } // Collection of forecast data points

            [JsonProperty("city")]
            public City City { get; set; } // Information about the forecast location
        }

        // Represents a single forecast time period (typically 3-hour intervals)
        public class ListItem
        {
            [JsonProperty("dt")]
            public long Dt { get; set; } // Forecast time as Unix timestamp (seconds since 1/1/1970 UTC)

            [JsonProperty("main")]
            public Main Main { get; set; } // Main weather parameters (temp, humidity, etc.)

            [JsonProperty("weather")]
            public List<Weather> Weather { get; set; } // Weather condition descriptions

            [JsonProperty("clouds")]
            public Clouds Clouds { get; set; } // Cloud coverage information

            [JsonProperty("wind")]
            public Wind Wind { get; set; } // Wind speed and direction data

            [JsonProperty("visibility")]
            public int Visibility { get; set; } // Average visibility in meters

            [JsonProperty("pop")]
            public double PrecipitationProbability { get; set; } // Probability of precipitation (0-1 scale)

            [JsonProperty("rain")]
            public Rain Rain { get; set; } // Optional: Rain volume data (null if no rain)

            [JsonProperty("snow")]
            public Snow Snow { get; set; } // Optional: Snow volume data (null if no snow)

            [JsonProperty("sys")]
            public Sys Sys { get; set; } // Part of day indicator (night/day)

            [JsonProperty("dt_txt")]
            public string DtTxt { get; set; } // Forecast time in ISO 8601 format (YYYY-MM-DD HH:MM:SS)

            // Helper property to convert Unix timestamp to DateTime
            public DateTime ForecastTime => DateTimeOffset.FromUnixTimeSeconds(Dt).DateTime;
        }

        // Contains main weather metrics for a forecast period
        public class Main
        {
            [JsonProperty("temp")]
            public double Temp { get; set; } // Temperature in specified units

            [JsonProperty("feels_like")]
            public double FeelsLike { get; set; } // Human-perceived temperature

            [JsonProperty("temp_min")]
            public double TempMin { get; set; } // Minimum expected temperature

            [JsonProperty("temp_max")]
            public double TempMax { get; set; } // Maximum expected temperature

            [JsonProperty("pressure")]
            public int Pressure { get; set; } // Atmospheric pressure in hPa

            [JsonProperty("sea_level")]
            public int SeaLevel { get; set; } // Sea-level pressure in hPa

            [JsonProperty("grnd_level")]
            public int GrndLevel { get; set; } // Ground-level pressure in hPa

            [JsonProperty("humidity")]
            public int Humidity { get; set; } // Relative humidity percentage (0-100)

            [JsonProperty("temp_kf")]
            public double TempKf { get; set; } // Internal parameter (temperature adjustment)
        }

        // Describes weather conditions
        public class Weather
        {
            [JsonProperty("id")]
            public int Id { get; set; } // Weather condition ID (e.g., 800 for clear sky)

            [JsonProperty("main")]
            public string Main { get; set; } // Group of weather parameters (Rain, Snow, etc.)

            [JsonProperty("description")]
            public string Description { get; set; } // Text description of weather condition

            [JsonProperty("icon")]
            public string Icon { get; set; } // Weather icon ID for visual representation
        }

        // Cloud coverage information
        public class Clouds
        {
            [JsonProperty("all")]
            public int All { get; set; } // Cloud coverage percentage (0-100)
        }

        // Wind information
        public class Wind
        {
            [JsonProperty("speed")]
            public double Speed { get; set; } // Wind speed in specified units

            [JsonProperty("deg")]
            public int Deg { get; set; } // Wind direction in degrees (meteorological)

            [JsonProperty("gust")]
            public double Gust { get; set; } // Wind gust speed in specified units
        }

        // Rain precipitation data
        public class Rain
        {
            // Note: Property name must match JSON exactly ("3h")
            [JsonProperty("3h")]
            public double VolumeLast3h { get; set; } // Rain volume in mm for last 3 hours
        }

        // Snow precipitation data
        public class Snow
        {
            // Note: Property name must match JSON exactly ("3h")
            [JsonProperty("3h")]
            public double VolumeLast3h { get; set; } // Snow volume in mm for last 3 hours
        }

        // System information (simplified for forecast)
        public class Sys
        {
            [JsonProperty("pod")]
            public string Pod { get; set; } // Part of day: "n" for night, "d" for day
        }

        // City/location information for the forecast
        public class City
        {
            [JsonProperty("id")]
            public int Id { get; set; } // City ID (OpenWeatherMap specific)

            [JsonProperty("name")]
            public string Name { get; set; } // City name

            [JsonProperty("coord")]
            public Coord Coord { get; set; } // Geographic coordinates

            [JsonProperty("country")]
            public string Country { get; set; } // Country code (e.g., "US")

            [JsonProperty("population")]
            public int Population { get; set; } // City population

            [JsonProperty("timezone")]
            public int Timezone { get; set; } // Shift in seconds from UTC

            [JsonProperty("sunrise")]
            public long Sunrise { get; set; } // Sunrise time as Unix timestamp

            [JsonProperty("sunset")]
            public long Sunset { get; set; } // Sunset time as Unix timestamp
        }

        // Geographic coordinates (can be shared with CurrentWeather)
        public class Coord
        {
            [JsonProperty("lat")]
            public double Lat { get; set; } // Latitude (-90 to 90)

            [JsonProperty("lon")]
            public double Lon { get; set; } // Longitude (-180 to 180)
        }
    }
}
