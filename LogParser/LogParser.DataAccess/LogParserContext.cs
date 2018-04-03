using System.Data.Entity;
using LogParser.DataAccess.Entities;

namespace LogParser.DataAccess
{
    public class LogParserContext : DbContext
    {
        public DbSet<RequestEntity> Requests { get; set; }

        public DbSet<RequestParameterEntity> RequestParameters { get; set; }

        public DbSet<ServerEntity> Servers { get; set; }

        public LogParserContext()
            : base("LogParserConnection")
        {
        }

        static LogParserContext()
        {
            Database.SetInitializer(new LogParserContextInitializer());
        }

        public static LogParserContext Create()
        {
            return new LogParserContext();
        }
    }
}
