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

        public string GG { get; set; }


        public EditMeetingVM(Meeting meetingItemVM)
        {
            this.Meeting = meetingItemVM;
            this.GG = "GG";
            SaveMeetingCommand = new CommandHandler(SaveMeetingClick, () => true);
        }

        private void SaveMeetingClick()
        {
           // throw new NotImplementedException();
        }
    }
}
