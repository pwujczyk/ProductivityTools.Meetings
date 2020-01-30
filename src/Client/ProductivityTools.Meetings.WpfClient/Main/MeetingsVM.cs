using ProductivityTools.Meetings.ClientCaller;
using ProductivityTools.Meetings.WpfClient.Automapper;
using ProductivityTools.Meetings.WpfClient.Controls.MeetingItem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace ProductivityTools.Meetings.WpfClient
{
    public class MeetingsVM
    {
        public ObservableCollection<MeetingItemVM> Meetings { get; set; }

        public ICommand GetMeetingsCommand { get; }
        

        public MeetingsVM()
        {
            this.Meetings = new ObservableCollection<MeetingItemVM>();
            GetMeetingsCommand = new CommandHandler(GetMeetings, () => true);
            this.Meetings.Add(new MeetingItemVM(new CoreObjects.Meeting() { AfterNotes = "Core", BeforeNotes="Core", DuringNotes="Core", Subject="fdsa" }));
            this.Meetings.Add(new MeetingItemVM(new CoreObjects.Meeting() { AfterNotes = "Core", BeforeNotes = "Core", DuringNotes = "Core" }));
        }

        private async void GetMeetings()
        {
            MeetingsClient client = new MeetingsClient();
            var xx = await client.GetMeetings();
           // await client.SaveMeeting(new CoreObjects.Meeting() { AfterNotes = "after" });

            foreach (var item in xx)
            {
                var meeting = new MeetingItemVM(item);
                this.Meetings.Add(meeting);
            }
        }
    }
}
