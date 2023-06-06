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
    /// Логика взаимодействия для Create_VCN.xaml
    /// </summary>
    public partial class Create_VCN : Page
    {
        public Create_VCN()
        {
            InitializeComponent();
            saveLogin.Content = App.Current.Resources["TextLogin"];
            Combo2.ItemsSource = KadrovoeEntities.GetContext().Positions.ToList();
        }

        private void Go_Out(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private Vacancies vacancies = new Vacancies();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectCombo = Combo2.SelectedItem as Positions;
            if (selectCombo != null)
            {
                vacancies.exp_required = int.Parse(Exp_Required.Text);
                vacancies.request = Request.Text;
                vacancies.id_position = selectCombo.id_position;
                vacancies.name_vacancies = Name_vacancies.Text;
                var account = KadrovoeEntities.GetContext().Accounts.Where(x => x.login_ == saveLogin.Content.ToString()).FirstOrDefault();
                if (account != null)
                {
                    var employer = KadrovoeEntities.GetContext().Employer.Where(x => x.id_account == account.id_account).FirstOrDefault();
                    vacancies.id_employer = employer.id_employer;
                }
                KadrovoeEntities.GetContext().Vacancies.Add(vacancies);
                KadrovoeEntities.GetContext().SaveChanges();
            }
        }
    }
}
