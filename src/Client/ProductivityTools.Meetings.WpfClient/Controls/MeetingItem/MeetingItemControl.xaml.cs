using System;
using System.Collections.Generic;
using System.Globalization;
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
            this.AfterNotesControl.Visibility = Visibility.Collapsed;
        }


        #region BeforeNotes
        private void OnBeforeNotesChanged(DependencyPropertyChangedEventArgs e)
        {
            this.BeforeNotesControl.Text = e.NewValue?.ToString();
        }

        private static void OnBeforeNotesChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            MeetingItemControl control = obj as MeetingItemControl;
            control.OnBeforeNotesChanged(e);
        }

        public static readonly DependencyProperty BeforeNotesProperty =
            DependencyProperty.Register("BeforeNotes", typeof(string), typeof(MeetingItemControl), new PropertyMetadata("", OnBeforeNotesChanged));

        public string BeforeNotes
        {
            get { return (string)GetValue(BeforeNotesProperty); }
            set { SetValue(BeforeNotesProperty, value); }
        }
        #endregion

        #region DuringNotes
        private void OnDuringNotesChanged(DependencyPropertyChangedEventArgs e)
        {
            this.NotesControl.Text = e.NewValue?.ToString();
        }

        private static void OnDuringNotesChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            MeetingItemControl meetingItemControl = obj as MeetingItemControl;
            meetingItemControl.OnDuringNotesChanged(e);
        }

        public static readonly DependencyProperty DuringNotesProperty =
            DependencyProperty.Register("DuringNotes", typeof(string), typeof(MeetingItemControl), new PropertyMetadata("", OnDuringNotesChanged));

        public string DuringNotes
        {
            get { return (string)GetValue(DuringNotesProperty); }
            set { SetValue(DuringNotesProperty, value); }
        }
        #endregion

        #region AfterNotes
        private void OnAfterNotesChanged(DependencyPropertyChangedEventArgs e)
        {
            this.AfterNotesControl.Text = e.NewValue?.ToString();
        }

        private static void OnAfterNotesChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            MeetingItemControl control = obj as MeetingItemControl;
            control.OnAfterNotesChanged(e);
        }

        public static readonly DependencyProperty AfterNotesProperty =
            DependencyProperty.Register("AfterNotes", typeof(string), typeof(MeetingItemControl), new PropertyMetadata("", OnAfterNotesChanged));

        public string AfterNotes
        {
            get { return (string)GetValue(AfterNotesProperty); }
            set
            {
                SetValue(AfterNotesProperty, value);
                //if (string.IsNullOrEmpty(value))
                //{
                //    this.AfterNotesControl.Visibility = Visibility.Hidden;
                //}
            }

        }
        #endregion

        #region Meeting Id

        private void OnIdChanged(DependencyPropertyChangedEventArgs e)
        {
            this.MeetingIdControl.Text = e.NewValue?.ToString();
        }

        private static void OnIdChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            MeetingItemControl meetingItemControl = obj as MeetingItemControl;
            meetingItemControl.OnIdChanged(e);
        }

        private static readonly DependencyProperty MeetingIdProperty =
            DependencyProperty.Register("Id", typeof(string), typeof(MeetingItemControl), new PropertyMetadata("", OnIdChanged));

        public string Id
        {
            get { return (string)GetValue(MeetingIdProperty); }
            set { SetValue(MeetingIdProperty, value); }
        }

        #endregion

        #region Meeting subject

        private void OnSubjectChanged(DependencyPropertyChangedEventArgs e)
        {
            this.MeetingSubjectControl.Text = e.NewValue?.ToString();
        }

        private static void OnSubjectChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            MeetingItemControl meetingItemControl = obj as MeetingItemControl;
            meetingItemControl.OnSubjectChanged(e);
        }

        private static readonly DependencyProperty MeetingSubjectProperty =
            DependencyProperty.Register("Subject", typeof(string), typeof(MeetingItemControl), new PropertyMetadata("", OnSubjectChanged));

        public string Subject
        {
            get { return (string)GetValue(MeetingSubjectProperty); }
            set { SetValue(MeetingSubjectProperty, value); }
        }

        #endregion

        #region Date
        private void OnDateChanged(DependencyPropertyChangedEventArgs e)
        {
            DateTime dt = DateTime.Parse(e.NewValue.ToString());
            this.MeetingDateControl.Text = dt.ToString("dddd - yyyy.MM.dd", CultureInfo.InvariantCulture);
        }

        private static void OnDateChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            MeetingItemControl control = obj as MeetingItemControl;
            control.OnDateChanged(e);
        }

        private static readonly DependencyProperty DateChangeProperty =
            DependencyProperty.Register("Date", typeof(DateTime), typeof(MeetingItemControl), new PropertyMetadata(default(DateTime), OnDateChanged));

        public DateTime Date
        {
            get { return (DateTime)GetValue(DateChangeProperty); }
            set { SetValue(DateChangeProperty, value); }
        }
        #endregion


        #region EditButton
        //private void OnDateChanged(DependencyPropertyChangedEventArgs e)
        //{
        //    DateTime dt = DateTime.Parse(e.NewValue.ToString());
        //    this.MeetingDateControl.Text = dt.ToString("dddd - yyyy.MM.dd", CultureInfo.InvariantCulture);
        //}

        //private static void OnDateChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        //{
        //    MeetingItemControl control = obj as MeetingItemControl;
        //    control.OnDateChanged(e);
        //}

        private static readonly DependencyProperty EditClickedProperty =
            DependencyProperty.Register("EditClicked", typeof(ICommand), typeof(MeetingItemControl), new PropertyMetadata(null));

        public ICommand EditClicked
        {
            get
            {
                return (ICommand)GetValue(EditClickedProperty);
            }
            set
            {
                SetValue(EditClickedProperty, value);
            }
        }
        #endregion

    }
}
