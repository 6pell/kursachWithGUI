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
            Machina objs = new Machina();
            objs.ReadDataFromFile();
            List<Automobile>cars = objs.GetData();
            CarDataGrid.ItemsSource = cars;
        }

        private void SaveCarData(object sender, RoutedEventArgs e)
        {
            List<Automobile> DataOnForm = (List<Automobile>)CarDataGrid.ItemsSource;
            Machina objs = new Machina();
            objs.SetData(DataOnForm);
            objs.RewriteDataFile();
        }

        private void InputSearch_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            
            if (InputSearch.Text == "")
            {
                Machina objs = new Machina();
                objs.ReadDataFromFile();
                List<Automobile> cars = objs.GetData();
                CarDataGrid.ItemsSource = cars;
            }
            else if (InputSearch.Text != "")
            {
                List<Automobile> DataOnForm = (List<Automobile>)CarDataGrid.ItemsSource;
                Machina objs = new Machina();
                objs.ReadDataFromFile();
                DataOnForm = objs.SearchByKey(InputSearch.Text.ToString());
                CarDataGrid.ItemsSource = DataOnForm;
            }
        }
    }
}
