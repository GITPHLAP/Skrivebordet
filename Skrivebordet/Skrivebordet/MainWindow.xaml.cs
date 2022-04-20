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

        private void dailyCheckBox_Click(object sender, RoutedEventArgs e)
        {
            BackgroundScheduler.IsDaily = dailyCheckBox.IsChecked ?? false;
        }

        private void weeklyCheckbox_Click(object sender, RoutedEventArgs e)
        {
            BackgroundScheduler.IsWeekly = weeklyCheckbox.IsChecked ?? false;
        }

        private void hourCheckBox_Click(object sender, RoutedEventArgs e)
        {
            BackgroundScheduler.IsHourly = hourCheckBox.IsChecked ?? false;
        }
    }
}
