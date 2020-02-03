﻿using ProductivityTools.Meetings.CoreObjects;
using ProductivityTools.Meetings.WpfClient.Controls.MeetingItem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProductivityTools.Meetings.WpfClient.Controls
{
    /// <summary>
    /// Interaction logic for EditMeeting.xaml
    /// </summary>
    public partial class EditMeeting : Window
    {
        public EditMeeting()
        {
            InitializeComponent();
        }

        public EditMeeting(Meeting meeting) : this()
        {
            this.DataContext = new EditMeetingVM(meeting);
        }
    }
}
