using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;

// Weather Forecast form
namespace WeatherApp
{
    public partial class UpcommingForecast : Form
    {
        // OpenWeatherMap API key for forecast requests
        private const string ApiKey = "bc0777391e88fa6edcb18b188696eb0a";

        // Latitude and longitude for the forecast location
        private double lat;
        private double lon;


        // Constructor takes latitude and longitude, initializes form and loads forecast
        public UpcommingForecast(double lat, double lon)
        {
            InitializeComponent();
            this.lat = lat;
            this.lon = lon;

            LoadForecast(); // Fetch and display forecast on startup
            this.StartPosition = FormStartPosition.CenterScreen;
        }




        // Fetches weather forecast data and dynamically creates UI cards
        private void LoadForecast()
        {
            try
            {
                using (WebClient web = new WebClient())
                {
                    // Build the API request URL with metrics units
                    string url = $"https://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&appid={ApiKey}&units=metric";

                    // Download JSON response and parse into objects
                    var json = web.DownloadString(url);
                    ForecastWeather.Root forecastInfo = JsonConvert.DeserializeObject<ForecastWeather.Root>(json);

                    if (forecastInfo?.List == null || forecastInfo.List.Count == 0)
                    {
                        MessageBox.Show("No forecast data available for this location.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Clear previous forecast cards from the panel
                    flowForecastPanel.Controls.Clear();

                    // Pick one forecast entry per day (select around midday) for the next 5 days
                    var dailyForecasts = new Dictionary<string, ForecastWeather.ListItem>();
                    foreach (var item in forecastInfo.List)
                    {
                        // Convert Unix timestamp to DateTime
                        DateTime forecastDateTime = DateTimeOffset.FromUnixTimeSeconds(item.Dt).DateTime;
                        string dateKey = forecastDateTime.ToString("yyyy-MM-dd");

                        // Select entries between 11 AM and 1 PM for each day if not already added
                        if (!dailyForecasts.ContainsKey(dateKey) &&
                            forecastDateTime.Hour >= 11 &&
                            forecastDateTime.Hour <= 13)
                        {
                            dailyForecasts[dateKey] = item;
                        }

                        // Stop after collecting 5 days of forecasts
                        if (dailyForecasts.Count == 5)
                            break;
                    }

                    // If we don't have exactly 5 days, try to get the best available data
                    if (dailyForecasts.Count < 5)
                    {
                        dailyForecasts.Clear();
                        int dayCount = 0;
                        string lastDateKey = "";

                        foreach (var item in forecastInfo.List)
                        {
                            DateTime forecastDateTime = DateTimeOffset.FromUnixTimeSeconds(item.Dt).DateTime;
                            string dateKey = forecastDateTime.ToString("yyyy-MM-dd");

                            // Add first item of each new day
                            if (dateKey != lastDateKey)
                            {
                                dailyForecasts[dateKey] = item;
                                lastDateKey = dateKey;
                                dayCount++;

                                if (dayCount >= 5)
                                    break;
                            }
                        }
                    }

                    // Create and add a card for each selected forecast entry
                    foreach (var item in dailyForecasts.Values)
                    {
                        try
                        {
                            // Format the forecast date and time for display
                            DateTime forecastDateTime = DateTimeOffset.FromUnixTimeSeconds(item.Dt).DateTime;
                            string dateTime = forecastDateTime.ToString("dddd, MMMM d yyyy h:mm tt", CultureInfo.InvariantCulture);

                            // Calculate responsive card width
                            int availableWidth = flowForecastPanel.Width - 718;
                            int cardWidth = Math.Max(225, availableWidth / 2);

                            // Configure panel to serve as a forecast card
                            Panel card = new Panel
                            {
                                Width = cardWidth,
                                Height = 140,
                                BackColor = Color.White,
                                Margin = new Padding(8),
                                BorderStyle = BorderStyle.FixedSingle
                            };

                            // Weather icon from OpenWeatherMap
                            PictureBox icon = new PictureBox
                            {
                                Size = new Size(60, 60),
                                Location = new Point(15, 15),
                                SizeMode = PictureBoxSizeMode.Zoom
                            };

                            try
                            {
                                icon.Load($"https://openweathermap.org/img/wn/{item.Weather[0].Icon}@2x.png");
                            }
                            catch
                            {
                                // If icon fails to load, continue without it
                            }

                            // Temperature label (bold, large)
                            Label lblTemp = new Label
                            {
                                Text = $"{item.Main.Temp:F2}°C",
                                Location = new Point(85, 15),
                                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                                AutoSize = true,
                                ForeColor = Color.Black
                            };

                            // Weather description label
                            Label lblDesc = new Label
                            {
                                Text = item.Weather[0].Description,
                                Location = new Point(85, 50),
                                Font = new Font("Segoe UI", 10),
                                AutoSize = true,
                                ForeColor = Color.Black
                            };

                            // Date and time label
                            Label lblTime = new Label
                            {
                                Text = dateTime,
                                Location = new Point(15, 80),
                                Font = new Font("Segoe UI", 9),
                                AutoSize = false,
                                Width = cardWidth - 30,
                                ForeColor = Color.Black
                            };

                            // Humidity and wind speed extras label
                            Label lblExtras = new Label
                            {
                                Text = $"💧 {item.Main.Humidity}%      💨 {item.Wind.Speed:F2} m/s",
                                Location = new Point(15, 110),
                                Font = new Font("Segoe UI", 9),
                                AutoSize = false,
                                Width = cardWidth - 30,
                                ForeColor = Color.Black
                            };

                            // Assemble card controls
                            card.Controls.Add(icon);
                            card.Controls.Add(lblTemp);
                            card.Controls.Add(lblDesc);
                            card.Controls.Add(lblTime);
                            card.Controls.Add(lblExtras);

                            // Add card to the flow layout panel for display
                            flowForecastPanel.Controls.Add(card);
                        }
                        catch (Exception cardEx)
                        {
                            // Log but continue if single card fails
                            System.Diagnostics.Debug.WriteLine($"Error creating forecast card: {cardEx.Message}");
                        }
                    }

                    if (flowForecastPanel.Controls.Count == 0)
                    {
                        MessageBox.Show("Unable to load forecast data. Please try again.", "No Forecast", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading forecast: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Handler for the Back button to navigate to the home page
        private void BackToHomePage_Click(object sender, EventArgs e)
        {
            // Show the existing home page instance instead of creating a new one
            foreach (Form form in Application.OpenForms)
            {
                if (form is WeatherHomePage)
                {
                    form.Show();
                    this.Close();
                    return;
                }
            }

            // If no home page instance found, create a new one
            WeatherHomePage homePage = new WeatherHomePage();
            homePage.Show();
            this.Close();
        }

        // Paint event for custom drawing on the flow layout panel (optional)
        private void flowForecastPanel_Paint(object sender, PaintEventArgs e)
        {
            // Add custom painting logic here if needed
        }

        // Handles form closing - shows main form again
        private void UpcommingForecast_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Find and show the main WeatherHomePage form
            foreach (Form form in Application.OpenForms)
            {
                if (form is WeatherHomePage mainForm)
                {
                    mainForm.Show();
                    break;
                }
            }
        }


    }
}