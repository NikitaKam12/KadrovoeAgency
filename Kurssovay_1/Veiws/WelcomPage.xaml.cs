using Kurssovay_1.Bases;
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
    /// Логика взаимодействия для WelcomPage.xaml
    /// </summary>
    public partial class WelcomPage : Page
    {
        public WelcomPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void UsersData_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageUser());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Employers_ADM());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ApplicantsADM());
        }
    }
}
