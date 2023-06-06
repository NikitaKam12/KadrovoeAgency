using Kurssovay_1.Bases;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Kurssovay_1.Veiws
{
    public partial class LcApplicant : Page
    {
        public LcApplicant()
        {
            InitializeComponent();
            ComboStatus.ItemsSource = KadrovoeEntities.GetContext().Status_.ToList();

            saveLogin.Content = App.Current.Resources["TextLogin"];
            var account = KadrovoeEntities.GetContext().Accounts.Where(x => x.login_ == saveLogin.Content.ToString()).FirstOrDefault();
            if (account != null)
            {
                var applicant = KadrovoeEntities.GetContext().Applicant.Where(x => x.id_account == account.id_account).FirstOrDefault();
                if (applicant != null)
                {
                    var advertisement = KadrovoeEntities.GetContext().Advertisement.Where(x => x.id_applicant == applicant.id_applicant).FirstOrDefault();
                    if (advertisement != null)
                        ApplicantsGrid.ItemsSource = KadrovoeEntities.GetContext().Statements1.Where(x => x.id_advertisement == advertisement.id_advertisement).ToList();
                }
            }
        }

        private void BtnAppl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_ClickOUT(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void My_ADV(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MyADV());
        }

        private void ApplicantsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectGrid = ApplicantsGrid.SelectedItem as Statements1;
            if (selectGrid != null)
            {
                ComboStatus.IsEnabled = true;
                if (selectGrid.id_status == 1)
                    ComboStatus.SelectedIndex = 0;
                if (selectGrid.id_status == 2)
                    ComboStatus.SelectedIndex = 1;
                if (selectGrid.id_status == 3)
                    ComboStatus.SelectedIndex = 2;
            }
        }

        private void ComboStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ApplicantsGrid.SelectedItem as Statements1;
            var selectedItemComboBox = ComboStatus.SelectedItem as Status_;

            if (selectedItem != null && selectedItemComboBox != null)
            {
                selectedItem.id_status = selectedItemComboBox.id_status;

                KadrovoeEntities.GetContext().SaveChanges();
                var account = KadrovoeEntities.GetContext().Accounts.Where(x => x.login_ == saveLogin.Content.ToString()).FirstOrDefault();
                if (account != null)
                {
                    var applicant = KadrovoeEntities.GetContext().Applicant.Where(x => x.id_account == account.id_account).FirstOrDefault();
                    if (applicant != null)
                    {
                        var advertisement = KadrovoeEntities.GetContext().Advertisement.Where(x => x.id_applicant == applicant.id_applicant).FirstOrDefault();
                        if (advertisement != null)
                            ApplicantsGrid.ItemsSource = KadrovoeEntities.GetContext().Statements1.Where(x => x.id_advertisement == advertisement.id_advertisement).ToList();
                    }
                }
            }
        }
    }
}
