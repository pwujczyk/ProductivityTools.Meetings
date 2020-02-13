using System;

namespace ProductivityTools.Meetings.CoreObjects
{
    public class Meeting
    {
        public int? MeetingId { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string BeforeNotes { get; set; }
        public string DuringNotes { get; set; }
        public string AfterNotes { get; set; }

        public Meeting()
        {
            //pw: date provider
            this.Date = DateTime.Now;
        }
    }
}
