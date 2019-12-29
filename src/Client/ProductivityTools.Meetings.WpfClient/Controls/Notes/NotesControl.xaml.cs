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

namespace ProductivityTools.Meetings.WpfClient.Controls.Notes
{
    public partial class NotesControl : UserControl
    {
        public NotesControl()
        {
            InitializeComponent();
        }

        public NotesVisibility NotesVisibility
        {
            get { return (NotesVisibility)GetValue(NotesVisibilityProperty); }
            set { SetValue(NotesVisibilityProperty, value); }
        }

        public static readonly DependencyProperty NotesVisibilityProperty =
            DependencyProperty.Register("NotesVisibility", typeof(NotesVisibility), typeof(NotesControl), new PropertyMetadata(NotesVisibility.CollapsedWhenEmpty));


        #region label
        public static readonly DependencyProperty SetLabelProperty =
         DependencyProperty.Register("Label", typeof(string), typeof(NotesControl), new PropertyMetadata("", new PropertyChangedCallback(OnSetLabelChanged)));

        public string Label
        {
            get { return (string)GetValue(SetLabelProperty); }
            set { SetValue(SetLabelProperty, value); }
        }

        private static void OnSetLabelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NotesControl notesControl = d as NotesControl;
            notesControl.OnLabelChanged(e);
        }

        private void OnLabelChanged(DependencyPropertyChangedEventArgs e)
        {
            LabelControl.Content = e.NewValue.ToString();
        }
        #endregion

        #region Text
        public static readonly DependencyProperty SetTextProperty = DependencyProperty.Register("Text", typeof(string), typeof(NotesControl), new PropertyMetadata("", new PropertyChangedCallback(OnSetTextChanged)));

        public string Text
        {
            get { return (string)GetValue(SetTextProperty); }
            set
            {
                SetValue(SetTextProperty, value);
                if (string.IsNullOrWhiteSpace(value))
                {
                    this.Visibility = Visibility.Collapsed;
                }
                else
                {
                    this.Visibility = Visibility.Visible;
                }
            }
        }

        private static void OnSetTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NotesControl notesControl = d as NotesControl;
            notesControl.OnSetTextChanged(e);
        }

        private void OnSetTextChanged(DependencyPropertyChangedEventArgs e)
        {
            Notes.Text = e.NewValue?.ToString();
        }
        #endregion
    }
}
