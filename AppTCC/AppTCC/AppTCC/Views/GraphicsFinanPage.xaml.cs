﻿using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTCC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GraphicsFinanPage : ContentPage
    {

        List<Microcharts.ChartEntry> entries = new List<Microcharts.ChartEntry>
        {
            new Microcharts.ChartEntry(200)
            {
                Label = "Janeiro",
                ValueLabel = "200",
                Color = SKColor.Parse("#266489")
            },
            new Microcharts.ChartEntry(250)
            {
                Label = "Fevereiro",
                ValueLabel = "250",
                Color = SKColor.Parse("#68B9C0")
            },
            new Microcharts.ChartEntry(100)
            {
                Label = "Março",
                ValueLabel = "100",
                Color = SKColor.Parse("#90D585")
            },
            new Microcharts.ChartEntry(150)
            {
                Label = "Abril",
                ValueLabel = "150",
                Color = SKColor.Parse("#e77e23")
            }
        };
        public GraphicsFinanPage()
        {
            InitializeComponent();
            Grafico.Chart = new Microcharts.BarChart() { Entries = entries };
        }
    }
}