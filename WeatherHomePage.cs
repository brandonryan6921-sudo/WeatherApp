using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherApp;
using static WeatherApp.ForecastWeather;

namespace WeatherApp
{
    public partial class WeatherHomePage : Form
    {
        // Timezone offset in seconds for local time calculation
        private int timezoneOffsetSeconds;

        // Timer for updating the local time display
        private Timer localTimeTimer;

        // Database components (DataSet and TableAdapters)
        private WeatherDBDataSet weatherAppDBDataSet;
        private WeatherDBDataSetTableAdapters.UserLocationTableAdapter userLocationTableAdapter;
        private WeatherDBDataSetTableAdapters.WeatherHistoryTableAdapter weatherHistoryTableAdapter;

        // API key for OpenWeatherMap (Note: In production, this should be secured)
        string ApiKey = "bc0777391e88fa6edcb18b188696eb0a";

        // Temperature unit tracking
        private bool isCelsius = true;

        // Cache of last retrieved weather data
        private double lastTempC;
        private double lastHumidity;
        private string lastConditions;

        // Geographic coordinates of last search
        private double lon;
        private double lat;

        //     ForecastWeather.City.Text (City is a data model class, not a UI control)
        private string currentCityName = string.Empty;

        public WeatherHomePage()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form1_Load);
            this.StartPosition = FormStartPosition.CenterScreen;


            try
            {
                // Initialize database components
                weatherAppDBDataSet = new WeatherDBDataSet();
                userLocationTableAdapter = new WeatherDBDataSetTableAdapters.UserLocationTableAdapter();
                weatherHistoryTableAdapter = new WeatherDBDataSetTableAdapters.WeatherHistoryTableAdapter();

                // Load initial data from database
                RefreshDatabaseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error initializing database or loading data:\n{ex.Message}",
                    "Initialization Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

       

        // Refreshes data from the database
        private void RefreshDatabaseConnection()
        {
            try
            {
                // Clear existing data and reload
                weatherAppDBDataSet.Clear();
                userLocationTableAdapter.Fill(weatherAppDBDataSet.UserLocation);
                weatherHistoryTableAdapter.Fill(weatherAppDBDataSet.WeatherHistory);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Could not load saved locations or history:\n{ex.Message}",
                    "Database Load Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize components when form loads
            RefreshDatabaseConnection();
            InitializeLocalTimeTimer();
            LoadLastSearchedCity();
        }

        // Sets up the timer for updating local time display
        private void InitializeLocalTimeTimer()
        {
            localTimeTimer = new Timer();
            localTimeTimer.Interval = 1000; // Update every second
            localTimeTimer.Tick += (s, e) =>
            {
                // Calculate local time using timezone offset
                DateTime localTime = DateTime.UtcNow.AddSeconds(timezoneOffsetSeconds);
                LocalTimeLabel.Text = "🕒 " + localTime.ToString("hh:mm:ss tt");
            };
            localTimeTimer.Start();
        }

        // Handles temperature unit conversion
        private void changeUnitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox6.Text) || textBox6.Text == "N/A") return;

            // Extract numeric value from temperature string
            int degPos = textBox6.Text.IndexOf('°');
            if (degPos < 0) return;

            string numberPart = textBox6.Text.Substring(0, degPos);
            if (!double.TryParse(numberPart, out double temp)) return;

            // Convert between Celsius and Fahrenheit
            double newTemp;
            string newUnit;

            if (isCelsius)
            {
                newTemp = temp * 9.0 / 5.0 + 32.0;
                newUnit = "°F";
            }
            else
            {
                newTemp = (temp - 32.0) * 5.0 / 9.0;
                newUnit = "°C";
            }

            // Update display
            textBox6.Text = $"{newTemp:F1}{newUnit}";
            isCelsius = !isCelsius;

            // Update menu item text
            if (sender is ToolStripMenuItem clickedMenuItem)
            {
                clickedMenuItem.Text = isCelsius ? "Switch to °F" : "Switch to °C";
            }
        }

        // Displays help information
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string faqMessage = "❓ Frequently Asked Questions\n\n" +
                         "1. **Where does this weather information come from?**\n" +
                         "   → We use the OpenWeatherMap API to gather accurate and up-to-date weather forecasts.\n\n" +
                         "2. **How often is the data updated?**\n" +
                         "   → The data is updated every few hours by OpenWeather servers, based on your location.\n\n" +
                         "3. **Can I check the forecast for other locations?**\n" +
                         "   → Yes! You can search for any city using the search functionality.\n\n" +
                         "4. **Why does the app need my location?**\n" +
                         "   → Your location helps us give you the most relevant weather data.\n\n" +
                         "Click 'Yes' to visit the OpenWeather API website.\nClick 'No' to stay on this page.";

            DialogResult result = MessageBox.Show(faqMessage, "Help & FAQs", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Open help website
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = "https://openweathermap.org/api",
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Unable to open the help link: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Opens forecast form
        private void button1_Click(object sender, EventArgs e)
        {
            // Check if coordinates are valid (city has been searched)
            if (lat == 0 && lon == 0)
            {
                MessageBox.Show("Please search for a city first to view the forecast.", "No Location", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create and show forecast form with current coordinates
            UpcommingForecast forecastForm = new UpcommingForecast(lat, lon);
            forecastForm.Show();
            this.Hide();
        }

        // Handles city search
        private void button2_Click(object sender, EventArgs e)
        {
            string cityName = search.Text.Trim();
            if (string.IsNullOrEmpty(cityName))
            {
                MessageBox.Show("Please enter a city name.");
                return;
            }

            // Get weather data
            getWeather();

 
            // currentCityName is set inside getWeather() from the API response 
            SaveSearchHistory(search.Text.Trim(), lat, lon);
            SaveWeatherData(currentCityName, lat, lon, lastTempC, lastHumidity, lastConditions);

            // Force immediate database update
            userLocationTableAdapter.Update(weatherAppDBDataSet.UserLocation);
            weatherHistoryTableAdapter.Update(weatherAppDBDataSet.WeatherHistory);
        }

        // Gets location ID from database
        private int GetRealLocationId(string cityName)
        {
            return weatherAppDBDataSet.UserLocation
                           .FirstOrDefault(r => r.City.Equals(cityName, StringComparison.OrdinalIgnoreCase))
                           ?.UserLocationID ?? -1;
        }

        // Saves search history to database
        private void SaveSearchHistory(string cityName, double lat, double lon)
        {
            try
            {
                // Check if city already exists in database
                var existing = weatherAppDBDataSet.UserLocation
                                 .FirstOrDefault(r => r.City.Equals(cityName, StringComparison.OrdinalIgnoreCase));

                if (existing != null)
                {
                    // Update existing record
                    existing.LastSearchTime = DateTime.Now;
                    existing.Latitude = lat;
                    existing.Longitude = lon;
                }
                else
                {
                    // Create new record
                    var row = weatherAppDBDataSet.UserLocation.NewUserLocationRow();
                    row.City = cityName;
                    row.Latitude = lat;
                    row.Longitude = lon;
                    row.LastSearchTime = DateTime.Now;
                    weatherAppDBDataSet.UserLocation.AddUserLocationRow(row);
                }

                // Update database
                userLocationTableAdapter.Update(weatherAppDBDataSet.UserLocation);
                weatherAppDBDataSet.UserLocation.Clear();
                userLocationTableAdapter.Fill(weatherAppDBDataSet.UserLocation);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving search history: {ex.Message}\nCheck database file permissions.",
                              "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Saves weather data to history table
        private void SaveWeatherData(string cityName, double lat, double lon,
                                     double temperature, double humidity, string conditions)
        {
            try
            {
                int realId = GetRealLocationId(cityName);
                if (realId < 0) return;

                // Create new history record
                var hist = weatherAppDBDataSet.WeatherHistory.NewWeatherHistoryRow();
                hist.UserLocationID = realId;
                hist.Date = DateTime.Now;
                hist.Temperature = temperature;
                hist.Humidity = humidity;
                hist.Conditions = conditions;

                weatherAppDBDataSet.WeatherHistory.AddWeatherHistoryRow(hist);
                weatherHistoryTableAdapter.Update(weatherAppDBDataSet.WeatherHistory);
                RefreshDatabaseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving weather data: {ex.Message}");
            }
        }

        // Loads the last searched city from database
        private void LoadLastSearchedCity()
        {
            var last = weatherAppDBDataSet.UserLocation
                           .OrderByDescending(r => r.LastSearchTime)
                           .FirstOrDefault();

            if (last != null)
            {
                search.Text = last.City;
                getWeather(); // Fetch fresh data
            }
        }

        // Gets weather by geographic coordinates
        private void getWeatherByCoords(double latitude, double longitude)
        {
            try
            {
                using (WebClient web = new WebClient())
                {
                    string url = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={ApiKey}&units=metric";
                    var json = web.DownloadString(url);
                    CurrentWeather.Root Info = JsonConvert.DeserializeObject<CurrentWeather.Root>(json);

                    // Update UI with weather data
                    // ForecastWeather.City.Text (which is a data model, not a UI control)
                    currentCityName = Info.name ?? "N/A";
                    Country.Text = Info.sys?.country ?? "N/A";
                    lastTempC = Info.main.temp;
                    lastHumidity = Info.main.humidity;
                    lastConditions = Info.weather[0].description;

                    Degrees.Text = $"{lastTempC:F1}°C";
                    HumidityText.Text = $"{lastHumidity}%";
                    CurrentDetails.Text = lastConditions;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading last city: {ex.Message}");
            }
        }

        // Gets weather data for searched city
        void getWeather()
        {
            if (string.IsNullOrWhiteSpace(search.Text))
            {
                MessageBox.Show("Please enter a city name.");
                return;
            }

            try
            {
                using (WebClient web = new WebClient())
                {
                    string cityEscaped = Uri.EscapeDataString(this.search.Text.Trim());
                    string url = $"https://api.openweathermap.org/data/2.5/weather?q={cityEscaped}&appid={ApiKey}&units=metric";

                    var json = web.DownloadString(url);
                    CurrentWeather.Root Info = JsonConvert.DeserializeObject<CurrentWeather.Root>(json);

                    // Update weather icon and description
                    if (Info?.weather != null && Info.weather.Count > 0)
                    {
                        CurrenPicture.ImageLocation =
                            $"https://openweathermap.org/img/wn/{Info.weather[0].icon}@2x.png";
                        CurrentDetails.Text = Info.weather[0].description;
                    }
                    else
                    {
                        CurrentDetails.Text = "N/A";
                        CurrenPicture.ImageLocation = null;
                    }

                    // Update weather metrics
                    WindSpeedText.Text = Info?.wind != null
                        ? $"{Info.wind.speed} m/s"
                        : "N/A";
                    HumidityText.Text = Info?.main != null
                        ? $"{Info.main.humidity}%"
                        : "N/A";

                    // ForecastWeather.City.Text (which is a data model, not a UI control)
                    currentCityName = Info?.name ?? "N/A";
                    Country.Text = Info?.sys?.country ?? "N/A";
                    City.Text = currentCityName;

                    if (Info?.main != null)
                    {
                        lastTempC = Info.main.temp;
                        lastHumidity = Info.main.humidity;
                        lastConditions = Info.weather?[0].description ?? "N/A";
                        textBox6.Text = $"{lastTempC:F1}\u00B0C";
                        isCelsius = true;
                    }
                    else
                    {
                        textBox6.Text = "N/A";
                    }

                    // Save coordinates for future requests
                    lon = Info.coord.lon;
                    lat = Info.coord.lat;

                    // Save timezone for clock updates
                    timezoneOffsetSeconds = Info.timezone;
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show("Network error: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Gets forecast data
        void getForecast()
        {
            try
            {
                using (WebClient web = new WebClient())
                {
                    string url = $"https://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&appid={ApiKey}&units=metric";
                    var json = web.DownloadString(url);
                    ForecastWeather.Root forecastInfo = JsonConvert.DeserializeObject<ForecastWeather.Root>(json);

                    // Forecast data is retrieved but not displayed in this form
                }
            }
            catch (WebException ex)
            {
                // Check if the response exists and is an HTTP 404 (Not Found)
                if (ex.Response is HttpWebResponse response && response.StatusCode == HttpStatusCode.NotFound)
                {
                    MessageBox.Show("The city you entered could not be found. Please check your spelling and try again.",
                                    "City Not Found",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Network error: " + ex.Message,
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        // Opens weather alerts form
        private void btnWeatherAlerts_Click(object sender, EventArgs e)
        {
            WeatherAlerts weatherAlertsForm = new WeatherAlerts(lat, lon);
            weatherAlertsForm.Show();
        }

        // Displays about/contact information
        private void aboutUsContactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string contactInfo = "🌦️ About Us:\n" +
                         "WeatherApp is your friendly neighborhood forecast tool...\n\n" +
                         "📬 Mailing Address:\n" +
                         "123 WeatherAPI Street\n" +
                         "Antarctica Avenue\n" +
                         "Chicago, IL 60601\n\n" +
                         "📞 Phone: +1 (800) 555-FORECAST\n" +
                         "📠 Fax: +1 (800) 555-FAWX\n" +
                         "✉️ Email: contact@weatherapi.fake\n";
            MessageBox.Show(contactInfo, "About Us & Contact Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Data classes for JSON deserialization
        public class WeatherData
        {
            public MainData Main { get; set; }
            public WeatherDescription[] Weather { get; set; }
        }

        public class MainData
        {
            public double Temp { get; set; }
            public double Humidity { get; set; }
        }

        public class WeatherDescription
        {
            public string Description { get; set; }
        }

        // Database binding methods (auto-generated by Visual Studio)
        private void userLocationBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            userLocationTableAdapter.Update(weatherAppDBDataSet.UserLocation);
            weatherHistoryTableAdapter.Update(weatherAppDBDataSet.WeatherHistory);
        }

        // Handles form closing - exits the entire application
        private void WeatherHomePage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // Empty event handlers (auto-generated)
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox6_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label2_Click_1(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void userLocationDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}