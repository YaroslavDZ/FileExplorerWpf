using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvxFileExplorer.Core.Commands;
using MvxFileExplorer.Core.Interfaces;
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
using static System.Net.Mime.MediaTypeNames;

namespace MvxFileExplorer.Core.ViewModels
{
    public class DirectoryViewModel : MvxViewModel
    {
        private DirectoryItemModel _directoryModel;
        private readonly IDirectoryHistory _directoryHistory;
        public const string ROOTPATH = "C:\\Users\\ydzys";

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

        public MvxObservableCollection<DirectoryItemModel> FileViewItems { get; set; } = new MvxObservableCollection<DirectoryItemModel>();

        public OpenCommand OpenCommand { get; }

        public RelayCommand MoveBackCommand { get; }

        public RelayCommand MoveForwardCommand { get; }

        public DirectoryViewModel(DirectoryItemModel directory)
        {
            _directoryModel = directory;
            _directoryHistory = new DirectoryHistory("C:\\", "C:\\");

            OpenCommand = new OpenCommand(this);

            MoveBackCommand = new RelayCommand(OnMoveBack, OnCanMoveBack);
            MoveForwardCommand = new RelayCommand(OnMoveForward, OnCanMoveForward);

            Name = _directoryHistory.CurrentItem.Name;
            Path = _directoryHistory.CurrentItem.Path;

            LoadDrivesToCollection(Items);

            _directoryHistory.HistoryChanged += History_HistoryChanged;
        }

        private void History_HistoryChanged(object sender, EventArgs e)
        {
            MoveBackCommand?.RaiseCanExecuteChanged();
            MoveForwardCommand?.RaiseCanExecuteChanged();

        }

        public void OnMoveBack(object parameter)
        {
            _directoryHistory.MoveBack();

            var current = _directoryHistory.CurrentItem;

            Path = current.Path;
            Name = current.Name;

            OpenDirectory();
        }

        public bool OnCanMoveBack(object obj) => _directoryHistory.CanMoveBack;

        public void OnMoveForward(object parameter)
        {
            _directoryHistory.MoveForward();

            var current = _directoryHistory.CurrentItem;

            Path = current.Path;
            Name = current.Name;

            OpenDirectory();
        }

        public bool OnCanMoveForward(object obj) => _directoryHistory.CanMoveForward;

        public void OpenItem(object parameter)
        {
            if (parameter is DirectoryItemModel item)
            {
                Path = item.Path;
                Name = item.Name;

                _directoryHistory.Add(Path, Name);

                OpenDirectory();
            }
        }

        private void OpenDirectory()
        {
            FileViewItems.Clear();


            var directoryInfo = new DirectoryInfo(Path);

            try
            {
                foreach (var dir in directoryInfo.GetDirectories())
                {
                    var dirItem = new DirectoryItemModel(dir.FullName, dir.Name) { Name = dir.Name, Path = dir.FullName, ItemType = GetItemType(dir.FullName), CreationDate = dir.CreationTime };
                    FileViewItems.Add(dirItem);
                }

                foreach (var file in directoryInfo.GetFiles())
                {
                    var dirItem = new DirectoryItemModel(file.FullName, file.Name) { Name = file.Name, Path = file.FullName, ItemType = GetItemType(file.FullName), CreationDate = file.CreationTime };
                    FileViewItems.Add(dirItem);
                }
            }
            catch
            {

            }
        }

        public void LoadDrivesToCollection(MvxObservableCollection<DirectoryItemModel> items)
        {
            foreach (var logicalDrive in Directory.GetLogicalDrives())
            {
                items.Add(new DirectoryItemModel(logicalDrive, logicalDrive) { Path = logicalDrive, Name = logicalDrive, ItemType = GetItemType(logicalDrive) });
            }
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
