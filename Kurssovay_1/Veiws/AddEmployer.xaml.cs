using System;
using Kurssovay_1.Bases;
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
using System.Text.RegularExpressions;

namespace Kurssovay_1.Veiws
{
    /// <summary>
    /// Логика взаимодействия для AddEmployer.xaml
    /// </summary>
    public partial class AddEmployer : Page
    {
        public Employer employer = new Employer();
        public Accounts accounts = new Accounts();
        public AddEmployer()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (KadrovoeEntities.GetContext().Accounts.Count(x => x.login_ == Login.Text) > 0)
            {
                MessageBox.Show("Пользователь уже существует");
                Login.Text = "";
                Password.Password = "";
            }
            else
            {
                accounts.login_ = Login.Text;
                accounts.password_ = Password.Password;
                accounts.role_user = 3;
                employer.name_company = NameCompany.Text;
                employer.adress_company = Adress.Text;
                employer.email_adress = email_adress.Text;
                // int str1;
                //string str = Expwork.Text;
                //bool success = Int32.TryParse(str, out int str2);
                //if (success)
                //{
                //    applicant.exp_work = str2;
                //}
                //else {
                //    MessageBox.Show("Не прошло");
                //}
                employer.requirements = Phone_Number.Text;
               

                
                KadrovoeEntities.GetContext().Employer.Add(employer);

                KadrovoeEntities.GetContext().Accounts.Add(accounts);

         

                    KadrovoeEntities.GetContext().SaveChanges();

                          // KadrovoeEntities.GetContext().SaveChanges();
                MessageBox.Show("Пользователь добавлен");

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void Login_TextChanged(object sender, RoutedEventArgs e)
        { 
        
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
