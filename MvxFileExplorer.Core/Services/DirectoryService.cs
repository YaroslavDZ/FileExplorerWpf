using MvvmCross.ViewModels;
using MvxFileExplorer.Core.Interfaces;
using MvxFileExplorer.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvxFileExplorer.Core.Services
{
    public class DirectoryService : IDirectoryService
    {
        public void OpenDirectory(MvxObservableCollection<DirectoryItemModel> items, string path)
        {
            items.Clear();


            var directoryInfo = new DirectoryInfo(path);

            try
            {
                foreach (var dir in directoryInfo.GetDirectories())
                {
                    var dirItem = new DirectoryItemModel(dir.FullName, dir.Name) { Name = dir.Name, Path = dir.FullName, ItemType = GetItemType(dir.FullName), CreationDate = dir.CreationTime };
                    items.Add(dirItem);
                }

                foreach (var file in directoryInfo.GetFiles())
                {
                    var dirItem = new DirectoryItemModel(file.FullName, file.Name) { Name = file.Name, Path = file.FullName, ItemType = GetItemType(file.FullName), CreationDate = file.CreationTime };
                    items.Add(dirItem);
                }
            }
            catch
            {

            }
        }

        public void LoadDrivesToCollection(MvxObservableCollection<DirectoryItemModel> items)
        {
            foreach (var logicalDrive in Directory.GetLogicalDrives())
            {
                items.Add(new DirectoryItemModel(logicalDrive, logicalDrive) { Path = logicalDrive, Name = logicalDrive, ItemType = GetItemType(logicalDrive) });
            }
        }

        private bool IsDrive(string path)
        {
            try
            {
                DriveInfo driveInfo = new DriveInfo(path);
                return driveInfo.IsReady && driveInfo.Name.Equals(path, StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        public ItemType GetItemType(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return ItemType.Unknown;
            }

            if (File.Exists(path))
            {
                return ItemType.File;
            }

            if (Directory.Exists(path))
            {
                if (IsDrive(path))
                {
                    return ItemType.Drive;
                }

                return ItemType.Directory;
            }

            return ItemType.Unknown;
        }
    }
}
