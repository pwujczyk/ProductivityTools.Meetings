using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace ProductivityTools.Meetings.DBFluentMigrator
{
    public class DBMigration
    {
        private readonly IConfiguration configuration;

        public DBMigration(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private void CreateDatabase()
        {
            string connectionString = configuration.GetConnectionString("PTMeetings");
            var parts = connectionString.Split(';');
            var serverConnectionString = parts.Where(x => !x.Contains("Database")).Aggregate((current,next)=>current+";"+next);
            var database = new CreateSQLServerDatabase.Database("PTMeetings", serverConnectionString);
            database.CreateSilent();
        }

        public void Upgrate()
        {
            CreateDatabase();
        }
    }
}
