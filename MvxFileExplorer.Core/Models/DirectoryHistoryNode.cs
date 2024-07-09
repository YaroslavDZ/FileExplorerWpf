using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvxFileExplorer.Core.Models
{
    public class DirectoryHistoryNode
    {
        public string Path { get; set; }

        public string Name { get; set; }

        public DirectoryHistoryNode PreviousNode { get; set; }

        public DirectoryHistoryNode NextNode { get; set; }

        public DirectoryHistoryNode(string path, string name)
        {
            Path = path;
            Name = name;
        }
    }
}
