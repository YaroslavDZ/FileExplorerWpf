using MvvmCross.Platforms.Wpf.Views;
using MvxFileExplorer.Core.Models;
using MvxFileExplorer.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MvxFileExplorer.Wpf.Views
{
    /// <summary>
    /// Interaction logic for DirectoryView.xaml
    /// </summary>
    public partial class DirectoryView : MvxWpfView
    {
        public DirectoryView()
        {
            InitializeComponent();
        }
    }
}
