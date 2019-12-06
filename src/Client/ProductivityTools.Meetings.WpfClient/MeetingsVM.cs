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
            this.Meetings.Add(new Meeting() { Title = "Title1", Date=DateTime.Now, BeforeNotes = "Before1", Notes = "Notes1", AfterNotes = "" });
            this.Meetings.Add(new Meeting() { Title = "Title2", Date = DateTime.Now.AddDays(1), BeforeNotes = "Before2", Notes = "Notes2", AfterNotes = "After2" });
            this.Meetings.Add(new Meeting() { Title = "Title3", Date = DateTime.Now.AddDays(2), BeforeNotes = "Before3", Notes = "Notes3", AfterNotes = "After3" });
            this.Meetings.Add(new Meeting() { Title = "Title4", Date = DateTime.Now.AddDays(3), BeforeNotes = "Before4", Notes = "Notes4", AfterNotes = "After4" });
            this.Meetings.Add(new Meeting() { Title = "Title1", Date = DateTime.Now, BeforeNotes = "Before1", Notes = "Notes1", AfterNotes = "" });
            this.Meetings.Add(new Meeting() { Title = "Title2", Date = DateTime.Now.AddDays(1), BeforeNotes = "Before2", Notes = "Notes2", AfterNotes = "After2" });
            this.Meetings.Add(new Meeting() { Title = "Title3", Date = DateTime.Now.AddDays(2), BeforeNotes = "Before3", Notes = "Notes3", AfterNotes = "After3" });
            this.Meetings.Add(new Meeting() { Title = "Title4", Date = DateTime.Now.AddDays(3), BeforeNotes = "Before4", Notes = "Notes4", AfterNotes = "After4" });
        }
    }
}
