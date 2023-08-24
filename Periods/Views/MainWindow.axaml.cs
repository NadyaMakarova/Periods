using Avalonia.Controls;
using Avalonia.Interactivity;
using Periods.ViewModels;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Drawing;
using Avalonia.Input;
using ScottPlot.Avalonia;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using System.Collections.Generic;

namespace Periods.Views
{
    public partial class MainWindow : Window
    {
        public MainWindowViewModel MainWindowViewModel => DataContext as MainWindowViewModel;

        public MainWindow()
        {
            InitializeComponent();

            //MainWindowViewModel = new MainWindowViewModel();
            //DataContext = MainWindowViewModel;
            //var comboBox = this.FindControl<ComboBox>("comboBox");
            //comboBox.DataContext = mainWindow;
        }

        //public void SelectionChanged(object sender, SelectionChangedEventArgs args)
        //{
        //    if ((sender as ComboBox).DataContext != null)
        //        ((sender as ComboBox).DataContext as TypeOperationViewModel).Lyambda = Convert.ToDouble(((args.AddedItems[0] as ComboBoxItem).Content as TextBlock).Text);
        //    //MainWindowViewModel.
        //    //var json = JsonConvert.SerializeObject(ViewModel.DtConfiguration);
        //    //File.WriteAllText("Models\\DtConfiguration.json", json);
        //}


        public async void Clicked(object sender, RoutedEventArgs args)
        {
            try
            {
                AvaPlot avaPlot1 = this.Find<AvaPlot>("AvaPlot1");
                avaPlot1.Plot.Clear();
                double F = 0.828944;
                double Y = Convert.ToDouble(MainWindowViewModel.Y);
                double S = 1;
                double tCurr = 0;
                double sum = 0;
                var xList = new List<double>();
                var yList = new List<double>();
                var yListUp = new List<double>();
                var yListDown = new List<double>();
                //foreach (var row in dataGridView1.Rows)
                //{
                //    var d = Convert.ToInt32((row as DataGridViewRow).Cells[1].Value);
                //    Y -= d;
                //    S *= (Y - d) / Y;
                //}
                //Y = Convert.ToInt32(textBox2.Text);
                var sigma = S * Math.Sqrt(sum);
                foreach (var period in MainWindowViewModel.Periods)
                {
                    sigma = S * Math.Sqrt(sum);
                    period.S = S;
                    period.Sigma = sigma;
                    xList.Add(tCurr);
                    yList.Add(S);
                    yListUp.Add(S + sigma * F);
                    yListDown.Add(S - sigma * F);
                    //var newPoint = new DataPoint(tCurr, S);
                    //chart1.Series[0].Points.Add(newPoint);
                    //var newPointUp = new DataPoint(tCurr, S + sigma * F);
                    //var newPointDown = new DataPoint(tCurr, S - sigma * F);
                    //chart1.Series[1].Points.Add(newPointUp);
                    //chart1.Series[2].Points.Add(newPointDown);
                    Y -= Convert.ToDouble(period.D);
                    sum += Convert.ToDouble(period.D) / (Y * (Y - Convert.ToDouble(period.D)));
                    S *= (Y - Convert.ToDouble(period.D)) / Y;
                    tCurr += Convert.ToDouble(period.Time);
                }
                xList.Add(tCurr);
                yList.Add(S);
                yListUp.Add(S + sigma * F);
                yListDown.Add(S - sigma * F);
                avaPlot1.Plot.AddScatterStep(xList.ToArray(), yList.ToArray());
                avaPlot1.Plot.AddScatterStep(xList.ToArray(), yListUp.ToArray());
                avaPlot1.Plot.AddScatterStep(xList.ToArray(), yListDown.ToArray());
                avaPlot1.Refresh();
            }
            catch
            {

            }
        }
    }

}
