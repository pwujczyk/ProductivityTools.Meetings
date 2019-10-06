using ProductivityTools.Meetings.WPF.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTools.Meetings.WPF.MeetingListGroup
{
    class MeetingListVM
    {
        IView View;

        public MeetingListVM(IView view)
        {
            View = view;
        }

        public List<MeetingView> MeetingList
        {
            get
            {
                List<MeetingView> items = new List<MeetingView>();
                items.Add(new MeetingView() { BeforeNotes = "Complete this WPF tutorial" });
                items.Add(new MeetingView() { BeforeNotes = "Learn C#" });
                items.Add(new MeetingView() { BeforeNotes = "Wash the car" });
                return items;
            }
        }
    }
}
