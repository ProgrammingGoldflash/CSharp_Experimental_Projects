using FileExplorer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace FileExplorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ObservableCollection<Tabulator> tabulators = new ObservableCollection<Tabulator>()
            {
                new Tabulator("Test"),
                new Tabulator("Hallo")
            };

            ExplorerManager.ItemsSource = tabulators;
        }

        private void Path_LostFocus(object sender, RoutedEventArgs e)
        {
            ObservableCollection<DirectoryItem> items = new ObservableCollection<DirectoryItem>();

            foreach (var directory in Directory.GetDirectories(((TextBox)sender).Text))
            {
                DirectoryInfo info = new DirectoryInfo(directory);
                items.Add(new DirectoryItem(info.Name, "Dateiordner", 0, info.LastWriteTime));
            }

            foreach (var file in Directory.GetFiles(((TextBox)sender).Text))
            {
                FileInfo info = new FileInfo(file);
                items.Add(new DirectoryItem(info.Name, info.Extension, info.Length, info.LastWriteTime));
            }

            ((((TextBox)sender).Parent as StackPanel).Children[1] as DataGrid).ItemsSource = items;
        }
    }
}
