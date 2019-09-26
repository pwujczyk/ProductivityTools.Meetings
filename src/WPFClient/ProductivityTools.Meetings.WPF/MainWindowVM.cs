using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProductivityTools.Meetings.WPF
{
    class MainWindowVM
    {
        IView View;
        private DelegateCommand selectMeetingList;

        public MainWindowVM(IView view)
        {
            View = view;
        }

        public DelegateCommand SelectMeetingList
        {
            get { return this.selectMeetingList; }
        }

       
    }
}
