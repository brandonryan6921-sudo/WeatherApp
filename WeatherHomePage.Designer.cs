namespace WeatherApp
{
    partial class WeatherHomePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method by the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LocalTimeLabel = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Degrees = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.search = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SearchCity = new System.Windows.Forms.Button();
            this.HumidityText = new System.Windows.Forms.TextBox();
            this.WindSpeedText = new System.Windows.Forms.TextBox();
            this.CurrentDetails = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.City = new System.Windows.Forms.TextBox();
            this.Country = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelAlerts = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CurrenPicture = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrenPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // LocalTimeLabel
            // 
            this.LocalTimeLabel.Font = new System.Drawing.Font("Poppins Medium", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocalTimeLabel.Location = new System.Drawing.Point(525, 175);
            this.LocalTimeLabel.Name = "LocalTimeLabel";
            this.LocalTimeLabel.ReadOnly = true;
            this.LocalTimeLabel.Size = new System.Drawing.Size(130, 25);
            this.LocalTimeLabel.TabIndex = 0;
            this.LocalTimeLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(800, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Degrees,
            this.helpToolStripMenuItem,
            this.aboutUsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 26);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // Degrees
            // 
            this.Degrees.Name = "Degrees";
            this.Degrees.Size = new System.Drawing.Size(257, 26);
            this.Degrees.Text = "Toggle Temperature Unit";
            this.Degrees.Click += new System.EventHandler(this.changeUnitsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.aboutUsToolStripMenuItem.Text = "About Us & Contact";
            this.aboutUsToolStripMenuItem.Click += new System.EventHandler(this.aboutUsContactsToolStripMenuItem_Click);
            // 
            // search
            // 
            this.search.Font = new System.Drawing.Font("Poppins Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search.Location = new System.Drawing.Point(285, 44);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(231, 27);
            this.search.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Poppins Medium", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(148, 44);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(112, 25);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "Search";
            // 
            // SearchCity
            // 
            this.SearchCity.Font = new System.Drawing.Font("Poppins Medium", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchCity.Location = new System.Drawing.Point(523, 40);
            this.SearchCity.Name = "SearchCity";
            this.SearchCity.Size = new System.Drawing.Size(145, 31);
            this.SearchCity.TabIndex = 4;
            this.SearchCity.Text = "Click To Search";
            this.SearchCity.UseVisualStyleBackColor = true;
            this.SearchCity.Click += new System.EventHandler(this.button2_Click);
            // 
            // HumidityText
            // 
            this.HumidityText.Font = new System.Drawing.Font("Poppins Medium", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HumidityText.Location = new System.Drawing.Point(148, 387);
            this.HumidityText.Name = "HumidityText";
            this.HumidityText.ReadOnly = true;
            this.HumidityText.Size = new System.Drawing.Size(112, 25);
            this.HumidityText.TabIndex = 5;
            this.HumidityText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // WindSpeedText
            // 
            this.WindSpeedText.Font = new System.Drawing.Font("Poppins Medium", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WindSpeedText.Location = new System.Drawing.Point(543, 387);
            this.WindSpeedText.Name = "WindSpeedText";
            this.WindSpeedText.ReadOnly = true;
            this.WindSpeedText.Size = new System.Drawing.Size(112, 25);
            this.WindSpeedText.TabIndex = 6;
            this.WindSpeedText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CurrentDetails
            // 
            this.CurrentDetails.Font = new System.Drawing.Font("Poppins Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentDetails.Location = new System.Drawing.Point(317, 197);
            this.CurrentDetails.Name = "CurrentDetails";
            this.CurrentDetails.ReadOnly = true;
            this.CurrentDetails.Size = new System.Drawing.Size(130, 27);
            this.CurrentDetails.TabIndex = 7;
            this.CurrentDetails.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Poppins Medium", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(327, 353);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(112, 48);
            this.textBox6.TabIndex = 8;
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // City
            // 
            this.City.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.City.Location = new System.Drawing.Point(327, 150);
            this.City.Name = "City";
            this.City.ReadOnly = true;
            this.City.Size = new System.Drawing.Size(112, 37);
            this.City.TabIndex = 9;
            this.City.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Country
            // 
            this.Country.Font = new System.Drawing.Font("Poppins Medium", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Country.Location = new System.Drawing.Point(327, 90);
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            this.Country.Size = new System.Drawing.Size(112, 48);
            this.Country.TabIndex = 10;
            this.Country.Text = "\r\n";
            this.Country.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("Poppins Medium", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(148, 108);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(112, 25);
            this.textBox9.TabIndex = 11;
            this.textBox9.Text = "Country:";
            // 
            // textBox10
            // 
            this.textBox10.Font = new System.Drawing.Font("Poppins Medium", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.Location = new System.Drawing.Point(148, 158);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(112, 25);
            this.textBox10.TabIndex = 12;
            this.textBox10.Text = "City:";
            // 
            // textBox11
            // 
            this.textBox11.Font = new System.Drawing.Font("Poppins Medium", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.Location = new System.Drawing.Point(148, 206);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(112, 25);
            this.textBox11.TabIndex = 13;
            this.textBox11.Text = "Description:";
            // 
            // flowLayoutPanelAlerts
            // 
            this.flowLayoutPanelAlerts.BackColor = System.Drawing.Color.Red;
            this.flowLayoutPanelAlerts.Font = new System.Drawing.Font("Poppins Medium", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanelAlerts.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.flowLayoutPanelAlerts.Location = new System.Drawing.Point(556, 90);
            this.flowLayoutPanelAlerts.Name = "flowLayoutPanelAlerts";
            this.flowLayoutPanelAlerts.Size = new System.Drawing.Size(65, 28);
            this.flowLayoutPanelAlerts.TabIndex = 15;
            this.flowLayoutPanelAlerts.Text = "Alerts";
            this.flowLayoutPanelAlerts.UseVisualStyleBackColor = false;
            this.flowLayoutPanelAlerts.Click += new System.EventHandler(this.btnWeatherAlerts_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Poppins Medium", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(529, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 61);
            this.button1.TabIndex = 16;
            this.button1.Text = "View Upcomming Forecast";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Poppins Medium", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(169, 415);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(67, 25);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = "Humidity";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Poppins Medium", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(576, 415);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(44, 25);
            this.textBox3.TabIndex = 18;
            this.textBox3.Text = "Wind";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.ErrorImage = global::WeatherApp.Properties.Resources.humidity;
            this.pictureBox2.Image = global::WeatherApp.Properties.Resources.humidity;
            this.pictureBox2.Location = new System.Drawing.Point(179, 333);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.ErrorImage = global::WeatherApp.Properties.Resources.storm;
            this.pictureBox1.Image = global::WeatherApp.Properties.Resources.storm;
            this.pictureBox1.Location = new System.Drawing.Point(569, 333);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // CurrenPicture
            // 
            this.CurrenPicture.BackColor = System.Drawing.Color.Transparent;
            this.CurrenPicture.Location = new System.Drawing.Point(327, 253);
            this.CurrenPicture.Name = "CurrenPicture";
            this.CurrenPicture.Size = new System.Drawing.Size(112, 78);
            this.CurrenPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.CurrenPicture.TabIndex = 14;
            this.CurrenPicture.TabStop = false;
            // 
            // WeatherHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WeatherApp.Properties.Resources.wp661789_blue_gradient_wallpaper;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 449);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanelAlerts);
            this.Controls.Add(this.CurrenPicture);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.Country);
            this.Controls.Add(this.City);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.CurrentDetails);
            this.Controls.Add(this.WindSpeedText);
            this.Controls.Add(this.HumidityText);
            this.Controls.Add(this.SearchCity);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.search);
            this.Controls.Add(this.LocalTimeLabel);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "WeatherHomePage";
            this.Text = "WeatherHomePage";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrenPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LocalTimeLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Degrees;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button SearchCity;
        private System.Windows.Forms.TextBox HumidityText;
        private System.Windows.Forms.TextBox WindSpeedText;
        private System.Windows.Forms.TextBox CurrentDetails;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox City;
        private System.Windows.Forms.TextBox Country;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.PictureBox CurrenPicture;
        private System.Windows.Forms.Button flowLayoutPanelAlerts;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
