﻿using MvvmCross.Commands;
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
        private FileViewModel _fileViewModel;

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

        public ICommand NavigateCommand { get; private set; }

        public DirectoryViewModel SelectedDirectory
        {
            get => _selectedDirectory;
            set => SetProperty(ref _selectedDirectory, value);
        }

        public MainViewModel(/*DirectoryService directoryService*/)
        {
            //_directoryService = directoryService;
            Directories = new MvxObservableCollection<DirectoryViewModel>();

            NavigateCommand = new MvxCommand<DirectoryViewModel>(Navigate);

            DirectoryViewModel = new DirectoryViewModel(new DirectoryItemModel());

            FileViewModel = new FileViewModel(DirectoryViewModel);

        }

        private void Navigate(DirectoryViewModel directory)
        {
            SelectedDirectory = directory;
        }
    }
}
