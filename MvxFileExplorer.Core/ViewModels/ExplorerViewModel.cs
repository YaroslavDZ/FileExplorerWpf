using MvvmCross.ViewModels;
using MvxFileExplorer.Core.Commands;
using MvxFileExplorer.Core.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvxFileExplorer.Core.ViewModels
{
    public class ExplorerViewModel : MvxViewModel
    {
        public DirectoryViewModel DirectoryViewModel { get; set; }

        public FileViewModel FileViewModel { get; set; }

        public ICommand NavigateChartCommand { get; private set; }

        public ExplorerViewModel(NavigationStore navigationStore)
        {
            DirectoryViewModel = new DirectoryViewModel(new Models.DirectoryItemModel("C\\", "C:\\"));
            FileViewModel = new FileViewModel();

            NavigateChartCommand = new NavigateChartCommand(navigationStore);
        }
    }
}
