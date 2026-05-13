namespace WeatherApp
{
    partial class UpcommingForecast
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
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowForecastPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowForecastPanel
            // 
            this.flowForecastPanel.AutoScroll = true;
            this.flowForecastPanel.BackColor = System.Drawing.Color.Transparent;
            this.flowForecastPanel.Location = new System.Drawing.Point(66, 37);
            this.flowForecastPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowForecastPanel.Name = "flowForecastPanel";
            this.flowForecastPanel.Size = new System.Drawing.Size(540, 293);
            this.flowForecastPanel.TabIndex = 0;
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.Transparent;
            this.Back.Location = new System.Drawing.Point(9, 10);
            this.Back.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(50, 23);
            this.Back.TabIndex = 1;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.BackToHomePage_Click);
            // 
            // UpcommingForecast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WeatherApp.Properties.Resources.wp661789_blue_gradient_wallpaper;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 365);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.flowForecastPanel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "UpcommingForecast";
            this.Text = "5-Day Forecast";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpcommingForecast_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowForecastPanel;
        private System.Windows.Forms.Button Back;
    }
}