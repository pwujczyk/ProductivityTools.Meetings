﻿using ProductivityTools.Meetings.CoreObjects;
using System.Collections.Generic;

namespace ProductivityTools.Meetings.Services
{
    public interface IMeetingService
    {
        List<Meeting> GetMeetings(int? treeNodeId, bool drillDown);
        void DeleteMeeting(int meetingId);
    }
}