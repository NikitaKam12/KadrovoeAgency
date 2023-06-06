using Kurssovay_1.Bases;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Kurssovay_1.Veiws
{
    /// <summary>
    /// Логика взаимодействия для LcEmployer.xaml
    /// </summary>
    public partial class LcEmployer : Page
    {
        public LcEmployer()
        {
            InitializeComponent();
            saveLogin.Content = App.Current.Resources["TextLogin"];
            ComboStatus.ItemsSource = KadrovoeEntities.GetContext().Status_.ToList();
            var account = KadrovoeEntities.GetContext().Accounts.Where(x => x.login_ == saveLogin.Content.ToString()).FirstOrDefault();
            if (account != null)
            {
                var employer = KadrovoeEntities.GetContext().Employer.Where(x=>x.id_account == account.id_account).FirstOrDefault();
                var vacancies = KadrovoeEntities.GetContext().Vacancies.Where(x => x.id_employer == employer.id_employer).FirstOrDefault();
                if(employer != null)
                {
                    ApplicantsGrid.ItemsSource = KadrovoeEntities.GetContext().Statements.Where(x=> x.id_vacancies == vacancies.id_vacancies).ToList();
                }
            }
        }

        private void Button_ClickOUT(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnAppl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ApplicantsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectGrid = ApplicantsGrid.SelectedItem as Statements;
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
            var selectedItem = ApplicantsGrid.SelectedItem as Statements;
            var selectedItemComboBox = ComboStatus.SelectedItem as Status_;

            if (selectedItem != null && selectedItemComboBox != null)
            {
                selectedItem.id_status = selectedItemComboBox.id_status;

                KadrovoeEntities.GetContext().SaveChanges();
                var account = KadrovoeEntities.GetContext().Accounts.Where(x => x.login_ == saveLogin.Content.ToString()).FirstOrDefault();
                if (account != null)
                {
                    var employer = KadrovoeEntities.GetContext().Employer.Where(x => x.id_account == account.id_account).FirstOrDefault();
                    var vacancies = KadrovoeEntities.GetContext().Vacancies.Where(x => x.id_employer == employer.id_employer).FirstOrDefault();
                    if (employer != null)
                    {
                        ApplicantsGrid.ItemsSource = KadrovoeEntities.GetContext().Statements.Where(x => x.id_vacancies == vacancies.id_vacancies).ToList();
                    }
                }
            }
        }
    }
}
