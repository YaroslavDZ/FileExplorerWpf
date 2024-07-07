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
        public string Name { get; set; }

        public string Path { get; set; }

        public ItemType ItemType { get; set; }

        public bool IsSelected { get; set; }

        public MvxObservableCollection<DirectoryItemModel> Children { get; set; }

    }

    public enum ItemType
    {
        File,
        Directory,
        Drive,
        Unknown
    }

}
