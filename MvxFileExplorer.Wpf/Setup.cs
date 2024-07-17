using MvvmCross.Platforms.Wpf.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using MvvmCross.IoC;
using MvxFileExplorer.Core.Interfaces;
using MvvmCross;
using MvxFileExplorer.Core.Stores;

namespace MvxFileExplorer.Wpf
{
    public class Setup : MvxWpfSetup<Core.App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
        }
    }
}
