using System;
using System.Collections.Generic;

namespace MyWeather.Models
{
    public partial class WeatherRecord
    {
        public int RecordId { get; set; }
        public string Area { get; set; }
        public string Forecast { get; set; }
        public DateTime SqlStartTime { get; set; }
        public DateTime SqlEndTime { get; set; }
    }
}
