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
    /// Логика взаимодействия для ChangeVCNADM.xaml
    /// </summary>
    public partial class ChangeVCNADM : Page
    {
        private Vacancies _currentVacancies = new Vacancies();
        public ChangeVCNADM(Vacancies x)
        {
            InitializeComponent();
            Position.ItemsSource = KadrovoeEntities.GetContext().Positions.ToList();
            Exp_work_need.Text = x.exp_required.ToString();
            Request.Text = x.request.ToString();
            if (x != null)
            {
                _currentVacancies = x;
            }
            DataContext = _currentVacancies;
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                KadrovoeEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные отредактированы");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
