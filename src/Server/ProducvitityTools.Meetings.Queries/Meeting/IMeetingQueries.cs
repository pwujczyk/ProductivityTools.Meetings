using System.Collections.Generic;
using ProductivityTools.Meetings.Database.Objects;

namespace ProducvitityTools.Meetings.Queries
{
    public interface IMeetingQueries
    {
        List<Meeting> GetMeetings();
        List<Meeting> GetMeetings(int treeNodeId);
        Meeting GetMeeting(int id);
    }
}