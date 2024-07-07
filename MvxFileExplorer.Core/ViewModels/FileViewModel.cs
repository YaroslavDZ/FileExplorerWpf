using MvvmCross.ViewModels;
using MvxFileExplorer.Core.Models;
using System.Collections.ObjectModel;

namespace MvxFileExplorer.Core.ViewModels
{
    public class FileViewModel : MvxViewModel
    {
        public MvxObservableCollection<DirectoryItemModel> _items {  get; set; } = new MvxObservableCollection<DirectoryItemModel>();

    }
}
