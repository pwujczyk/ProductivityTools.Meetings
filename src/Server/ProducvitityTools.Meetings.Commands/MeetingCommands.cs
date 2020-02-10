using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProductivityTools.Meetings.Database;
using ProductivityTools.Meetings.Database.Objects;

namespace ProducvitityTools.Meetings.Commands
{
    public class MeetingCommands : IMeetingCommands
    {
        MeetingContext MeetingContext;

        public MeetingCommands(MeetingContext context)
        {
            this.MeetingContext = context;
        }

        void IMeetingCommands.Save(Meeting meeting)
        {
            MeetingContext.Meeting.Attach(meeting);
            MeetingContext.Entry(meeting).State = EntityState.Modified;

            var ChangeTracker = MeetingContext.ChangeTracker;

            var addedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Added).ToList();
            var modifiedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified).ToList();
            var deletedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted).ToList();


            MeetingContext.SaveChanges();
        }
    }
}
