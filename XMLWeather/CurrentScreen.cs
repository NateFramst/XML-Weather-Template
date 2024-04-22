using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class CurrentScreen : UserControl
    {
        public CurrentScreen()
        {
            InitializeComponent();
            DisplayCurrent();
        }

        public void DisplayCurrent()
        {
            cityOutput.Text = Form1.days[0].location;
            cityOutput.Location = new System.Drawing.Point(this.Width / 2 - cityOutput.Width / 2, 80);
            currentOutput.Text = Math.Round(Convert.ToDouble(Form1.days[0].currentTemp)).ToString("0") + "°";
            currentOutput.Location = new System.Drawing.Point(this.Width / 2 - currentOutput.Width / 2, 220);
            tempLabel.Location = new System.Drawing.Point(this.Width / 2 - tempLabel.Width / 2, 180);
            minOutput.Text = Math.Round(Convert.ToDouble(Form1.days[0].tempLow)).ToString("0") + "°";
            maxOutput.Text = Math.Round(Convert.ToDouble(Form1.days[0].tempHigh)).ToString("0")+ "°";

            humidityOutput.Text = Form1.days[0].wetAir + "%";
            sunRiseOutput.Text = AdjustTimeZone(Form1.days[0].sunRise, Form1.days[0].timeZone).ToString().Substring(11);
            sunSetOutput.Text = AdjustTimeZone(Form1.days[0].sunSet, Form1.days[0].timeZone).ToString().Substring(11);

            switch (Convert.ToInt32(Form1.days[0].weatherType))
            {
                case 800:

                    currentWeatherIcon1.Image = Properties.Resources.Sun;
                    currentWeatherIcon2.Image = Properties.Resources.Sun;

                    break;
                case int i when i >= 200 && i < 300:

                    currentWeatherIcon1.Image = Properties.Resources.Thunder;
                    currentWeatherIcon2.Image = Properties.Resources.Thunder;

                    break;

                case int i when i >= 300 && i < 400:

                    currentWeatherIcon1.Image = Properties.Resources.drizzle;
                    currentWeatherIcon2.Image = Properties.Resources.drizzle;

                    break;

                case int i when i >= 500 && i < 600:

                    currentWeatherIcon1.Image = Properties.Resources.Rainy;
                    currentWeatherIcon2.Image = Properties.Resources.Rainy;

                    break;

                case int i when i > 800:

                    currentWeatherIcon1.Image = Properties.Resources.Clouds;
                    currentWeatherIcon2.Image = Properties.Resources.Clouds;

                    break;
            }
                
           

        }

        //Mathews (W)
        public DateTime AdjustTimeZone(string time, string timezone)
        {
            int year = Convert.ToInt32(time.Substring(0, 4));
            int month = Convert.ToInt32(time.Substring(5, 2));
            int day = Convert.ToInt32(time.Substring(8, 2));
            int hour = Convert.ToInt32(time.Substring(11, 2));
            int minute = Convert.ToInt32(time.Substring(14, 2));
            int second = Convert.ToInt32(time.Substring(17, 2));

            DateTime test = new DateTime(year, month, day, hour, minute, second);

            test = test.AddSeconds(Convert.ToInt32(timezone));

            return test;
        }

        private void forecastLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new SearchScreen());
        }

        private void CurrentScreen_Load(object sender, EventArgs e)
        {
            DisplayCurrent();
            Refresh();
        }
    }
}
