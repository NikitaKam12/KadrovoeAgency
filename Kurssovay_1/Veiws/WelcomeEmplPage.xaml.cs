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

namespace Kurssovay_1.Veiws
{
    /// <summary>
    /// Логика взаимодействия для WelcomeEmplPage.xaml
    /// </summary>
    public partial class WelcomeEmplPage : Page
    {
        public WelcomeEmplPage()
        {
            InitializeComponent();
        }

        private void UsersData_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LcEmployer());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ApplicantUser());
            //Вывести обьявления соискателей в нормальной форме 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
