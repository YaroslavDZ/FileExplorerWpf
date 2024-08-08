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
using Syncfusion.UI.Xaml.Charts;
using MvxFileExplorer.Core.Models;
using MvxFileExplorer.Core.Stores;

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

            /*SfChart chart = new SfChart();
            ViewModel viewModel = new ViewModel();
            chart.DataContext = viewModel;
            chart.Header = "Weight Report";
            chart.Legend = new ChartLegend();

            // Defining the PieSeries with adornments.
            PieSeries series = new PieSeries();
            series.XBindingPath = "Name";
            series.YBindingPath = "Weight";
            series.ItemsSource = viewModel.Data;
            series.AdornmentsInfo = new ChartAdornmentInfo()
            {
                ShowLabel = true
            };
            chart.Series.Add(series);*/
        }
    }
}
