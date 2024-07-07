using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Collections;
using MvvmCross.ViewModels;

namespace MvxFileExplorer.Core.Models
{
    
    public class DirectoryModel
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public MvxObservableCollection<FileModel> Files { get; set; }

        public MvxObservableCollection<DirectoryModel> Directories { get; set; }
    }
}
