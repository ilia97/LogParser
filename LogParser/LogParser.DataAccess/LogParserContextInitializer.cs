using System.Data.Entity;

namespace LogParser.DataAccess
{
    class LogParserContextInitializer : CreateDatabaseIfNotExists<LogParserContext>
    {
        protected override void Seed(LogParserContext db)
        {
            
        }
    }
}
