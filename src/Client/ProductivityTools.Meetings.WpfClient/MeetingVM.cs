using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ProductivityTools.Meetings.WpfClient
{
    public class MeetingVM
    {


        public int MeetingId { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string BeforeNotes { get; set; }
        public string DuringNotes { get; set; }
        public string AfterNotes { get; set; }

        public ICommand EditMeetingCommand { get; }

        public MeetingVM()
        {
            EditMeetingCommand = new CommandHandler(EditMeetingClick, () => true);
        }

        private void EditMeetingClick()
        {
            EditMeeting editMeetingWindow = new EditMeeting(this);
            editMeetingWindow.ShowDialog();
        }
    }
}
