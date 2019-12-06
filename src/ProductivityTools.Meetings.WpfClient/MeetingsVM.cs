using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.Meetings.WpfClient
{
    public class MeetingsVM
    {
        public List<Meeting> Meetings { get; set; }

        public MeetingsVM()
        {
            this.Meetings= new List<Meeting>();
            this.Meetings.Add(new Meeting() { Notes = "xxx1" });
            this.Meetings.Add(new Meeting() { Notes = "xxx2" });
            this.Meetings.Add(new Meeting() { Notes = "xxx3" });
            this.Meetings.Add(new Meeting() { Notes = "xxx4" });
        }
    }
}
