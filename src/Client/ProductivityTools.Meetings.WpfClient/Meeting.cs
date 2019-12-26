using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.Meetings.WpfClient
{
    public class Meeting
    {
        public int MeetingId { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string BeforeNotes { get; set; }
        public string DuringNotes { get; set; }
        public string AfterNotes { get; set; }
    }
}
