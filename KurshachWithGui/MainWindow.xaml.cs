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

namespace KurshachWithGui
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void CarDBClicked(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageCarData();
        }
        private void ProviderDBClicked(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageProviderData();
        }
        private void DetailDBProvider(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageDetailData();
        }
    }
}