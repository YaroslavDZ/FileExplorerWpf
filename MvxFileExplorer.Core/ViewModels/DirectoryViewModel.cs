﻿using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvxFileExplorer.Core.Commands;
using MvxFileExplorer.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvxFileExplorer.Core.ViewModels
{
    public class DirectoryViewModel : MvxViewModel
    {
        private DirectoryItemModel _directoryModel;
        private MvxObservableCollection<DirectoryViewModel> _directories;
        private MvxObservableCollection<FileViewModel> _files;

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

        public bool IsSelected
        {
            get => _directoryModel.IsSelected;
            set
            {
                if (_directoryModel.IsSelected != value)
                {
                    _directoryModel.IsSelected = value;
                    RaisePropertyChanged(() => IsSelected);
                }
            }
        }

        public DirectoryItemModel SelectedItem
        {
            get => _directoryModel.SelectedItem;
            set
            {
                if (_directoryModel.SelectedItem != value)
                {
                    _directoryModel.SelectedItem = value;
                    RaisePropertyChanged(() => SelectedItem);
                }
            }
        }

        public MvxObservableCollection<DirectoryItemModel> Items { get; set; } = new MvxObservableCollection<DirectoryItemModel>();

        public ICommand SelectItemCommand { get; }

        public DirectoryViewModel(DirectoryItemModel directory)
        {
            _directoryModel = directory;
  
            SelectItemCommand = new SelectItemCommand(this);
            LoadItems("C:\\Users\\ydzys");
        }

        public void OpenItem()
        {
            LoadItems(SelectedItem.Path);
        }

        public void LoadItems(string rootPath)
        {
            Items.Clear();

            if (Directory.Exists(rootPath))
            {
                foreach (var dir in Directory.GetDirectories(rootPath))
                {
                    var item = new DirectoryItemModel { Name = System.IO.Path.GetFileName(dir), Path = dir, ItemType = GetItemType(dir) };
                    Items.Add(item);
                    LoadChildren(item);
                }

                foreach (var file in Directory.GetFiles(rootPath))
                {
                    Items.Add(new DirectoryItemModel { Name = System.IO.Path.GetFileName(file), Path = file, ItemType = GetItemType(file) });
                }
            }
        }

        private void LoadChildren(DirectoryItemModel item)
        {
            try
            {
                foreach (var dir in Directory.GetDirectories(item.Path))
                {
                    var childItem = new DirectoryItemModel { Name = System.IO.Path.GetFileName(dir), Path = dir, ItemType = GetItemType(dir) };
                    item.Children.Add(childItem);
                    LoadChildren(childItem);
                }

                foreach (var file in Directory.GetFiles(item.Path))
                {
                    item.Children.Add(new DirectoryItemModel { Name = System.IO.Path.GetFileName(file), Path = file, ItemType = GetItemType(file) });
                }
            }
            catch { }
        }

        private bool IsDrive(string path)
        {
            try
            {
                DriveInfo driveInfo = new DriveInfo(path);
                return driveInfo.IsReady && driveInfo.Name.Equals(path, StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        public ItemType GetItemType(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return ItemType.Unknown;
            }

            if (File.Exists(path))
            {
                return ItemType.File;
            }

            if (Directory.Exists(path))
            {
                if (IsDrive(path))
                {
                    return ItemType.Drive;
                }

                return ItemType.Directory;
            }

            return ItemType.Unknown;
        }

    }
}
