using MvvmCross;
using MvvmCross.Core;
using MvvmCross.Platforms.Wpf.Core;
using MvvmCross.Platforms.Wpf.Views;
using MvxFileExplorer.Core.Interfaces;
using MvxFileExplorer.Core.Stores;
using MvxFileExplorer.Core.ViewModels;
using System.Windows;

namespace MvxFileExplorer.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : MvxApplication
    {
        protected override void RegisterSetup()
        {
            this.RegisterSetupType<MvxWpfSetup<MvxFileExplorer.Core.App>>(); 
        }
    }

}
