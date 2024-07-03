using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvxFileExplorer.Core.Commands
{
    public class DeleteFile : MvxCommand
    {
        public DeleteFile(Action execute) : base(execute)
        {
        }
    }
}
