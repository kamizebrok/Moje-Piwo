using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Moje_Piwo.ViewModel
{

    public class ElementClickCommand : ICommand
    {
        private Action<object> execute;

        public ElementClickCommand(Action<object> execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            // Add your own logic here if needed
            return true;
        }

        public void Execute(object parameter)
        {
            execute?.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }

}
