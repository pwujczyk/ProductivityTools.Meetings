using IdentityModel.Client;
using ProductivityTools.Meetings.ClientCaller;
using ProductivityTools.Meetings.WpfClient.Automapper;
using ProductivityTools.Meetings.WpfClient.Controls;
using ProductivityTools.Meetings.WpfClient.Controls.MeetingItem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;

namespace ProductivityTools.Meetings.WpfClient
{
    public class MeetingsVM
    {
        public ObservableCollection<MeetingItemVM> Meetings { get; set; }

        public ICommand GetMeetingsCommand { get; }
        public ICommand NewMeetingCommand { get; }
        public ICommand LoginCommand { get; }
        public string Secret { get; set; }


        public MeetingsVM()
        {
            this.Meetings = new ObservableCollection<MeetingItemVM>();
            GetMeetingsCommand = new CommandHandler(GetMeetings, () => true);
            NewMeetingCommand = new CommandHandler(NewMeeting, () => true);
            this.Meetings.Add(new MeetingItemVM(new CoreObjects.Meeting() { AfterNotes = "Core", BeforeNotes = "Core", DuringNotes = "Core", Subject = "fdsa" }));
            this.Meetings.Add(new MeetingItemVM(new CoreObjects.Meeting() { AfterNotes = "Core", BeforeNotes = "Core", DuringNotes = "Core" }));
        }

        private async void GetMeetings()
        {
            MeetingsClient client = new MeetingsClient(this.Secret);
            try
            {
                var xx = await client.GetMeetings();
                var tree = await client.GetTree();
                this.Meetings.Clear();
                foreach (var item in xx)
                {
                    var meeting = new MeetingItemVM(item);
                    this.Meetings.Add(meeting);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void NewMeeting()
        {
            var meeting = new CoreObjects.Meeting();
            var meetingvm = new MeetingItemVM(meeting);
            this.Meetings.Add(meetingvm);
            EditMeeting edit = new EditMeeting(meeting);
            edit.Show();

        }
    }
}
