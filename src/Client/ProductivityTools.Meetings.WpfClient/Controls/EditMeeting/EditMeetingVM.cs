using ProductivityTools.Meetings.ClientCaller;
using ProductivityTools.Meetings.CoreObjects;
using ProductivityTools.Meetings.WpfClient.Controls.MeetingItem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ProductivityTools.Meetings.WpfClient.Controls
{
    public class EditMeetingVM
    {
        public Meeting Meeting { get; set; }
        public ICommand SaveMeetingCommand { get; }

        public EditMeetingVM(Meeting meeting)
        {
            this.Meeting = meeting;
            SaveMeetingCommand = new CommandHandler(SaveMeetingClick, () => true);
        }

        private async void SaveMeetingClick()
        {
            MeetingsClient client = new MeetingsClient();
            await client.SaveMeeting(this.Meeting);
        }
    }
}
