using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.Meetings.WpfClient
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
