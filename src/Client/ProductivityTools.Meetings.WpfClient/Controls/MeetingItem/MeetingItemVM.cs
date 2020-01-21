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
        //public int MeetingId { get; set; }
        //public DateTime Date { get; set; }
        //public string Subject { get; set; }
        //public string BeforeNotes { get; set; }
        //public string DuringNotes { get; set; }
        //public string AfterNotes { get; set; }

        public ICommand EditMeetingCommand { get; }

        public MeetingItemVM(Meeting meeting)
        {
            this.Meeting = meeting;
            EditMeetingCommand = new CommandHandler(EditMeetingClick, () => true);
        }

        private void EditMeetingClick()
        {
            EditMeeting editMeetingWindow = new EditMeeting(this);
            editMeetingWindow.ShowDialog();
        }
    }
}
