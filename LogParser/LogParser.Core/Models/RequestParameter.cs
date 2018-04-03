namespace LogParser.Core.Models
{
    public class RequestParameter
    {
        public int Id { get; set; }

        public string ParameterName { get; set; }

        public string ParameterValue { get; set; }

        public Request Request { get; set; }
    }
}