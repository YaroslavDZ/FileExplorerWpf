using MvvmCross.Commands;
using MvxFileExplorer.Core.Models;
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
        private readonly DirectoryItemModel _directoryItemModel;

        public NavigateChartCommand(NavigationStore navigationStore, DirectoryItemModel directoryItemModel)
        {
            _navigationStore = navigationStore;
            _directoryItemModel = directoryItemModel;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new ChartViewModel(_directoryItemModel, _navigationStore);
        }
    }
}
