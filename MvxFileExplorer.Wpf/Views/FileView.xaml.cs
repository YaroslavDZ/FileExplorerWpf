using MvvmCross.Platforms.Wpf.Views;
using MvxFileExplorer.Core.Models;
using MvxFileExplorer.Core.ViewModels;
using System;
using System.Collections.Generic;
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

namespace MvxFileExplorer.Wpf.Views
{
    /// <summary>
    /// Interaction logic for FileView.xaml
    /// </summary>
    public partial class FileView : MvxWpfView
    {
        public FileView()
        {
            InitializeComponent();
            DataContext = new DirectoryViewModel(new Core.Models.DirectoryItemModel("C:\\", "C:\\"));
        }
    }
}
