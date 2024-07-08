using MvvmCross.Commands;
using MvxFileExplorer.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvxFileExplorer.Core.Commands
{
    public class SelectItemCommand : ICommand
    {
        public DirectoryViewModel DirectoryViewModel { get; set; }

        public event EventHandler? CanExecuteChanged;

        public SelectItemCommand(DirectoryViewModel directoryViewModel)
        {
            DirectoryViewModel = directoryViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            DirectoryViewModel.OpenItem();
        }
    }
}
