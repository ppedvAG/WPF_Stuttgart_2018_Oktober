using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMHelper
{
    public class DelegateCommand : ICommand
    {
        //Delegate-Datentypen
        public delegate void ExecuteDelegate(object parameter);
        public delegate bool CanExecuteDelegate(object parameter);

        //Generische Delegate-Typen: https://docs.microsoft.com/de-de/dotnet/csharp/programming-guide/generics/generic-delegates
        //private Action<object> _execMeth;
        //private Func<object, bool> _canExecMeth;

        private ExecuteDelegate _execMethod;
        private CanExecuteDelegate _canExecMethod;

        public DelegateCommand(ExecuteDelegate execMethod, CanExecuteDelegate canExecMethod = null)
        {
            _execMethod = execMethod;
            _canExecMethod = canExecMethod;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {

            //Wenn keine CanExecute-Logik mitgegeben wurde, immer true zurückgeben
            if (_canExecMethod == null)
                return true;
            return _canExecMethod(parameter);
        }

        public void Execute(object parameter)
        {
            _execMethod?.Invoke(parameter);    
        }
    }
}
