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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductivityTools.Meetings.WpfClient.Controls.MeetingItem
{
    /// <summary>
    /// Interaction logic for MeetingItemControl.xaml
    /// </summary>
    public partial class MeetingItemControl : UserControl
    {
        public MeetingItemControl()
        {
            InitializeComponent();
        }

        #region BeforeNotes
        private void OnBeforeChanged(DependencyPropertyChangedEventArgs e)
        {
            this.BeforeNotesControl.Text = e.NewValue.ToString();
        }

        private static void OnBeforeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            MeetingItemControl control = obj as MeetingItemControl;
            control.OnBeforeChanged(e);
        }

        public static readonly DependencyProperty BeforeProperty =
            DependencyProperty.Register("Before", typeof(string), typeof(MeetingItemControl), new PropertyMetadata("", OnBeforeChanged));

        public string Before
        {
            get { return (string)GetValue(BeforeProperty); }
            set { SetValue(BeforeProperty, value); }
        }
        #endregion

        #region Notes
        private void OnNotesChanged(DependencyPropertyChangedEventArgs e)
        {
            this.NotesControl.Text = e.NewValue.ToString();
        }

        private static void OnNotesChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            MeetingItemControl meetingItemControl = obj as MeetingItemControl;
            meetingItemControl.OnNotesChanged(e);
        }

        public static readonly DependencyProperty NotesProperty =
            DependencyProperty.Register("Notes", typeof(string), typeof(MeetingItemControl), new PropertyMetadata("", OnNotesChanged));

        public string Notes
        {
            get { return (string)GetValue(NotesProperty); }
            set { SetValue(NotesProperty, value); }
        }
        #endregion

        #region AfterNotes
        private void OnAfterNotesChanged(DependencyPropertyChangedEventArgs e)
        {
            this.AfterNotesControl.Text = e.NewValue.ToString();
        }

        private static void OnAfterNotesChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            MeetingItemControl control = obj as MeetingItemControl;
            control.OnAfterNotesChanged(e);
        }

        public static readonly DependencyProperty AfterNotesProperty =
            DependencyProperty.Register("After", typeof(string), typeof(MeetingItemControl), new PropertyMetadata("", OnAfterNotesChanged));

        public string After
        {
            get { return (string)GetValue(AfterNotesProperty); }
            set { SetValue(AfterNotesProperty, value); }

        }
        #endregion
    }
}
    