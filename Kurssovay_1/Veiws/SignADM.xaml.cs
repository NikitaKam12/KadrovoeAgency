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
    /// Логика взаимодействия для SignADM.xaml
    /// </summary>
    public partial class SignADM : Page
    {
        public SignADM()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Accounts CurrentUser = Connects.db.Accounts.FirstOrDefault(u => u.login_ == Login.Text && u.password_ == Password.Password);
            if (CurrentUser != null)
            { if (CurrentUser.id_account == 1 && CurrentUser.password_ == "1111")
                {
                    Session.UserID = CurrentUser.id_account;
                    NavigationService.Navigate(new WelcomPage());           //Авторизация администратора
                }
                else
                {
                    MessageBox.Show("Данного Администратора нет в базе");
                    Login.Text = "";
                    Password.Password = "";
                }
            }
                       
        }

        private void BtnOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
