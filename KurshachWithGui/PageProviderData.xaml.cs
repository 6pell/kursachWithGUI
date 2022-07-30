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
            ProvidersService providersService = new ProvidersService();
            providersService.ReadDataFromFile();
            ProviderDataGrid.ItemsSource = providersService.GetData();
        }

        private void SaveProviderData(object sender, RoutedEventArgs e)
        {
            List<Provider> DataOnForm = (List<Provider>)ProviderDataGrid.ItemsSource;
            ProvidersService providersService = new ProvidersService();
            providersService.SetData(DataOnForm);
            providersService.RewriteDataFile();
        }

        private void InputSearch_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            ProvidersService providersService = new ProvidersService();
            providersService.ReadDataFromFile();
            if (InputSearch.Text == "")
            {
                ProviderDataGrid.ItemsSource = providersService.GetData();
            }
            else if (InputSearch.Text != "") 
            {
                ProviderDataGrid.ItemsSource = providersService.SearchByKey(InputSearch.Text.ToString());
            }
        }

    }
}
