using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvxFileExplorer.Core.Commands
{
    public class RenameFile : MvxCommand
    {
        public RenameFile(Action execute) : base(execute)
        {
        }
    }
}
