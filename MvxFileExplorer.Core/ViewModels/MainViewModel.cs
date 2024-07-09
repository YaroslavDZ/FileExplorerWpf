using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvxFileExplorer.Core.Commands;
using MvxFileExplorer.Core.Models;
using MvxFileExplorer.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvxFileExplorer.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly DirectoryService _directoryService;

        private DirectoryViewModel _selectedDirectory;
        private FileViewModel _selectedFile;

        private DirectoryViewModel _directoryViewModel;
        private FileViewModel _fileViewModel;

        private ObservableCollection<string> navigationHistory;
        private int currentIndex;

        private string currentPath;
        public string CurrentPath
        {
            get => currentPath;
            set
            {
                if (currentPath != value)
                {
                    currentPath = value;
                    RaisePropertyChanged();
                    UpdateNavigationHistory();
                }
            }
        }

        public DirectoryViewModel DirectoryViewModel
        {
            get => _directoryViewModel;
            set => SetProperty(ref _directoryViewModel, value);
        }

        public FileViewModel FileViewModel
        {
            get => _fileViewModel;
            set => SetProperty(ref _fileViewModel, value);
        }

        public FileViewModel SelectedFile
        {
            get => _selectedFile;
            set => SetProperty(ref _selectedFile, value);
        }

        public MvxObservableCollection<DirectoryViewModel> Directories { get; set; }

        public DirectoryViewModel SelectedDirectory
        {
            get => _selectedDirectory;
            set => SetProperty(ref _selectedDirectory, value);
        }

        public MvxCommand BackCommand { get; }
        public MvxCommand ForwardCommand { get; }
        public MvxCommand UpCommand { get; }

        public MainViewModel(/*DirectoryService directoryService*/)
        {
            //_directoryService = directoryService;
            Directories = new MvxObservableCollection<DirectoryViewModel>();

            DirectoryViewModel = new DirectoryViewModel(new DirectoryItemModel());

            FileViewModel = new FileViewModel(DirectoryViewModel);

            navigationHistory = new ObservableCollection<string>();

        }

        private void UpdateNavigationHistory()
        {
            if (currentIndex == navigationHistory.Count - 1)
            {
                navigationHistory.Add(currentPath);
                currentIndex++;
            }
            else
            {
                navigationHistory[currentIndex] = currentPath;
            }
            RaisePropertyChanged(nameof(CanGoBack));
            RaisePropertyChanged(nameof(CanGoForward));
        }
        private void Back(object parameter)
        {
            if (CanGoBack)
            {
                currentIndex--;
                CurrentPath = navigationHistory[currentIndex];
            }
        }

        public bool CanGoBack => currentIndex > 0;

        private void Forward(object parameter)
        {
            if (CanGoForward)
            {
                currentIndex++;
                CurrentPath = navigationHistory[currentIndex];
            }
        }

        public bool CanGoForward => currentIndex < navigationHistory.Count - 1;

        private void Up(object parameter)
        {
            if (CanGoUp)
            {
                CurrentPath = System.IO.Path.GetDirectoryName(CurrentPath);
            }
        }

        public bool CanGoUp => !string.IsNullOrEmpty(CurrentPath) && System.IO.Path.GetDirectoryName(CurrentPath) != null;

    }
}
