using MvxFileExplorer.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MvxFileExplorer.Wpf
{
    public class DirInfo : DependencyObject
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Root { get; set; }
        public string Size { get; set; }
        public string Ext { get; set; }
        public int DirType { get; set; }

        public static readonly DependencyProperty propertyChilds = DependencyProperty.Register("Childs", typeof(IList<DirInfo>), typeof(DirInfo));
        public IList<DirInfo> SubDirectories
        {
            get { return (IList<DirInfo>) GetValue(propertyChilds); }
            set { SetValue(propertyChilds, value); }
        }

        public static readonly DependencyProperty propertyIsExpanded = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(DirInfo));
        public bool IsExpanded
        {
            get { return (bool)GetValue(propertyIsExpanded); }
            set { SetValue(propertyIsExpanded, value); }
        }

        public static readonly DependencyProperty propertyIsSelected = DependencyProperty.Register("IsSelected", typeof(bool), typeof(DirInfo));
        public bool IsSelected
        {
            get { return (bool)GetValue(propertyIsSelected); }
            set { SetValue(propertyIsSelected, value); }
        }
    }
}
