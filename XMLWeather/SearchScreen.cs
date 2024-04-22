using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class SearchScreen : UserControl
    {
        public SearchScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (searchBox.Text != null)
            {
                Form1.place = searchBox.Text;
                try
                {
                    Form1.days.Clear();
                    Form1.ExtractForecast();
                    Form1.ExtractCurrent();
                    Form1.ChangeScreen(this, new CurrentScreen());
                }
                catch
                {
                    searchBox.Text = "Bro, C'mon";
                }
                
            }
        }
    }
}
