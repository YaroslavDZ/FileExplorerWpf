using LiveCharts.Wpf;
using LiveCharts;
using MvvmCross.Platforms.Wpf.Views;
using MvxFileExplorer.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MvxFileExplorer.Wpf.Views
{
    /// <summary>
    /// Interaction logic for ChartView.xaml
    /// </summary>
    public partial class ChartView : MvxWpfView
    {
        public ChartView()
        {
            InitializeComponent();
            Loaded += PieChart_Loaded;
        }

        private void PieChart_Loaded(object sender, RoutedEventArgs e)
        {
            UpdatePieChart();
        }

        private void UpdatePieChart()
        {
            var viewModel = DataContext as ChartViewModel;

            if (viewModel == null || viewModel.FileTypeSizes == null)
            {
                return;
            }

            var seriesCollection = new SeriesCollection();

            foreach (var data in viewModel.FileTypeSizes)
            {
                seriesCollection.Add(new PieSeries
                {
                    Title = data.Key,
                    Values = new ChartValues<double> { data.Value },
                    DataLabels = true
                });
            }

            viewModel.Series = seriesCollection;
        }
    }
}
