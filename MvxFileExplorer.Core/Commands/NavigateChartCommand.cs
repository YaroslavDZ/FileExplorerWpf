using MvxFileExplorer.Core.Stores;
using MvxFileExplorer.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvxFileExplorer.Core.Commands
{
    public class NavigateChartCommand : ICommand
    {
        private readonly NavigationStore _navigationStore;

        public NavigateChartCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new ChartViewModel(new NavigationStore());
        }
    }
}
