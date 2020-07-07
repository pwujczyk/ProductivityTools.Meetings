using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ProductivityTools.Meetings.WpfClient
{
    public class CommandHandler : ICommand
    {
        private Action action;
        private Action<object> actiono;
        private Func<bool> canExecute;
        private object parameter;
        public CommandHandler(Action action, Func<bool> canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public CommandHandler(Action<object> action, Func<bool> canExecute)
        {
            this.actiono = action;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return canExecute();
        }

        public void Execute(object parameter)
        {
            if (action != null)
            {
                action();
            }
            else
            {
                actiono(parameter);
            }
        }
    }
}
