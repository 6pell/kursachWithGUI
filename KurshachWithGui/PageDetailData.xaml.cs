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
        public ObservableCollection<MarkWithID> marks { get; set; }
        public PageDetailData()
        {
            InitializeComponent();
            Detail objsDetail = new Detail();
            Machina objsCars = new Machina();
            objsDetail.ReadDataFromFile();
            objsCars.ReadDataFromFile();

            List<DetailFields> list = objsDetail.GetData();
            DetailDataGrid.ItemsSource = list;

            marks = objsCars.GetDataMark();
        }

        private void SaveDetailData(object sender, RoutedEventArgs e)
        {
            List<DetailFields> DataOnForm = (List<DetailFields>)DetailDataGrid.ItemsSource;
            Detail objs = new Detail();
            objs.SetData(DataOnForm);
            objs.RewriteDataFile();
        }

        private void InputSearch_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (InputSearch.Text == "")
            {
                Detail objs = new Detail();
                objs.ReadDataFromFile();
                DetailDataGrid.ItemsSource = objs.GetData();
            }
            else if (InputSearch.Text != "")
            {
                List<DetailFields> DataOnForm = (List<DetailFields>)DetailDataGrid.ItemsSource;
                Detail objs = new Detail();
                objs.ReadDataFromFile();
                DataOnForm = objs.SearchByKey(InputSearch.Text.ToString());
                DetailDataGrid.ItemsSource = DataOnForm;
            }
        }
    }
}
