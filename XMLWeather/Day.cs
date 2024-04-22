using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLWeather
{
    public class Day
    {
        public string date, dow, weatherType, currentTemp, currentTime, condition, location, tempHigh, tempLow, 
            windSpeed, windDirection, precipitation, visibility, sunRise, sunSet, wetAir, timeZone;



        public Day()
        {
            date = currentTemp = dow = wetAir = weatherType = sunRise = sunSet = timeZone = currentTime = condition = location = tempHigh = tempLow
                = windSpeed = windDirection = precipitation = visibility = "";
        }
    }
}
