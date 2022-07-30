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
    public partial class PageCarData : Page
    {
        public PageCarData()
        {
            InitializeComponent();
            CarsService carsService = new CarsService();
            carsService.ReadDataFromFile();
            CarDataGrid.ItemsSource = carsService.GetData();
        }

        private void SaveCarData(object sender, RoutedEventArgs e)
        {
            CarsService carsService = new CarsService();
            List<Car> DataOnForm = (List<Car>)CarDataGrid.ItemsSource;
            carsService.SetData(DataOnForm);
            carsService.RewriteDataFile();
        }

        private void InputSearch_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            CarsService carsService = new CarsService();
            carsService.ReadDataFromFile();
            if (InputSearch.Text == "")
            {
                CarDataGrid.ItemsSource = carsService.GetData();
            }
            else if (InputSearch.Text != "")
            {
                CarDataGrid.ItemsSource = carsService.SearchByKey(InputSearch.Text.ToString());
            }
        }
    }
}
