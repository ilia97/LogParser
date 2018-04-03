using System;
using System.Collections.Generic;

namespace LogParser.Core.Models
{
    public class Request
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Url { get; set; }

        public string Result { get; set; }

        public int Size { get; set; }
        
        public Server Server { get; set; }

        public List<RequestParameter> RequestParameters { get; set; }

        public Request()
        {
            RequestParameters = new List<RequestParameter>();
        }
    }
}
