using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ProductivityTools.Meetings.WpfClient
{
    public class Meeting
    {


        public int MeetingId { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string BeforeNotes { get; set; }
        public string DuringNotes { get; set; }
        public string AfterNotes { get; set; }

        public ICommand EditMeetingCommand { get; }

        public Meeting()
        {
            EditMeetingCommand = new CommandHandler(EditMeetingClick, () => true);
        }

        private void EditMeetingClick()
        {

        }
    }
}
