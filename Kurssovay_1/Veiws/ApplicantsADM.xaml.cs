using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Kurssovay_1.Bases;

namespace Kurssovay_1.Veiws
{
    /// <summary>
    /// Логика взаимодействия для ApplicantsADM.xaml
    /// </summary>
    public partial class ApplicantsADM : Page
    {
        public ApplicantsADM()
        {
            InitializeComponent();
            ApplicantsGrid.ItemsSource = KadrovoeEntities.GetContext().Advertisement.ToList();
        }
        private void BtnAppl_Click(object sender, RoutedEventArgs e)
        {
            //редактирование 
        }

        private void Button_ClickOUT(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click_Create(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Create_Position());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selected = ApplicantsGrid.SelectedItem as Advertisement;
            if (selected != null)
            {
                var searchAdverisement = KadrovoeEntities.GetContext().Advertisement.FirstOrDefault(x=> x.id_advertisement == selected.id_advertisement);
                var searchApplicant = KadrovoeEntities.GetContext().Applicant.FirstOrDefault(x => x.id_applicant == searchAdverisement.id_applicant);

                KadrovoeEntities.GetContext().Advertisement.Remove(searchAdverisement);
                KadrovoeEntities.GetContext().Applicant.Remove(searchApplicant);
                KadrovoeEntities.GetContext().SaveChanges();
                ApplicantsGrid.ItemsSource = KadrovoeEntities.GetContext().Advertisement.ToList();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var x = ApplicantsGrid.SelectedItem as Advertisement;
            if (x != null)
            {
                NavigationService.Navigate(new ChangeAdvADM(x));
            }
            //редактирование
        }
    }
}
