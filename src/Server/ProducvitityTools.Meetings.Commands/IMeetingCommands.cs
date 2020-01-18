using System;
using System.Collections.Generic;
using System.Text;
using ProductivityTools.Meetings.Database.Objects;

namespace ProducvitityTools.Meetings.Commands
{
    public interface IMeetingCommands
    {
        void Save(Meeting meeting);
    }
}
