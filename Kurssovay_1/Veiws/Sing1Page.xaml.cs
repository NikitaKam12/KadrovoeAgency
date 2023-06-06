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
    /// Логика взаимодействия для Sing1Page.xaml
    /// </summary>
    public partial class Sing1Page : Page
    {
        public Sing1Page()
        {
            InitializeComponent();
        }
        public int id_account;

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Accounts CurrentUser = Connects.db.Accounts.FirstOrDefault(u => u.login_ == Login.Text && u.password_ == Password.Password);
            if (CurrentUser != null)
            {

                if (CurrentUser.role_user != 1)
                {
                    Session.UserID = CurrentUser.id_account;
                    if (CurrentUser.role_user == 2) // проверка кто входит 1 -админ, 2 -соискатель, 3 -работодатель
                    {
                        if (MessageBox.Show("Вы хотите войти как Соискатель?", "Соискатель", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        {
                            MessageBox.Show("Зарегистрируйтесь как Работодатель");
                        }
                        else
                        {
                            App.Current.Resources["TextLogin"] = Login.Text;
                            NavigationService.Navigate(new UserStartPage());// переход на страницу  пользователя
                            Login.Clear();
                            //Login.Text = "";
                            Password.Clear();
                            //Password.Password = "";
                        }
                    }
                    else
                    {

                        if (MessageBox.Show("Вы хотите войти как Работодатель?", "Работодатель", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        {
                            MessageBox.Show("Зарегистрируйтесь как Соискатель");
                        }
                        else
                        {
                            App.Current.Resources["TextLogin"] = Login.Text;
                            NavigationService.Navigate(new WelcomeEmplPage()); //переход на страницу Работодателя
                            //Login.Text = "";
                            //Password.Password = "";
                            Login.Clear();
                            Password.Clear();
                        }


                    }

                }
                else
                {
                    MessageBox.Show("Войдите как Администратор !");
                }



            }
            else
            {
                MessageBox.Show("Данного пользователя нет в базе ! Зарегистрируйтесь !");
                Login.Clear();
                Password.Clear();

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы хотите зарегистрироваться как Соискатель? Если ДА-Соискатель , НЕТ-Работодатель", "Выбор регистрации", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                NavigationService.Navigate(new AddEmployer());
            }
            else
            {
                NavigationService.Navigate(new AddUserPage());
            }
        }

        private void BtnAdm_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignADM());
        }


    }
}



