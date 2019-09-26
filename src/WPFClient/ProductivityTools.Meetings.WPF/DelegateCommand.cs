using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductivityTools.Meetings.WPF
{
    public class DelegateCommand : ICommand
    {
        public delegate void SimpleEventHandler(object sender, EventArgs e);
        private SimpleEventHandler handler;

        public event EventHandler CanExecuteChanged;
        private bool isEnabled = true;

        public DelegateCommand(SimpleEventHandler handler)
        {
            this.handler = handler;
        }

        public bool CanExecute(object parameter)
        {
            return this.IsEnabled;
        }

        public void Execute(object parameter)
        {
            this.handler(this, EventArgs.Empty);
        }

        public bool IsEnabled
        {
            get
            {
                return this.isEnabled;
            }
            set
            {
                this.isEnabled = value;
                this.OnCanExecuteChanged();
            }
        }

        private void OnCanExecuteChanged()
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
