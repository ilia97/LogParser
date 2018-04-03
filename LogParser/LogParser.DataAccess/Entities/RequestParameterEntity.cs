using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogParser.DataAccess.Entities
{
    public class RequestParameterEntity
    {
        [Key]
        public int Id { get; set; }

        public string ParameterName { get; set; }

        public string ParameterValue { get; set; }
        
        public int RequestId { get; set; }

        public virtual RequestEntity Request { get; set; }
    }
}
