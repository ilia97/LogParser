using System;
using System.Collections.Generic;

namespace LogParser.API.ViewModels.Log
{
    public class LogsViewModel
    {
        public DateTime Date { get; set; }

        public string Url { get; set; }

        public string Result { get; set; }

        public int Size { get; set; }

        public string IpAddress { get; set; }

        public string Geolocation { get; set; }

        public Dictionary<string, string> RequestParameters { get; set; }

        public LogsViewModel()
        {
            RequestParameters = new Dictionary<string, string>();
        }
    }
}