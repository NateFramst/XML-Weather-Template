using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;


//http://api.openweathermap.org/data/2.5/forecast/daily?q=Stratford,CA&mode=xml&units=metric&cnt=7&appid=3f2e224b815c0ed45524322e145149f0

namespace XMLWeather
{
    public partial class Form1 : Form
    {
        // TODO: create list to hold day objects

       public static string place = "Stratford, CA";

        public static List<Day> days = new List<Day>();
        public Form1()
        {
            InitializeComponent();

            ExtractForecast();
            ExtractCurrent();

            // open weather screen for todays weather
            CurrentScreen cs = new CurrentScreen();
            this.Controls.Add(cs);
        }

        public static void ExtractForecast()
        {
            XmlReader reader = XmlReader.Create("http://api.openweathermap.org/data/2.5/forecast/daily?q="+ place +"&mode=xml&units=metric&cnt=7&appid=3f2e224b815c0ed45524322e145149f0");

            while (reader.Read())
            {
                // create a day object
                Day d = new Day();

                // fill day object with required data

                d.location = reader.GetAttribute("name");

                reader.ReadToFollowing("time");
                d.date = reader.GetAttribute("day");

                reader.ReadToFollowing("sun");
                d.sunRise = reader.GetAttribute("rise");
                d.sunSet = reader.GetAttribute("set");

                reader.ReadToFollowing("symbol");
                d.weatherType = reader.GetAttribute("number");
                d.condition = reader.GetAttribute("name");

                reader.ReadToFollowing("temperature");
                d.tempLow = reader.GetAttribute("min");
                d.tempHigh = reader.GetAttribute("max");

                reader.ReadToFollowing("humidity");
                d.wetAir = reader.GetAttribute("value");

               d.dow = DateTime.Now.AddDays(days.Count).DayOfWeek.ToString();

                //TODO: if day object not null add to the days list

                days.Add(d);
            }


        }

       // "http://api.openweathermap.org/data/2.5/weather?q=Stratford,CA&mode=xml&units=metric&appid=3f2e224b815c0ed45524322e145149f0"

        public static void ExtractCurrent()
        {
            // current info is not included in forecast file so we need to use this file to get it
            XmlReader reader = XmlReader.Create("http://api.openweathermap.org/data/2.5/weather?q="+ place +"&mode=xml&units=metric&appid=3f2e224b815c0ed45524322e145149f0");

            //TODO: find the city and current temperature and add to appropriate item in days list

            reader.ReadToFollowing("city");


            days[0].location = reader.GetAttribute("name");

            reader.ReadToFollowing("timezone");
            days[0].timeZone = reader.ReadString();



            reader.ReadToFollowing("temperature");

            days[0].currentTemp = reader.GetAttribute("value");

        }

        public static void ChangeScreen(object sender, UserControl next)
        {
            Form form;
            if (sender is Form)
            {
                form = sender as Form;
            }
            else
            {
                UserControl currenet = sender as UserControl;
                form = currenet.FindForm();
                form.Controls.Remove(currenet);
            }

            next.Location = new Point((form.Width - next.Width) / 2, (form.Height - next.Height) / 2);

            form.Controls.Add(next);
        }



    }
}
