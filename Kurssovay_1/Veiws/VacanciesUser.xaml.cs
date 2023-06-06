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
    /// Логика взаимодействия для VacanciesUser.xaml
    /// </summary>
    public partial class VacanciesUser : Page
    {
        public VacanciesUser()
        {
            InitializeComponent();
            saveLogin.Content = App.Current.Resources["TextLogin"];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private Statements statements = new Statements();

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
        
            var selected = VacanciesUserGrid.SelectedItem as Vacancies;

            if (selected != null)
            {
                statements.id_vacancies = selected.id_vacancies;
                statements.login_2 = saveLogin.Content.ToString();
                statements.id_status = 1;

                KadrovoeEntities.GetContext().Statements.Add(statements);
                KadrovoeEntities.GetContext().SaveChanges();
            }
        }

        private void Vacancies(object sender, RoutedEventArgs e)
        {
            VacanciesUserGrid.ItemsSource = KadrovoeEntities.GetContext().Vacancies.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddAdvUser());
        }
    }
}
