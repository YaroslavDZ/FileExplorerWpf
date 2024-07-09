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
            DataContext = new DirectoryViewModel(new Core.Models.DirectoryItemModel());
        }

        private void TreeViewItem_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var viewModel = DataContext as DirectoryViewModel;
            if (viewModel != null)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    viewModel.SelectedItem = e.NewValue as DirectoryItemModel;
                });
            }
        }

        //private void LoadFileSystem(string path, ItemCollection items)
        //{
        //    DirectoryInfo directoryInfo = new DirectoryInfo(path);

        //    try
        //    {
        //        foreach (var directory in directoryInfo.GetDirectories())
        //        {
        //            TreeViewItem directoryItem = new TreeViewItem
        //            {
        //                Header = directory.Name,
        //                Tag = directory.FullName,
        //            };
        //            items.Add(directoryItem);
        //            LoadFileSystem(directory.FullName, directoryItem.Items);
        //        }

        //        foreach (var file in directoryInfo.GetFiles())
        //        {
        //            TreeViewItem fileItem = new TreeViewItem
        //            {
        //                Header = file.Name,
        //                Tag = file.FullName
        //            };
        //            items.Add(fileItem);
        //        }
        //    }
        //    catch (UnauthorizedAccessException e)
        //    {

        //    }
        //}
    }
}
