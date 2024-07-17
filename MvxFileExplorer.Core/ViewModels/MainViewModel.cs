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
        private ChartViewModel _chartViewModel;

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

        public ChartViewModel ChartViewModel
        {
            get => _chartViewModel;
            set => SetProperty(ref _chartViewModel, value);
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

        public MainViewModel()
        {
            Directories = new MvxObservableCollection<DirectoryViewModel>();

            DirectoryViewModel = new DirectoryViewModel(new DirectoryItemModel("C:\\", "C:\\"));

            FileViewModel = new FileViewModel();

            ChartViewModel = new ChartViewModel(new NavigationStore());

            navigationHistory = new ObservableCollection<string>();

        }
    }
}
