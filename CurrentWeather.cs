using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    internal partial class CurrentWeather
    {
        // Represents cloud coverage information
        public class Clouds
        {
            // Percentage of cloud coverage (0-100)
            public int all { get; set; }
        }

        // Represents geographical coordinates
        public class Coord
        {
            // Longitude of the location
            public double lon { get; set; }
            // Latitude of the location
            public double lat { get; set; }
        }

        // Contains main weather parameters
        public class Main
        {
            // Current temperature in specified units
            public double temp { get; set; }
            // Human perception of weather (what temperature it feels like)
            public double feels_like { get; set; }
            // Minimum temperature at the moment
            public double temp_min { get; set; }
            // Maximum temperature at the moment
            public double temp_max { get; set; }
            // Atmospheric pressure in hPa (hectopascals)
            public int pressure { get; set; }
            // Humidity percentage (0-100)
            public int humidity { get; set; }
            // Atmospheric pressure at sea level in hPa
            public int sea_level { get; set; }
            // Atmospheric pressure at ground level in hPa
            public int grnd_level { get; set; }
        }

        // Root class containing all weather data
        public class Root
        {
            // Coordinate information
            public Coord coord { get; set; }
            // List of weather conditions
            public List<Weather> weather { get; set; }
            // Internal parameter (unspecified in API docs)
            public string @base { get; set; }
            // Main weather metrics
            public Main main { get; set; }
            // Visibility in meters
            public int visibility { get; set; }
            // Wind information
            public Wind wind { get; set; }
            // Cloud coverage information
            public Clouds clouds { get; set; }
            // Time of data calculation (unix timestamp)
            public int dt { get; set; }
            // System information
            public Sys sys { get; set; }
            // Shift in seconds from UTC
            public int timezone { get; set; }
            // City ID
            public int id { get; set; }
            // City name
            public string name { get; set; }
            // Internal parameter (HTTP response code)
            public int cod { get; set; }
        }

        // Contains system information
        public class Sys
        {
            // Internal parameter (unspecified in API docs)
            public int type { get; set; }
            // Internal parameter (unspecified in API docs)
            public int id { get; set; }
            // Country code (e.g., "US")
            public string country { get; set; }
            // Sunrise time (unix timestamp)
            public int sunrise { get; set; }
            // Sunset time (unix timestamp)
            public int sunset { get; set; }
        }

        // Contains weather condition information
        public class Weather
        {
            // Weather condition ID
            public int id { get; set; }
            // Main weather group (e.g., "Rain", "Snow")
            public string main { get; set; }
            // Detailed weather description
            public string description { get; set; }
            // Weather icon ID
            public string icon { get; set; }
        }

        // Contains wind information
        public class Wind
        {
            // Wind speed in specified units
            public double speed { get; set; }
            // Wind direction in degrees (meteorological)
            public int deg { get; set; }
        }
    }
}
