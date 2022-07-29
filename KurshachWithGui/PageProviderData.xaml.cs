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
    /// <summary>
    /// Логика взаимодействия для PageProviderData.xaml
    /// </summary>
    public partial class PageProviderData : Page
    {
        public PageProviderData()
        {
            InitializeComponent();
            Provider obj = new Provider();
            obj.ReadDataFromFile();
            ProviderDataGrid.ItemsSource = obj.GetData();
        }

        private void SaveProviderData(object sender, RoutedEventArgs e)
        {
            List<ProviderFields> DataOnForm = (List<ProviderFields>)ProviderDataGrid.ItemsSource;
            Provider obj = new Provider();
            obj.SetData(DataOnForm);
            obj.RewriteDataFile();
        }

        private void SearchProviderData(object sender, RoutedEventArgs e)
        {
            List<ProviderFields> DataOnForm = (List<ProviderFields>)ProviderDataGrid.ItemsSource;
            Provider obj = new Provider();
            obj.SetData(DataOnForm);
            DataOnForm = obj.SearchByKey(InputSearch.Text);
            ProviderDataGrid.ItemsSource = DataOnForm;
        }

        private void InputSearch_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (InputSearch.Text == "")
            {
                Provider obj = new Provider();
                obj.ReadDataFromFile();
                ProviderDataGrid.ItemsSource = obj.GetData();
            }
            else if (InputSearch.Text != "") 
            {
                List<ProviderFields> DataOnForm = (List<ProviderFields>)ProviderDataGrid.ItemsSource;
                Provider objs = new Provider();

                objs.ReadDataFromFile();
                DataOnForm = objs.SearchByKey(InputSearch.Text.ToString());
                ProviderDataGrid.ItemsSource = DataOnForm;
            }
        }

    }
}
