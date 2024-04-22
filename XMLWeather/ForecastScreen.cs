using System;
using System.Windows.Forms;
using System.Drawing;

namespace XMLWeather
{
    public partial class ForecastScreen : UserControl
    {

        Label[] BackGroundLabels = new Label[7];
        PictureBox[] weatherIcons = new PictureBox[7];


        public ForecastScreen()
        {
            InitializeComponent();
            BackGroundLabels[0] = day1Label;
            BackGroundLabels[1] = day2Label;
            BackGroundLabels[2] = day3Label;
            BackGroundLabels[3] = day4Label;
            BackGroundLabels[4] = day5Label;
            BackGroundLabels[5] = day6Label;
            BackGroundLabels[6] = day7Label;

            weatherIcons[0] = weatherIcon1;
            weatherIcons[1] = weatherIcon2;
            weatherIcons[2] = weatherIcon3;
            weatherIcons[3] = weatherIcon4;
            weatherIcons[4] = weatherIcon5;
            weatherIcons[5] = weatherIcon6;
            weatherIcons[6] = weatherIcon7;

            weatherIcon1.Parent = day1Label;
            weatherIcon2.Parent = day2Label;
            weatherIcon3.Parent = day3Label;
            weatherIcon4.Parent = day4Label;
            weatherIcon5.Parent = day5Label;
            weatherIcon6.Parent = day6Label;
            weatherIcon7.Parent = day7Label;

            max1.Parent = day1Label;
            max2.Parent = day2Label;
            max3.Parent = day3Label;
            max4.Parent = day4Label;
            max5.Parent = day5Label;
            max6.Parent = day6Label;
            max7.Parent = day7Label;

            min1.Parent = day1Label;
            min2.Parent = day2Label;
            min3.Parent = day3Label;
            min4.Parent = day4Label;
            min5.Parent = day5Label;
            min6.Parent = day6Label;
            min7.Parent = day7Label;

            date1.Parent = day1Label;
            date2.Parent = day2Label;
            date3.Parent = day3Label;
            date4.Parent = day4Label;
            date5.Parent = day5Label;
            date6.Parent = day6Label;
            date7.Parent = day7Label;

            date1.BringToFront();
            date2.BringToFront();
            date3.BringToFront();
            date4.BringToFront();
            date5.BringToFront();
            date6.BringToFront();
            date7.BringToFront();


            date1.Location = new Point(3, 10);
            min1.Location = new Point(113, 10);
            max1.Location = new Point(173, 10);
            weatherIcon1.Location = new Point(253, 10);

            date2.Location = new Point(3, 10);
            min2.Location = new Point(113, 10);
            max2.Location = new Point(173, 10);
            weatherIcon2.Location = new Point(253, 10);

            date3.Location = new Point(3, 10);
            min3.Location = new Point(113, 10);
            max3.Location = new Point(173, 10);
            weatherIcon3.Location = new Point(253, 10);

            date4.Location = new Point(3, 10);
            min4.Location = new Point(113, 10);
            max4.Location = new Point(173, 10);
            weatherIcon4.Location = new Point(253, 10);

            date5.Location = new Point(3, 10);
            min5.Location = new Point(113, 10);
            max5.Location = new Point(173, 10);
            weatherIcon5.Location = new Point(253, 10);

            date6.Location = new Point(3, 10);
            min6.Location = new Point(113, 10);
            max6.Location = new Point(173, 10);
            weatherIcon6.Location = new Point(253, 10);

            date7.Location = new Point(3, 10);
            min7.Location = new Point(113, 10);
            max7.Location = new Point(173, 10);
            weatherIcon7.Location = new Point(253, 10);

            displayForecast();
        }

        public void displayForecast()
        {
            
            for (int i = 0; i < BackGroundLabels.Length; i++)
            {
                if (Convert.ToInt16(Form1.days[i].weatherType) == 800)
                {
                    BackGroundLabels[i].BackColor = Color.Turquoise;
                    weatherIcons[i].Image = Properties.Resources.Sun;
                }
                if (Convert.ToInt16(Form1.days[i].weatherType) >= 200 && Convert.ToInt16(Form1.days[i].weatherType) < 300)
                {
                    BackGroundLabels[i].BackColor = Color.DarkGray;
                    weatherIcons[i].Image = Properties.Resources.Thunder;
                }
                if (Convert.ToInt16(Form1.days[i].weatherType) >= 300 && Convert.ToInt16(Form1.days[i].weatherType) < 400)
                {
                    BackGroundLabels[i].BackColor = Color.LightGray;
                    weatherIcons[i].Image = Properties.Resources.drizzle;
                }
                if (Convert.ToInt16(Form1.days[i].weatherType) >= 500 && Convert.ToInt16(Form1.days[i].weatherType) < 600)
                {
                    BackGroundLabels[i].BackColor = Color.Gray;
                    weatherIcons[i].Image = Properties.Resources.Rainy;
                }
                if (Convert.ToInt16(Form1.days[i].weatherType) > 800)
                {
                    BackGroundLabels[i].BackColor = Color.Thistle;
                    weatherIcons[i].Image = Properties.Resources.Clouds;
                }

            }

            date1.Text = "Today";
            min1.Text = Math.Round(Convert.ToDouble(Form1.days[0].tempLow)).ToString("0") + "°";
            max1.Text = Math.Round(Convert.ToDouble(Form1.days[0].tempHigh)).ToString("0") + "°";


            date2.Text = Form1.days[1].dow;
            min2.Text = Math.Round(Convert.ToDouble(Form1.days[1].tempLow)).ToString("0") + "°";
            max2.Text = Math.Round(Convert.ToDouble(Form1.days[1].tempHigh)).ToString("0") + "°";

            date3.Text = Form1.days[2].dow;
            min3.Text = Math.Round(Convert.ToDouble(Form1.days[2].tempLow)).ToString("0") + "°";
            max3.Text = Math.Round(Convert.ToDouble(Form1.days[2].tempHigh)).ToString("0") + "°";

            date4.Text = Form1.days[3].dow;
            min4.Text = Math.Round(Convert.ToDouble(Form1.days[3].tempLow)).ToString("0") + "°";
            max4.Text = Math.Round(Convert.ToDouble(Form1.days[3].tempHigh)).ToString("0") + "°";

            date5.Text = Form1.days[4].dow;
            min5.Text = Math.Round(Convert.ToDouble(Form1.days[4].tempLow)).ToString("0") + "°";
            max5.Text = Math.Round(Convert.ToDouble(Form1.days[4].tempHigh)).ToString("0") + "°";

            date6.Text = Form1.days[5].dow;
            min6.Text = Math.Round(Convert.ToDouble(Form1.days[5].tempLow)).ToString("0") + "°";
            max6.Text = Math.Round(Convert.ToDouble(Form1.days[5].tempHigh)).ToString("0") + "°";

            date7.Text = Form1.days[6].dow;
            min7.Text = Math.Round(Convert.ToDouble(Form1.days[6].tempLow)).ToString("0") + "°";
            max7.Text = Math.Round(Convert.ToDouble(Form1.days[6].tempHigh)).ToString("0") + "°";

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CurrentScreen cs = new CurrentScreen();
            f.Controls.Add(cs);
        }

        private void weatherIcon1_Click(object sender, EventArgs e)
        {

        }

        private void weatherIcon2_Click(object sender, EventArgs e)
        {

        }

        private void weatherIcon3_Click(object sender, EventArgs e)
        {

        }

        private void weatherIcon4_Click(object sender, EventArgs e)
        {

        }

        private void weatherIcon5_Click(object sender, EventArgs e)
        {

        }

        private void weatherIcon6_Click(object sender, EventArgs e)
        {

        }
    }
}
      