using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для PageDetailData.xaml
    /// </summary>
    public partial class PageDetailData : Page
    {
        public ObservableCollection<MarkWithID> markWithIDs { get; set; }
        public ObservableCollection<ProviderWithID> providerWithIDs { get; set; }
        public PageDetailData()
        {
            InitializeComponent();

            DetailsService detailsService = new DetailsService();
            CarsService carsService = new CarsService();
            ProvidersService providerService = new ProvidersService();
            
            detailsService.ReadDataFromFile();
            carsService.ReadDataFromFile();
            providerService.ReadDataFromFile();

            DetailDataGrid.ItemsSource = detailsService.GetData();
            markWithIDs = carsService.GetDataMark();
            providerWithIDs = providerService.GetDataProvider();
        }

        private void SaveDetailData(object sender, RoutedEventArgs e)
        {
            List<Detail> dataOnForm = (List<Detail>)DetailDataGrid.ItemsSource;
            DetailsService detailsService = new DetailsService();
            detailsService.SetData(dataOnForm);
            detailsService.RewriteDataFile();
        }

        private void InputSearch_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            DetailsService detailsService = new DetailsService();
            detailsService.ReadDataFromFile();
            if (InputSearch.Text == "")
            {
                DetailDataGrid.ItemsSource = detailsService.GetData();
            }
            else if (InputSearch.Text != "")
            {
                DetailDataGrid.ItemsSource = detailsService.SearchByKey(InputSearch.Text.ToString());
            }
        }
    }
}
