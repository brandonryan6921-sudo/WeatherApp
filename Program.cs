using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]  // Marks the main thread as a single-threaded apartment for Windows Forms compatibility
        static void Main()
        {
            Application.EnableVisualStyles(); // Enables visual styles for controls (modern look)
            Application.SetCompatibleTextRenderingDefault(false); // Uses GDI+ for text rendering for better compatibility

            MessageBox.Show("App starting..."); // Temporary debug message to confirm app launch

            Application.Run(new WeatherHomePage()); // Starts the application with the WeatherHomePage form
        }
    }
}
