using MvxFileExplorer.Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvxFileExplorer.Core.Models
{
    public class DirectoryHistory : IDirectoryHistory
    {
        private DirectoryHistoryNode _head;

        public DirectoryHistoryNode CurrentItem { get; private set; }

        public bool CanMoveBack => CurrentItem.PreviousNode != null;

        public bool CanMoveForward => CurrentItem.NextNode != null;

        public event EventHandler HistoryChanged;

        public DirectoryHistory(string filePath, string name)
        {
            _head = new DirectoryHistoryNode(filePath, name);
            CurrentItem = _head;
        }

        public IEnumerator<DirectoryHistoryNode> GetEnumerator()
        {
            yield return CurrentItem;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void MoveBack()
        {
            var prev = CurrentItem.PreviousNode;

            CurrentItem = prev;
            RaiseHistoryChanged();
        }

        public void Add(string filePath, string name)
        {
            var node = new DirectoryHistoryNode(filePath, name);

            CurrentItem.NextNode = node;
            node.PreviousNode = CurrentItem;
            CurrentItem = node;

            RaiseHistoryChanged();
        }

        public void MoveForward()
        {
            RaiseHistoryChanged();
        }

        private void RaiseHistoryChanged()
        {
            HistoryChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
