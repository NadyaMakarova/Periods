using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Npgsql;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Information;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Input;

namespace Periods.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        object? _n;
        public string Greeting => "Welcome to Avalonia!";

        public List<PeriodViewModel> Periods { get; set; }

        public ICommand CalculationCommand { get; set; }

        //public object? Y { get; set; }

        public object? Y { get; set; }

        //public object? Pob { get; set; }

        //public object? Pi { get; set; }

        //public double? Pop { get; set; }

        //public double? Pisp { get; set; }

        //public double? Pd { get; set; }

        //object? _r;

        public object? N
        {
            get
            {
                return _n;
            }
            set
            {
                if (value == _n)
                    return;
                _n = value;
                try
                {
                    this.RaisePropertyChanged(nameof(N));
                    if (Convert.ToInt32(N) > 0)
                    {
                        Periods = new List<PeriodViewModel>();
                        for (int i = 1; i <= Convert.ToInt32(N); i++)
                        {
                            Periods.Add(new PeriodViewModel((i).ToString(), (i)));
                        }
                        this.RaisePropertyChanged(nameof(Periods));
                    }
                }
                catch
                {
                }
            }
        }



        public MainWindowViewModel()
        {
            try
            {
                Periods = new List<PeriodViewModel>();
                CalculationCommand = ReactiveCommand.Create(Calculation);
            }
            catch
            {

            }
        }

        //public void AddElements(int index)
        //{
        //    try
        //    {
        //        var newList = new List<PeriodViewModel>();
        //        var periods = new List<PeriodViewModel>();
        //        for (int i = 0; i < index; i++)
        //        {
        //            var newElement = new PeriodViewModel((i + 1).ToString(), (i + 1));
        //            periods.Add(newElement);
        //        }
        //        Periods = new List<PeriodViewModel>(periods);
        //        this.RaisePropertyChanged(nameof(Periods));
        //    }
        //    catch
        //    {

        //    }
        //}

        //public void Download(string fileName)
        //{
        //    try
        //    {
        //        var newFile = new FileInfo(fileName);
        //        var Excel_Package = new ExcelPackage(newFile);
        //        var workSheet = Excel_Package.Workbook.Worksheets[0];
        //        var cells = workSheet.Cells;
        //        //foreach (var type in TypeOperations)
        //        //{
        //        //    type.AddData(cells);
        //        //}
        //        Pk = Convert.ToDouble(cells["F3"].Value.ToString().Replace(".", ","));
        //        this.RaisePropertyChanged(nameof(Pk));
        //        Pob = Convert.ToDouble(cells["G3"].Value.ToString().Replace(".", ","));
        //        this.RaisePropertyChanged(nameof(Pob));
        //        Pi = Convert.ToDouble(cells["H3"].Value.ToString().Replace(".", ","));
        //        this.RaisePropertyChanged(nameof(Pi));
        //        this.RaisePropertyChanged(nameof(TypeOperations));

        //    }
        //    catch
        //    {
        //    }
        //}

        public void Calculation()
        {
            try
            {
                
            }
            catch
            {

            }
        }

        //public void Calculation()
        //{
        //    try
        //    {
        //        TypeOperations.ForEach(o => o.Calculation());
        //        Pop = 1;
        //        foreach (var oper in TypeOperations)
        //        {
        //            Pop = Pop * Math.Pow(Convert.ToDouble(oper.P), Convert.ToDouble(oper.k));
        //        }
        //        Pisp = Convert.ToDouble(Pk) * Convert.ToDouble(Pob) * Convert.ToDouble(Pi);
        //        Pd = Pop + (1 - Pop) * Pisp;
        //        this.RaisePropertyChanged(nameof(Pop));
        //        this.RaisePropertyChanged(nameof(Pisp));
        //        this.RaisePropertyChanged(nameof(Pd));
        //    }
        //    catch
        //    {

        //    }
        //}

    }
}
