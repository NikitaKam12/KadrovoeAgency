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
    /// Логика взаимодействия для Employers_ADM.xaml
    /// </summary>
    public partial class Employers_ADM : Page
    {
        public Employers_ADM()
        {
            InitializeComponent();
            ApplicantsGrid.ItemsSource = KadrovoeEntities.GetContext().Vacancies.ToList();
        }

        private void Button_ClickOUT(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        { 
            
        }

        private void Button_Click(object sender,RoutedEventArgs e)
        {
            var selected = ApplicantsGrid.SelectedItem as Vacancies;
            if (selected != null)
            {
                var searchVacancies = KadrovoeEntities.GetContext().Vacancies.FirstOrDefault(x => x.id_vacancies == selected.id_vacancies);

                KadrovoeEntities.GetContext().Vacancies.Remove(searchVacancies);
                KadrovoeEntities.GetContext().SaveChanges();
                ApplicantsGrid.ItemsSource = KadrovoeEntities.GetContext().Vacancies.ToList();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //переход в редактирование
            var x = ApplicantsGrid.SelectedItem as Vacancies;
                if (x != null)
            {
                NavigationService.Navigate(new ChangeVCNADM(x));
            }
        }
    }
}
