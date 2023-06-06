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
    /// Логика взаимодействия для MyADV.xaml
    /// </summary>
    public partial class MyADV : Page
    {
        public MyADV()
        {
            InitializeComponent();
            saveLogin.Content = App.Current.Resources["TextLogin"];
            var account = KadrovoeEntities.GetContext().Accounts.Where(x => x.login_ == saveLogin.Content.ToString()).FirstOrDefault();
            if (account != null)
            {
                var applicant = KadrovoeEntities.GetContext().Applicant.Where(x => x.id_account == account.id_account).FirstOrDefault();
                if (applicant != null)
                {
                    var item = KadrovoeEntities.GetContext().Advertisement.Where(x => x.id_applicant == applicant.id_applicant).ToList();
                    MyADVGrid.ItemsSource = item;
                }
            }
        }

        private void Button_ClickOUT(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void My_ADV_Loaded(object sender, RoutedEventArgs e)
        { 
        
        }
    }
}
