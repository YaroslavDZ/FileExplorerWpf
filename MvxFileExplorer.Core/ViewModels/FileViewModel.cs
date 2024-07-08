using MvvmCross.ViewModels;
using MvxFileExplorer.Core.Commands;
using MvxFileExplorer.Core.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MvxFileExplorer.Core.ViewModels
{
    public class FileViewModel : MvxViewModel
    {
        public MvxObservableCollection<DirectoryItemModel> Items {  get; set; } = new MvxObservableCollection<DirectoryItemModel>();

        public FileViewModel(DirectoryViewModel directoryViewModel)
        {
        }
    }
}
