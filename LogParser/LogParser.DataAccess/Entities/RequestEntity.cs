using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LogParser.DataAccess.Entities
{
    public class RequestEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Url { get; set; }

        public string Result { get; set; }

        public int Size { get; set; }

        public string ServerIpAddress { get; set; }

        public virtual ServerEntity Server { get; set; }

        public virtual List<RequestParameterEntity> RequestParameters { get; set; }

        public RequestEntity()
        {
            RequestParameters = new List<RequestParameterEntity>();
        }
    }
}
