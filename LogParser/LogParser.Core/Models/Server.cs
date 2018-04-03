using System.Collections.Generic;

namespace LogParser.Core.Models
{
    public class Server
    {
        public string IpAddress { get; set; }

        public string Geolocation { get; set; }

        public List<Request> Requests { get; set; }

        public Server()
        {
            Requests = new List<Request>();
        }
    }
}
