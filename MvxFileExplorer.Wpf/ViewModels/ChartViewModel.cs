using LiveCharts;
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
using LiveCharts.SeriesAlgorithms;
using System.IO;

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

        private SeriesCollection _seriesCollection;
        public SeriesCollection SeriesCollection
        {
            get { return _seriesCollection; }
            set
            {
                _seriesCollection = value;
                RaisePropertyChanged(nameof(SeriesCollection));
            }
        }

        public ObservableCollection<PieChartData> PieChartValues { get; set; }

        public Dictionary<string, long> FileTypeSizes { get; set; }

        public ICommand NavigateHomeCommand { get; }

        private ObservableCollection<PieChartData> _pieChartData;

        public ObservableCollection<PieChartData> PieChartData
        {
            get => _pieChartData;
            set => SetProperty(ref _pieChartData, value);
        }

        public ChartViewModel(DirectoryItemModel directoryItemModel, NavigationStore navigationStore) 
        {
            _directoryItemModel = directoryItemModel;

            NavigateHomeCommand = new NavigateMainCommand(navigationStore);

            PieChartValues = new ObservableCollection<PieChartData>();

            FileTypeSizes = CountFileTypes(directoryItemModel.Path);

            PieChartData = new ObservableCollection<PieChartData>
            {
                new PieChartData { Title = "Maria", Value = 3 },
                new PieChartData { Title = "Charles", Value = 4 },
                new PieChartData { Title = "Frida", Value = 6 },
                new PieChartData { Title = "Frederic", Value = 2 }
            };
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
