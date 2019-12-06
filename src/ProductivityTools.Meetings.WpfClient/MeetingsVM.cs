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
            this.Meetings = new List<Meeting>();
            this.Meetings.Add(new Meeting() { BeforeNotes = "Before1", Notes = "Notes1", AfterNotes = "After1" });
            this.Meetings.Add(new Meeting() { BeforeNotes = "Before2", Notes = "Notes2", AfterNotes = "After2" });
            this.Meetings.Add(new Meeting() { BeforeNotes = "Before3", Notes = "Notes3", AfterNotes = "After3" });
            this.Meetings.Add(new Meeting() { BeforeNotes = "Before4", Notes = "Notes4", AfterNotes = "After4" });
        }
    }
}
