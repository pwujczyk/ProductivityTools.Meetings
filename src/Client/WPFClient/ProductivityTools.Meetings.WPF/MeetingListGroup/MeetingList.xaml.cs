using ProductivityTools.Meetings.WPF.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductivityTools.Meetings.WPF.MeetingListGroup
{
    /// <summary>
    /// Interaction logic for MeetingList.xaml
    /// </summary>
    public partial class MeetingList : Page,IView
    {
        public MeetingList()
        {
            InitializeComponent();
            this.DataContext = new MeetingListVM(this);

        }
    }
}
