using MvvmCross.Commands;
using MvxFileExplorer.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvxFileExplorer.Core.Commands
{
    public class Navigate : MvxCommand<DirectoryViewModel>
    {
        public Navigate(Action<DirectoryViewModel> execute) : base(execute)
        {
        }
    }
}
