using MvvmCross.ViewModels;
using MvxFileExplorer.Core.Models;
using System.Collections.ObjectModel;

namespace MvxFileExplorer.Core.ViewModels
{
    public class FileListViewModel : MvxViewModel
    {
        public MvxObservableCollection<DirectoryItemViewModel> _items {  get; set; } = new MvxObservableCollection<DirectoryItemViewModel>();

    }
}
