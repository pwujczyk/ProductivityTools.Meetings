using System;
using System.Collections.Generic;
using System.Text;
using ProductivityTools.Meetings.Database.Objects;

namespace ProducvitityTools.Meetings.Commands
{
    public interface IMeetingCommands
    {
        int Save(Meeting meeting);
        void Update(Meeting meeting);
        void Delete(Meeting meetingId);
    }
}
