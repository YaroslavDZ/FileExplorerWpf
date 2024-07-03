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
        public ICommand CreateFileCommand { get; private set; }
        public ICommand RenameFileCommand { get; private set; }
        public ICommand CopyFileCommand { get; private set; }
        public ICommand DeleteFileCommand { get; private set; }
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
            CreateFileCommand = new MvxCommand(CreateFile);
            RenameFileCommand = new MvxCommand(RenameFile);
            CopyFileCommand = new MvxCommand(CopyFile);
            DeleteFileCommand = new MvxCommand(DeleteFile);
            NavigateCommand = new MvxCommand<DirectoryViewModel>(Navigate);

            DirectoryViewModel = new DirectoryViewModel(new DirectoryModel());
        }

        private void LoadDirectories()
        {
            var rootDirectories = _directoryService.GetRootDirectories();
            foreach (var dir in rootDirectories)
            {
                Directories.Add(new DirectoryViewModel(dir));
            }
        }

        private void CreateFile()
        {
            if (SelectedDirectory == null) return;
            // Logic to create a new file
            var newFile = _directoryService.CreateFile(SelectedDirectory.Path, "NewFile.txt");
            SelectedDirectory.Files.Add(new FileViewModel(newFile));
        }

        private void RenameFile()
        {
            if (SelectedFile == null) return;
            var newName = "RenamedFile.txt"; 
            _directoryService.RenameFile(SelectedFile.Path, newName);
            SelectedFile.Name = newName;
        }

        private void CopyFile()
        {
            if (SelectedFile == null) return;

            var destinationPath = "PathToDestinationDirectory";
            _directoryService.CopyFile(SelectedFile.Path, destinationPath);
        }

        private void DeleteFile()
        {
            if (SelectedFile == null) return;
            _directoryService.DeleteFile(SelectedFile.Path);
            SelectedDirectory.Files.Remove(SelectedFile);
        }

        private void Navigate(DirectoryViewModel directory)
        {
            SelectedDirectory = directory;
        }
    }
}
