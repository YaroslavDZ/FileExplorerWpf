using MvxFileExplorer.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvxFileExplorer.Core.Services
{
    public class DirectoryService
    {
        public ObservableCollection<DirectoryItemModel> GetRootDirectories()
        {
            var drives = Directory.GetLogicalDrives();
            var directories = new ObservableCollection<DirectoryItemModel>();

            foreach (var drive in drives)
            {
                var directoryInfo = new DirectoryInfo(drive);
                directories.Add(new DirectoryItemModel(directoryInfo.FullName, directoryInfo.Name)
                {
                    Name = directoryInfo.Name,
                    Path = directoryInfo.FullName,
                });
            }

            return directories;
        }

        private ObservableCollection<DirectoryItemModel> GetDirectories(string path)
        {
            var directories = new ObservableCollection<DirectoryItemModel>();
            var directoryInfo = new DirectoryInfo(path);

            foreach (var directory in directoryInfo.GetDirectories())
            {
                directories.Add(new DirectoryItemModel(directory.FullName, directory.Name));
            }

            return directories;
        }

        private ObservableCollection<DirectoryItemModel> GetFiles(string path)
        {
            var files = new ObservableCollection<DirectoryItemModel>();
            var directoryInfo = new DirectoryInfo(path);

            foreach (var file in directoryInfo.GetFiles())
            {
                files.Add(new DirectoryItemModel(file.FullName, file.Name));
            }

            return files;
        }



        //public static IList<FileInfo> GetChildFiles(string directory)
        //{
        //    try
        //    {
        //        return Directory.GetFiles(directory).Select(x => new FileInfo(x)).ToList();
        //    }
        //    catch (Exception e){
        //        Console.WriteLine(e.Message);
        //    }

        //    return new List<FileInfo>();
        //}

        //public static IList<DirectoryInfo> GetChildDirectories(string directory)
        //{
        //     try
        //     {
        //        return Directory.GetDirectories(directory).Select(x => new DirectoryInfo(x)).ToList();
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine(e.Message);
        //     }

        //     return new List<DirectoryInfo>();
        //}

        //public static IList<DriveInfo> GetRootDirectories()
        //{
        //    return DriveInfo.GetDrives().ToList();
        //}
    }
}
