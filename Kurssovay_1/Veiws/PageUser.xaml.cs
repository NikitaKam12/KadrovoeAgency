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
    /// Логика взаимодействия для PageUser.xaml
    /// </summary>
    public partial class PageUser : Page
    {
        public PageUser()
        {
            InitializeComponent();
        }

       // DataUsers accountId = new DataUsers();

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //MessageBox.Show(accountId.id.ToString());
           UsersGrid.ItemsSource= Connects.db.Accounts.ToList();
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UsersGrid.ItemsSource = Connects.db.Applicant.ToList();
        }

        private void Button_Click_Create(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Create_Position());
        }
    }
}
