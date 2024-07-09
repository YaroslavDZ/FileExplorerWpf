using MvxFileExplorer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvxFileExplorer.Core.Interfaces
{
    public interface IDirectoryHistory : IEnumerable<DirectoryHistoryNode>
    {
        public bool CanMoveBack { get; }

        public bool CanMoveForward { get; }

        public DirectoryHistoryNode CurrentItem { get; }

        public void Add(string filePath, string name);

        event EventHandler HistoryChanged;

        void MoveBack();

        void MoveForward();

    }
}
