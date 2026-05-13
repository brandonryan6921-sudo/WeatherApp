using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class WeatherAlerts : Form
    {
        // OpenWeatherMap API key for alerts endpoint
        private const string ApiKey = "bc0777391e88fa6edcb18b188696eb0a";

        // Coordinates for alert retrieval
        private double lat;
        private double lon;

        // Constructor: accepts latitude and longitude, initializes components, and loads alerts
        public WeatherAlerts(double lat, double lon)
        {
            InitializeComponent();
            // Note: InitializeComponent is called twice; consider removing duplicate
            InitializeComponent();
            this.lat = lat;
            this.lon = lon;

            LoadWeatherAlerts(); // Fetch and display current weather alerts
        }

        // Fetches weather alerts using the One Call API
        private void LoadWeatherAlerts()
        {
            try
            {
                using (WebClient web = new WebClient())
                {
                    // Build API URL: exclude irrelevant data, include alerts
                    string url = $"https://api.openweathermap.org/data/2.5/onecall?lat={lat}&lon={lon}&exclude=current,minutely,daily&appid={ApiKey}";

                    // Download JSON response
                    var json = web.DownloadString(url);

                    // Deserialize into WeatherAlertsData model
                    var weatherData = JsonConvert.DeserializeObject<WeatherAlertsData>(json);

                    // Check if any alerts are present
                    if (weatherData.alerts != null && weatherData.alerts.Any())
                    {
                        // Iterate through each alert
                        foreach (var alert in weatherData.alerts)
                        {
                            // Format alert message: event and description
                            string alertMessage = $"{alert.AlertEvent} alert:\n{alert.description}\n\n";

                            // Create read-only, scrollable TextBox for display
                            TextBox alertBox = new TextBox
                            {
                                Text = alertMessage,
                                Multiline = true,
                                ReadOnly = true,
                                Width = 400,
                                Height = 100,
                                ScrollBars = ScrollBars.Vertical
                            };

                            // Add alert box to the flow layout panel
                            flowLayoutPanelAlerts.Controls.Add(alertBox);
                        }
                    }
                    else
                    {
                        // No alerts: notify user
                        MessageBox.Show(
                            "No active weather alerts.",
                            "Weather Alerts",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                // Display any errors during fetch or parse
                MessageBox.Show(
                    "Error fetching weather alerts: " + ex.Message,
                    "Weather Alerts Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // Form load event handler (currently unused)
        private void WeatherAlerts_Load(object sender, EventArgs e)
        {
            // Additional initialization logic can be placed here
        }

        // Paint event for alerts panel: reloads alerts when the panel repaints
        private void flowLayoutPanelAlerts_Paint(object sender, PaintEventArgs e)
        {
            LoadWeatherAlerts();
        }

        // Data model for deserializing alert data
        public class WeatherAlertsData
        {
            public List<Alert> alerts { get; set; } // List of alert objects
        }

        // Represents a single weather alert
        public class Alert
        {
            public string AlertEvent { get; set; }   // Name of the alert event
            public string description { get; set; }  // Detailed alert description
            public long start { get; set; }          // Start time (Unix timestamp)
            public long end { get; set; }            // End time (Unix timestamp)
            public string sender_name { get; set; }  // Issuing authority name
        }
    }
}
