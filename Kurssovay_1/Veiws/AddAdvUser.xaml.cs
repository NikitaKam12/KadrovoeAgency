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
    /// Логика взаимодействия для AddAdvUser.xaml
    /// </summary>
    public partial class AddAdvUser : Page
    {
        public Advertisement advertisement = new Advertisement();
        public Positions positions = new Positions();
        public Applicant applicant = new Applicant();
        public AddAdvUser()
        {
            InitializeComponent();
            Combo2.ItemsSource = KadrovoeEntities.GetContext().Positions.ToList();
            saveLogin.Content = App.Current.Resources["TextLogin"];
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var position = Combo2.ItemsSource as Positions;
            var combo2 = Combo2.SelectedItem as Positions;
            var ps1 = positions.id_position;
            MessageBox.Show(ps1.ToString());
            MessageBox.Show(applicant.id_applicant.ToString());
            advertisement.id_position = combo2.id_position;
            var account = KadrovoeEntities.GetContext().Accounts.Where(x => x.login_ == saveLogin.Content.ToString()).FirstOrDefault();
            if (account != null)
            {
                var applicant = KadrovoeEntities.GetContext().Applicant.Where(x => x.id_account == account.id_account).FirstOrDefault();
                if (applicant != null)
                    advertisement.id_applicant = applicant.id_applicant;
            }
            KadrovoeEntities.GetContext().Advertisement.Add(advertisement);
            KadrovoeEntities.GetContext().SaveChanges();
            MessageBox.Show("Вы сохранили свое обьявление");
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = calendar1.SelectedDate;
            advertisement.date_of_application = selectedDate.Value.Date;
            MessageBox.Show(selectedDate.Value.Date.ToShortDateString());
        }

        private void listUserAdv_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LcApplicant());
        }
    }
}
