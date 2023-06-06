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
    /// Логика взаимодействия для Create_Position.xaml
    /// </summary>
    public partial class Create_Position : Page
    {
        public Create_Position()
        {
            InitializeComponent();
        }

        private void Create_(object sender, RoutedEventArgs e)
        { 
        
        }
        private Positions positions = new Positions();


        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            positions.position = Proffesion.Text;
            KadrovoeEntities.GetContext().Positions.Add(positions);
            KadrovoeEntities.GetContext().SaveChanges();
        }

        private void Go_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
