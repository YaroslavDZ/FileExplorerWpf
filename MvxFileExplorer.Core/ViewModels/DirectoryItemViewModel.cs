using MvvmCross.ViewModels;
using MvxFileExplorer.Core.Interfaces;
using MvxFileExplorer.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvxFileExplorer.Core.ViewModels
{
    public class DirectoryItemViewModel : MvxViewModel
    {
        private readonly DirectoryItemModel _item;

        public string Name
        {
            get => _item.Name;
            set
            {
                if (_item.Name != value)
                {
                    _item.Name = value;
                    RaisePropertyChanged(() => Name);
                }
            }
        }

        public string Path
        {
            get => _item.Path;
            set
            {
                if (_item.Path != value)
                {
                    _item.Path = value;
                    RaisePropertyChanged(() => Path);
                }
            }
        }

        public DateTime? CreationDate
        {
            get => _item.CreationDate;
            set
            {
                if (_item.CreationDate != value)
                {
                    _item.CreationDate = value;
                    RaisePropertyChanged(() => CreationDate);
                }
            }
        }

        public long Size
        {
            get => _item.Size;
            set
            {
                if (_item.Size != value)
                {
                    _item.Size = value;
                    RaisePropertyChanged(() => Size);
                }
            }
        }

        public bool IsSelected
        {
            get => _item.IsSelected;
            set
            {
                if (_item.IsSelected != value)
                {
                    _item.IsSelected = value;
                    RaisePropertyChanged(() => IsSelected);
                }
            }
        }

        public ItemType ItemType
        {
            get => _item.ItemType;
            set
            {
                if (_item.ItemType != value)
                {
                    _item.ItemType = value;
                    RaisePropertyChanged(() => ItemType);
                }
            }
        }

        public MvxObservableCollection<DirectoryItemModel> Children { get; set; } = new MvxObservableCollection<DirectoryItemModel>();

        public DirectoryItemViewModel(DirectoryItemModel item)
        {
            _item = item;
        }
    }
}
