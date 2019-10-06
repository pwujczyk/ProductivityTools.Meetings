using System;

namespace ProductivityTools.Meetings.DBFluentMigrator
{
    public class DBMigration
    {
        private void CreateDatabase()
        {
            var database=new CreateSQLServerDatabase.Database("PTMeetings")
        }

        public void Upgrate()
        {

        }
    }
}
