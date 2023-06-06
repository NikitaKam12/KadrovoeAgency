using Kurssovay_1.Bases;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        public Applicant applicant = new Applicant();
        public Accounts accounts = new Accounts();
        public AddUserPage()
        {
            InitializeComponent();
            Combo1.ItemsSource = KadrovoeEntities.GetContext().Positions.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (KadrovoeEntities.GetContext().Accounts.Count(x => x.login_ == Login.Text) > 0)
            {
                MessageBox.Show("Пользователь уже существует");
                Login.Clear();
                Password.Clear();
                
            }
            else
            {// Необходимо добавить проверку вводимой информации
                accounts.login_ = Login.Text;
                accounts.password_ = Password.Password;
                accounts.role_user = 2;
                applicant.sex = Sex_box.Text;
                applicant.surname = FirstName.Text;
                applicant.first_name = Name.Text;
                string str = Expwork.Text;//вводим число в базу
                applicant.exp_work = int.Parse(str);//
                var positions = Combo1.SelectedItem as Positions;
                applicant.skills = positions.position;
                KadrovoeEntities.GetContext().Applicant.Add(applicant);
                KadrovoeEntities.GetContext().Accounts.Add(accounts);
                try
                {
                    KadrovoeEntities.GetContext().SaveChanges(); //
                }
                catch (DbEntityValidationException ex) //
                {
                    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors) //
                    {
                        MessageBox.Show("Object: " + validationError.Entry.Entity.ToString()); //
                        MessageBox.Show(" ");
                        foreach (DbValidationError err in validationError.ValidationErrors) //
                        {
                            MessageBox.Show(err.ErrorMessage + " "); // Проверка на ошибку 
                        }
                    }
                } 
                MessageBox.Show("Пользователь добавлен");

            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Sing1Page());
        }

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
