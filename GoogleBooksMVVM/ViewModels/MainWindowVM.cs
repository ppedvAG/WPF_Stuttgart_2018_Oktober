using MVVMHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GoogleBooksMVVM.ViewModels
{
    public class MainWindowVM
    {

        public DelegateCommand PageSelectorCommand { get; set; }

        //TODO: Back-Button

        public MainWindowVM()
        {
            PageSelectorCommand = new DelegateCommand(SelectPage);
        }

        public void SelectPage(object parameter)
        {
            if (parameter is PageTypes type)
            {
                NavigationManager.NavigateTo(type,null);
            }
        }
    }
}
