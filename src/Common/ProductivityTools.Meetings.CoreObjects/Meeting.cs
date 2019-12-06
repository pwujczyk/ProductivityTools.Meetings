using System;

namespace ProductivityTools.Meetings.CoreObjects
{
    public class Meeting
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string BeforeNotes { get; set; }
        public string Notes { get; set; }
        public string AfterNotes { get; set; }
    }
}
