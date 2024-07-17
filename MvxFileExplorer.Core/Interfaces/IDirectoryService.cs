using MvvmCross.ViewModels;
using MvxFileExplorer.Core.Models;

namespace MvxFileExplorer.Core.Interfaces
{
    public interface IDirectoryService
    {
        ItemType GetItemType(string path);
        void LoadDrivesToCollection(MvxObservableCollection<DirectoryItemModel> items);
        void OpenDirectory(MvxObservableCollection<DirectoryItemModel> items, string path);
    }
}