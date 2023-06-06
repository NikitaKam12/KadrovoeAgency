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
using Kurssovay_1.Bases;

namespace Kurssovay_1.Veiws
{
    /// <summary>
    /// Логика взаимодействия для ChangeAdvADM.xaml
    /// </summary>
    public partial class ChangeAdvADM : Page
    {
        private Advertisement _currentAdvertisement = new Advertisement();

        public ChangeAdvADM(Advertisement x)
        {
            InitializeComponent();
            Date.Text = x.date_of_application.ToString();
            Position.ItemsSource = KadrovoeEntities.GetContext().Positions.ToList();

            if (x != null)
            {
                _currentAdvertisement = x;
            }
            DataContext = _currentAdvertisement;
            
        }

      
        private void Button_ClickOUT(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //сохранение редактирования
            try
            {
                KadrovoeEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные отредактированы");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
