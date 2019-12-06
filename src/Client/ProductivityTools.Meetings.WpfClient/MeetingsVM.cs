using ProductivityTools.SimpleHttpPostClient;
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
            this.Meetings.Add(new Meeting() { Title = "Title1", Date = DateTime.Now, BeforeNotes = "Before1", Notes = "Notes1", AfterNotes = "" });
        }

        public async void UpdateMeetings()
        {
            HttpPostClient client = new HttpPostClient();
            client.SetBaseUrl("https://localhost:44366/Api");
            client.EnableLogging();
            var xx = client.Post<string>("Meetings", "Test").Result;

            var meetings = await client.Post<List<Meeting>>("Meetings", "Get");

            this.Meetings = meetings;
        }
    }
}
