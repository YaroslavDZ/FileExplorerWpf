using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Collections;

namespace MvxFileExplorer.Core.Models
{
    
    public class DirectoryModel
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public ObservableCollection<FileModel> Files { get; set; }

        public ObservableCollection<DirectoryModel> Directories { get; set; }
    }
}
