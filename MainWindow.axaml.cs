using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Net;
using System.Runtime.InteropServices;
using System.IO;
using Wallhaven_Random_Wallpaper.Methods;
using System.Threading.Tasks;
using Wallhaven_Random_Wallpaper.Models;
using System.Threading;
using Quartz.Impl;
using Quartz;
using ReactiveUI;
using System.Reactive;

namespace Wallhaven_Random_Wallpaper
{
    public partial class MainWindow : Window
    {
        const string apiQuery = "https://wallhaven.cc/api/v1/search?categories=111&purity=110&ratios=landscape&sorting=hot&order=desc";
        public MainWindow()
        {
            InitializeComponent();
            DoTheThing = ReactiveCommand.Create(Close);
#if DEBUG
            this.AttachDevTools();
#endif
        }
        public ReactiveCommand<Unit, Unit> DoTheThing { get; }

        private void InitializeComponent()
        {

            AvaloniaXamlLoader.Load(this);

        }
        public void button_Click(object sender, RoutedEventArgs e)
        {
            Temperatures temperatures = new Temperatures();
            string path = Path.GetTempPath();
            Thread backgroundSetWallpaper = new Thread(data => Wallpaper.SetWallpaperFromQuery(path, apiQuery));
            backgroundSetWallpaper.Start();
        }
        public void checkBox_Click(object sender, RoutedEventArgs e)
        {
            // Change button text when button is clicked.
            var checkbox = (CheckBox)sender;
            if (checkbox.IsChecked != null)
            {
                if (checkbox.IsChecked == true)
                {
                    Close(this);
                }
                else
                {
                    //reset from baackground
                }
            }

        }
        public void closeApplication_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            // todo: not working TrayIcon. May be it`s bug of framework
        }
    }
}