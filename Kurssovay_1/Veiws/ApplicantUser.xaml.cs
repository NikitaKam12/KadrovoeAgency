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
    /// Логика взаимодействия для ApplicantUser.xaml
    /// </summary>
    public partial class ApplicantUser : Page
    {
        public ApplicantUser()
        {
            InitializeComponent();
            saveLogin.Content = App.Current.Resources["TextLogin"];
        }

        private Statements1 statements1 = new Statements1();
        private void ApplicantUser_Loaded(object sender, RoutedEventArgs e)
        {
            ApplicantsGrid.ItemsSource = KadrovoeEntities.GetContext().Advertisement.ToList();
        }
        private void BtnAppl_Click(object sender, RoutedEventArgs e)
        {
            var selected = ApplicantsGrid.SelectedItem as Advertisement;
            if (selected != null)
            {
                statements1.id_advertisement = selected.id_advertisement;
                statements1.login_1 = saveLogin.Content.ToString();
                statements1.id_status = 1;
                KadrovoeEntities.GetContext().Statements1.Add(statements1);
                KadrovoeEntities.GetContext().SaveChanges();
            }
        }

        private void Button_ClickOUT(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Create(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Create_VCN());
        }
    }
}
