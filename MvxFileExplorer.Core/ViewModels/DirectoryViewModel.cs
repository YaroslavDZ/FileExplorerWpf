using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvxFileExplorer.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvxFileExplorer.Core.ViewModels
{
    public class DirectoryViewModel : MvxViewModel
    {
        private readonly DirectoryModel _directoryModel;
        private MvxObservableCollection<DirectoryViewModel> _directories;
        private MvxObservableCollection<FileListViewModel> _files;

        public string Name
        {
            get => _directoryModel.Name;
            set
            {
                if (_directoryModel.Name != value)
                {
                    _directoryModel.Name = value;
                    RaisePropertyChanged(() => Name);
                }
            }
        }

        public string Path
        {
            get => _directoryModel.Path;
            set
            {
                if (_directoryModel.Path != value)
                {
                    _directoryModel.Path = value;
                    RaisePropertyChanged(() => Path);
                }
            }
        }

        public MvxObservableCollection<DirectoryItemModel> Items { get; set; } = new MvxObservableCollection<DirectoryItemModel>();

        public ICommand LoadFileSystemCommand { get; }

        public DirectoryViewModel(DirectoryModel directory)
        {
            _directoryModel = directory;
            LoadFileSystemCommand = new MvxCommand<string>(LoadFileSystem);
            LoadFileSystemRecursively("C:\\Users\\ydzys", Items);
        }

        private void LoadFileSystem(string path)
        {
            Items.Clear();
            LoadFileSystemIteratively(path);
        }

        private static bool IsDrive(string path)
        {
            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.Name.Equals(System.IO.Path.GetPathRoot(path), StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        private ItemType GetItemType(string path)
        {
            if (Directory.Exists(path))
            {
                if (IsDrive(path))
                {
                    return ItemType.Drive;
                }

                return ItemType.Directory;
            }
            else if (File.Exists(path))
            {
                return ItemType.File;
            }
            else
            {
                return ItemType.Unknown;
            }
        }

        private void LoadFileSystemIteratively(string path)
        {
            var stack = new Stack<(string Path, DirectoryItemModel Parent)>();
            stack.Push((path, null));

            while (stack.Count > 0)
            {
                var (currentPath, parent) = stack.Pop();
                var directoryInfo = new DirectoryInfo(currentPath);

                try
                {
                    var currentItem = new DirectoryItemModel()
                    {
                        Name = directoryInfo.Name,
                        Path = directoryInfo.FullName,
                        ItemType = GetItemType(directoryInfo.FullName),
                        IsSelected = false,
                    };

                    if (parent == null)
                    {
                        Items.Add(currentItem);
                    }
                    else
                    {
                        parent.Children.Add(currentItem);
                    }

                    foreach (var directory in directoryInfo.GetDirectories())
                    {
                        stack.Push((directory.FullName, currentItem));
                    }

                    foreach (var file in directoryInfo.GetFiles())
                    {
                        var fileItem = new DirectoryItemModel()
                        {
                            Name = file.Name,
                            Path = file.FullName,
                            IsSelected = false,
                            ItemType = GetItemType(file.FullName)
                        };
                        currentItem.Children.Add(fileItem);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    // Handle exception
                }
            }
        }

        private void LoadFileSystemRecursively(string path, MvxObservableCollection<DirectoryItemModel> items)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            try
            {
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    DirectoryItemModel directoryItem = new DirectoryItemModel()
                    {
                        Name = directoryInfo.Name,
                        Path = directoryInfo.FullName,
                        ItemType = GetItemType(directoryInfo.FullName),
                        IsSelected = false,
                        Children = items
                    };
                    Items.Add(directoryItem);
                    LoadFileSystemRecursively(directory.FullName, directoryItem.Children);
                }

                foreach (var file in directoryInfo.GetFiles())
                {
                    DirectoryItemModel fileItem = new DirectoryItemModel()
                    {
                        Name = file.Name,
                        Path = file.FullName,
                        IsSelected = false,
                        ItemType = GetItemType(file.FullName)
                    };
                    items.Add(fileItem);
                }
            }
            catch (UnauthorizedAccessException e)
            {

            }
        }
    }
}
