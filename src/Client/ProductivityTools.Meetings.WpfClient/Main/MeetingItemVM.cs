    using ProductivityTools.Meetings.CoreObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ProductivityTools.Meetings.WpfClient;

namespace ProductivityTools.Meetings.WpfClient.Controls.MeetingItem
{
    public class MeetingItemVM
    {
        public Meeting Meeting { get; set; }
        public ICommand EditMeetingCommand { get; }
        public ICommand SaveMeetingCommand { get; } 
        
        public string GG { get; set; }
        
        public MeetingItemVM(Meeting meeting)
        {
            this.Meeting = meeting;
            this.Meeting.BeforeNotes = "Before notes pawel";
            EditMeetingCommand = new CommandHandler(EditMeetingClick, () => true);
            SaveMeetingCommand = new CommandHandler(SaveMeetingClick, () => true);
        }

        private void EditMeetingClick()
        {
            EditMeeting editMeetingWindow = new EditMeeting(Meeting);
            editMeetingWindow.ShowDialog();
        }

        private void SaveMeetingClick()
        {

        }
    }
}
