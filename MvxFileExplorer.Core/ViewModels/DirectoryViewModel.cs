using MvvmCross.ViewModels;
using MvxFileExplorer.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvxFileExplorer.Core.ViewModels
{
    public class DirectoryViewModel : MvxViewModel
    {
        private readonly DirectoryModel _directoryModel;

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

        private ObservableCollection<FileViewModel> _files;
        public ObservableCollection<FileViewModel> Files => _files ??= new ObservableCollection<FileViewModel>(
            _directoryModel.Files.Select(f => new FileViewModel(f)));

        private ObservableCollection<DirectoryViewModel> _directories;
        public ObservableCollection<DirectoryViewModel> Directories => _directories ??= new ObservableCollection<DirectoryViewModel>(
            _directoryModel.Directories.Select(d => new DirectoryViewModel(d)));


        public DirectoryViewModel(DirectoryModel directory)
        {
            _directoryModel = directory;
        }
    }
}
