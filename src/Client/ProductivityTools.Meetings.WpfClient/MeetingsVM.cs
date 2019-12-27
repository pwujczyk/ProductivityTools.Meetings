using ProductivityTools.Meetings.ClientCaller;
using ProductivityTools.Meetings.WpfClient.Automapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace ProductivityTools.Meetings.WpfClient
{
    public class MeetingsVM
    {
        public ObservableCollection<MeetingVM> Meetings { get; set; }

        public ICommand GetMeetingsCommand { get; }
        

        public MeetingsVM()
        {
            this.Meetings = new ObservableCollection<MeetingVM>();

            GetMeetingsCommand = new CommandHandler(GetMeetings, () => true);
        
            this.Meetings.Add(new MeetingVM() { Subject = "Title1", Date = DateTime.Now, BeforeNotes = "Before1", DuringNotes = "Notes1", AfterNotes = "" });

        }

        

        private async void GetMeetings()
        {
            MeetingsClient client = new MeetingsClient();
            var xx = await client.GetMeetings();

            foreach (var item in xx)
            {
                var meeting = AutoMapperConfiguration.Configuration.Map<ProductivityTools.Meetings.CoreObjects.Meeting, MeetingVM>(item);
                this.Meetings.Add(meeting);
            }
        }
    }
}
