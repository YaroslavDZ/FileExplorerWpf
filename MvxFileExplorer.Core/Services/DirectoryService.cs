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
                directories.Add(new DirectoryItemModel
                {
                    Name = directoryInfo.Name,
                    Path = directoryInfo.FullName,
                });
            }

            return directories;
        }

        public DirectoryItemModel CreateFile(string directoryPath, string fileName)
        {
            var filePath = Path.Combine(directoryPath, fileName);
            using (var fileStream = File.Create(filePath))
            {
                // File created
            }

            var fileInfo = new FileInfo(filePath);

            return new DirectoryItemModel
            {
                Name = fileInfo.Name,
                Path = fileInfo.FullName,
            };
        }

        public void RenameFile(string filePath, string newName)
        {
            var directory = Path.GetDirectoryName(filePath);
            if (directory == null) return;

            var newFilePath = Path.Combine(directory, newName);
            File.Move(filePath, newFilePath);

            Console.WriteLine($"The file was renamed from {filePath} to {newFilePath}");
        }

        public void CopyFile(string sourcePath, string destinationPath)
        {
            File.Copy(sourcePath, destinationPath);

            Console.WriteLine($"The file was copied from {sourcePath} to {destinationPath}");
        }

        public void DeleteFile(string filePath)
        {
            File.Delete(filePath);

            Console.WriteLine($"The file was deleted: {filePath}");
        }

        private ObservableCollection<DirectoryItemModel> GetDirectories(string path)
        {
            var directories = new ObservableCollection<DirectoryItemModel>();
            var directoryInfo = new DirectoryInfo(path);

            foreach (var directory in directoryInfo.GetDirectories())
            {
                directories.Add(new DirectoryItemModel
                {
                    Name = directory.Name,
                    Path = directory.FullName,
                });
            }

            return directories;
        }

        private ObservableCollection<DirectoryItemModel> GetFiles(string path)
        {
            var files = new ObservableCollection<DirectoryItemModel>();
            var directoryInfo = new DirectoryInfo(path);

            foreach (var file in directoryInfo.GetFiles())
            {
                files.Add(new DirectoryItemModel
                {
                    Name = file.Name,
                    Path = file.FullName,
                });
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
