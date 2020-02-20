using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.Meetings.DatabaseMigrations.Migrations
{
    [Migration(20200217)]
    class CreateMeetingsTable : Migration
    {
        public override void Down()
        {
            Create.Table("Meetings")
                .WithColumn("MeetingId").AsInt32().Identity().PrimaryKey()
                .WithColumn("Date").AsDateTime().NotNullable()
                .WithColumn("Subject").AsString(200).NotNullable()
                .WithColumn("BeforeNotes").AsString(2000);
        }

        public override void Up()
        {
            throw new NotImplementedException();
        }
    }
}
