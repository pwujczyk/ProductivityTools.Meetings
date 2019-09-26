using ProductivityTools.Meetings.WPF.MeetingListGroup;
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

namespace ProductivityTools.Meetings.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,IView
    {
        public MainWindow()
        {
            InitializeComponent();

            
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Content = new MeetingList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Content = new NewMeeting();
        }
    }
}
