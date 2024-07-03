using MvvmCross.ViewModels;
using MvxFileExplorer.Core.Models;

namespace MvxFileExplorer.Core.ViewModels
{
    public class FileViewModel : MvxViewModel
    {
        private readonly FileModel _model;

        public string Name
        {
            get => _model.Name;
            set
            {
                if (_model.Name != value)
                {
                    _model.Name = value;
                    RaisePropertyChanged(() => Name);
                }
            }
        }

        public string Path
        {
            get => _model.Path;
            set
            {
                if (_model.Path != value)
                {
                    _model.Path = value;
                    RaisePropertyChanged(() => Path);
                }
            }
        }

        public long Size
        {
            get => _model.Size;
            set
            {
                if (_model.Size != value)
                {
                    _model.Size = value;
                    RaisePropertyChanged(() => Size);
                }
            }
        }

        public DateTime DateModified
        {
            get => _model.DateModified;
            set
            {
                if (_model.DateModified != value)
                {
                    _model.DateModified = value;
                    RaisePropertyChanged(() => Name);
                }
            }
        }

        public FileViewModel(FileModel model)
        {
            _model = model;
        }
    }
}
