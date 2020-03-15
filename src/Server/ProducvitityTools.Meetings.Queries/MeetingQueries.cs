using ProductivityTools.Meetings.Database;
using ProductivityTools.Meetings.Database.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProducvitityTools.Meetings.Queries
{
    public class MeetingQueries : IMeetingQueries
    {
        MeetingContext MeetingContext;

        public MeetingQueries(MeetingContext context)
        {
            this.MeetingContext = context;
        }

        public List<Meeting> GetMeetings()
        {
            var result = this.MeetingContext.Meeting.OrderByDescending(x=>x.Date).Take(10).ToList();
            return result;
        }
    }
}
