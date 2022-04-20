using Microsoft.Win32;
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
using System.Windows.Threading;

namespace Skrivebordet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int currentImgIndex = 0;
        public MainWindow()
        {
            InitializeComponent();
            fileNameList.ItemsSource = ImageHandler.ImagePaths;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += OnTick;
            timer.Start();
        }

        private void OnTick(object? sender, EventArgs e)
        {

            DateTime? nexttime = Scheduler.GetNextTime();

            if (nexttime != null)
            {
                nextTimeLabel.Content = nexttime.ToString();
                if (ImageHandler.ImagePaths.Count > 0)
                {
                    BackgroundChanger.ChangeWallpaper(ImageHandler.ImagePaths[currentImgIndex]);

                    currentImgIndex = (currentImgIndex + 1) % ImageHandler.ImagePaths.Count;
                }                
            }
        }

        private void LoadFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Images|*.jpg;*.jpeg;*.png;";
            openFileDialog.ShowDialog();
            
            if (!string.IsNullOrWhiteSpace(openFileDialog.FileName))
            {
                ImageHandler.ImagePaths.Add(openFileDialog.FileName);
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            string imagePath = (string)fileNameList.Items[fileNameList.SelectedIndex];
            if (!string.IsNullOrWhiteSpace (imagePath))
            {
                ImageHandler.ImagePaths.Remove(imagePath);
            }
        }
    }
}
