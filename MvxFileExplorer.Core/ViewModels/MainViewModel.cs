using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvxFileExplorer.Core.Commands;
using MvxFileExplorer.Core.Models;
using MvxFileExplorer.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public DirectoryViewModel DirectoryViewModel
        {
            get => _directoryViewModel;
            set => SetProperty(ref _directoryViewModel, value);
        }

        public FileViewModel SelectedFile
        {
            get => _selectedFile;
            set => SetProperty(ref _selectedFile, value);
        }

        public ObservableCollection<DirectoryViewModel> Directories { get; set; }

        public ICommand NavigateCommand { get; private set; }

        public DirectoryViewModel SelectedDirectory
        {
            get => _selectedDirectory;
            set => SetProperty(ref _selectedDirectory, value);
        }

        public MainViewModel(/*DirectoryService directoryService*/)
        {
            //_directoryService = directoryService;
            Directories = new ObservableCollection<DirectoryViewModel>();

            NavigateCommand = new MvxCommand<DirectoryViewModel>(Navigate);

            DirectoryViewModel = new DirectoryViewModel(new DirectoryModel());
        }

        private void Navigate(DirectoryViewModel directory)
        {
            SelectedDirectory = directory;
        }
    }
}
