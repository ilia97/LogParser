using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LogParser.DataAccess.Entities
{
    public class ServerEntity
    {
        [Key]
        public string IpAddress { get; set; }

        public string Geolocation { get; set; }

        public virtual List<RequestEntity> Requests { get; set; }

        public ServerEntity()
        {
            Requests = new List<RequestEntity>();
        }
    }
}
