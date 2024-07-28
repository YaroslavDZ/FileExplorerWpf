using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvxFileExplorer.Core.Commands;
using MvxFileExplorer.Core.Interfaces;
using MvxFileExplorer.Core.Models;
using MvxFileExplorer.Core.Services;
using MvxFileExplorer.Core.Stores;
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
        private readonly DirectoryService _directoryService;
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

        public DateTime? CreationDate
        {
            get => _directoryModel.CreationDate;
            set
            {
                if (_directoryModel.CreationDate != value)
                {
                    _directoryModel.CreationDate = value;
                    RaisePropertyChanged(() => CreationDate);
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

        public ICommand NavigateChartCommand { get; private set; }

        public DirectoryViewModel(DirectoryItemModel directory, NavigationStore navigationStore)
        {
            _directoryModel = directory;
            _directoryHistory = new DirectoryHistory("C:\\", "C:\\");
            _directoryService = new DirectoryService();

            OpenCommand = new OpenCommand(this);

            MoveBackCommand = new RelayCommand(OnMoveBack, OnCanMoveBack);
            MoveForwardCommand = new RelayCommand(OnMoveForward, OnCanMoveForward);

            NavigateChartCommand = new NavigateChartCommand(navigationStore);

            Name = _directoryHistory.CurrentItem.Name;
            Path = _directoryHistory.CurrentItem.Path;

            _directoryService.LoadDrivesToCollection(Items);

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

            _directoryService.OpenDirectory(FileViewItems, Path);
        }

        public bool OnCanMoveBack(object obj) => _directoryHistory.CanMoveBack;

        public void OnMoveForward(object parameter)
        {
            _directoryHistory.MoveForward();

            var current = _directoryHistory.CurrentItem;

            Path = current.Path;
            Name = current.Name;

            _directoryService.OpenDirectory(FileViewItems, Path);
        }

        public bool OnCanMoveForward(object obj) => _directoryHistory.CanMoveForward;

        public void OpenItem(object parameter)
        {
            if (parameter is DirectoryItemModel item)
            {
                Path = item.Path;
                Name = item.Name;

                _directoryHistory.Add(Path, Name);

                _directoryService.OpenDirectory(FileViewItems, Path);
            }
        }
    }
}
