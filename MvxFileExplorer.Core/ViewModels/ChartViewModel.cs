﻿using LiveCharts;
using LiveCharts.Definitions.Series;
using MimeDetective;
using MvvmCross.ViewModels;
using MvxFileExplorer.Core.Commands;
using MvxFileExplorer.Core.Models;
using MvxFileExplorer.Core.Stores;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LiveCharts.Wpf;

namespace MvxFileExplorer.Core.ViewModels
{
    public class ChartViewModel : MvxViewModel
    {
        private SeriesCollection _series;

        private readonly DirectoryItemModel _directoryItemModel;

        private static readonly Dictionary<string, string> FileTypeMappings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { ".jpg", "Images" }, { ".jpeg", "Images" }, { ".png", "Images" }, { ".gif", "Images" }, { ".bmp", "Images" },
            { ".mp4", "Videos" }, { ".avi", "Videos" }, { ".mkv", "Videos" }, { ".mov", "Videos" },
            { ".txt", "Text Files" }, { ".doc", "Text Files" }, { ".docx", "Text Files" }, { ".pdf", "Text Files" },
        };

        public SeriesCollection Series
        {
            get => _series;
            set
            {
                if (_series == value) return;
                _series = value;
                RaisePropertyChanged(() => Series);
            }
        }

        public ObservableCollection<PieChartData> PieChartValues { get; set; }

        public Dictionary<string, long> FileTypeSizes { get; set; }

        public string Title { get; set; }

        public int Value { get; set; }

        public ICommand NavigateHomeCommand { get; }

        public ChartViewModel(DirectoryItemModel directoryItemModel, NavigationStore navigationStore) 
        {
            _directoryItemModel = directoryItemModel;

            NavigateHomeCommand = new NavigateMainCommand(navigationStore);

            PieChartValues = new ObservableCollection<PieChartData>();

            FileTypeSizes = CountFileTypes(directoryItemModel.Path);
        }

        private Dictionary<string, long> CountFileTypes(string directoryPath)
        {
            var fileTypeCounts = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase)
            {
                { "Images", 0 },
                { "Videos", 0 },
                { "Text Files", 0 },
                { "Others", 0 }
            };

            CountFileSizesRecursive("C:\\Users\\ydzys\\Pictures\\Screenshots", fileTypeCounts);

            return fileTypeCounts;
        }

        private void CountFileSizesRecursive(string directoryPath, Dictionary<string, long> fileTypeSizes)
        {
            try
            {
                foreach (var file in Directory.GetFiles(directoryPath))
                {
                    var extension = Path.GetExtension(file);
                    var fileInfo = new FileInfo(file);
                    var fileSize = fileInfo.Length;

                    if (FileTypeMappings.TryGetValue(extension, out var fileType))
                    {
                        fileTypeSizes[fileType] += fileSize;
                    }
                    else
                    {
                        fileTypeSizes["Others"] += fileSize;
                    }
                }

                foreach (var subDirectory in Directory.GetDirectories(directoryPath))
                {
                    CountFileSizesRecursive(subDirectory, fileTypeSizes);
                }
            }
            catch (UnauthorizedAccessException)
            {
            }
        }
    }
}
