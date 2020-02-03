using ProductivityTools.Meetings.WpfClient.Controls.Notes;
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
        }


        #region EditCommand
        public ICommand Edit
        {
            get { return (ICommand)GetValue(EditProperty); }
            set { SetValue(EditProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Edit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditProperty =
            DependencyProperty.Register("Edit", typeof(ICommand), typeof(MeetingItemControl));
        #endregion

        #region SaveCommand


        public ICommand Save
        {
            get { return (ICommand)GetValue(SaveProperty); }
            set { SetValue(SaveProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Save.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SaveProperty =
            DependencyProperty.Register("Save", typeof(ICommand), typeof(MeetingItemControl));


        #endregion


        #region BeforeNotes
        public static readonly DependencyProperty BeforeNotesProperty =
            DependencyProperty.Register("BeforeNotes", typeof(string), typeof(MeetingItemControl));

        public string BeforeNotes
        {
            get { return (string)GetValue(BeforeNotesProperty); }
            set { SetValue(BeforeNotesProperty, value); }
        }
        #endregion

        #region DuringNotes

        public static readonly DependencyProperty DuringNotesProperty =
            DependencyProperty.Register("DuringNotes", typeof(string), typeof(MeetingItemControl));

        public string DuringNotes
        {
            get { return (string)GetValue(DuringNotesProperty); }
            set { SetValue(DuringNotesProperty, value); }
        }
        #endregion

        #region AfterNotes
        public static readonly DependencyProperty AfterNotesProperty =
            DependencyProperty.Register("AfterNotes", typeof(string), typeof(MeetingItemControl));

        public string AfterNotes
        {
            get { return (string)GetValue(AfterNotesProperty); }
            set
            {
                SetValue(AfterNotesProperty, value);
            }

        }
        #endregion

        #region Meeting Id
        private static readonly DependencyProperty MeetingIdProperty =
            DependencyProperty.Register("Id", typeof(string), typeof(MeetingItemControl));

        public string Id
        {
            get { return (string)GetValue(MeetingIdProperty); }
            set { SetValue(MeetingIdProperty, value); }
        }

        #endregion

        #region Meeting subject
        private static readonly DependencyProperty MeetingSubjectProperty =
            DependencyProperty.Register("Subject", typeof(string), typeof(MeetingItemControl));

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

        #region ReadOnly
        public bool ReadOnly
        {
            get { return (bool)GetValue(ReadOnlyProperty); }
            set { SetValue(ReadOnlyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReadOnlyProperty =
            DependencyProperty.Register("ReadOnly", typeof(bool), typeof(MeetingItemControl), new PropertyMetadata(true, OnReadOnlyChanged));


        private void OnReadOnlyChanged(DependencyPropertyChangedEventArgs e)
        {
            var @readonly = (bool)e.NewValue;
            NotesVisibility visibility = @readonly ? NotesVisibility.CollapsedWhenEmpty : NotesVisibility.AlwaysVisible;
            //this.AfterNotesControl.NotesVisibility =
           //this.BeforeNotesControl.NotesVisibility =
           // this.DuringNotesControl.NotesVisibility = visibility;
            this.SaveMeeting.Visibility = @readonly ? Visibility.Hidden : Visibility.Visible;
            this.EditMeeting.Visibility = !@readonly ? Visibility.Hidden : Visibility.Visible;
        }

        private static void OnReadOnlyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            MeetingItemControl control = obj as MeetingItemControl;
            control.OnReadOnlyChanged(e);
        }
        #endregion
    }
}
