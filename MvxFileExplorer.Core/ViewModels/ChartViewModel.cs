using LiveCharts;
using LiveCharts.Definitions.Series;
using MvvmCross.ViewModels;
using MvxFileExplorer.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvxFileExplorer.Core.ViewModels
{
    public class ChartViewModel : MvxViewModel
    {
        public ObservableCollection<PieChartData> PieChartValues { get; set; }

        public string Title { get; set; }

        public int Value { get; set; }

        public ChartViewModel() 
        {
            PieChartValues = new ObservableCollection<PieChartData>
            {
                new PieChartData { Title = "Category 1", Value = 10 },
                new PieChartData { Title = "Category 2", Value = 20 },
                new PieChartData { Title = "Category 3", Value = 30 },
                new PieChartData { Title = "Category 4", Value = 40 }
            };
        }
    }
}
