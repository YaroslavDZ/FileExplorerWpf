using MvvmCross.ViewModels;
using MvxFileExplorer.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvxFileExplorer.Core.Models
{
    public class DirectoryItemModel
    {
        public string Name { get; set; } = string.Empty;

        public string Path { get; set; } = string.Empty;

        public long Size { get; set; }

        public DateTime? CreationDate { get; set; }

        public ItemType ItemType { get; set; }

        public string ImagePath {
            get
            {
                if (ItemType == ItemType.File)
                {
                    return "pack://application:,,,/Images/file.png";
                }
                else if (ItemType == ItemType.Drive)
                {
                    return "pack://application:,,,/Images/drive.png";
                }
                else
                {
                    return "pack://application:,,,/Images/folder.png";
                }
            }
        }

        public bool IsSelected { get; set; }

        public DirectoryItemModel SelectedItem { get; set; }

        public MvxObservableCollection<DirectoryItemModel>? Children { get; set; } = new MvxObservableCollection<DirectoryItemModel>();

    }

    public enum ItemType
    {
        File,
        Directory,
        Drive,
        Unknown
    }

}
