using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvxFileExplorer.Core.Stores
{
    public class NavigationStore
    {
        private MvxViewModel _currentViewModel;

        public MvxViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                if (_currentViewModel != value)
                {
                    _currentViewModel = value;
                    OnCurrentlyViewModelChanged();
                }
            }
        }

        public event Action CurrentViewModelChanged;

        private void OnCurrentlyViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

    }
}
 