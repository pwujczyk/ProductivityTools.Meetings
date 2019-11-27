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
            var database = new CreateSQLServerDatabase.Database("PTMeetings", connectionString);
            database.CreateSilent();
        }

        public void Upgrate()
        {
            CreateDatabase();
        }
    }
}
