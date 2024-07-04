﻿using MvvmCross.Platforms.Wpf.Views;
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

namespace MvxFileExplorer.Wpf.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : MvxWpfView
    {
        public MainView()
        {
            InitializeComponent();

            LoadFileSystem("C:\\Users\\ydzys\\CodeProjects", treeViewItem.Items);
        }

        private void LoadFileSystem(string path, ItemCollection items)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            try
            {
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    TreeViewItem directoryItem = new TreeViewItem
                    {
                        Header = directory.Name,
                        Tag = directory.FullName
                    };
                    items.Add(directoryItem);
                    LoadFileSystem(directory.FullName, directoryItem.Items);
                }

                foreach (var file in directoryInfo.GetFiles())
                {
                    TreeViewItem fileItem = new TreeViewItem
                    {
                        Header = file.Name,
                        Tag = file.FullName
                    };
                    items.Add(fileItem);
                }
            }
            catch (UnauthorizedAccessException e)
            {

            }
        }
    }
}
