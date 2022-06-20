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
using System.Windows.Shapes;
using SiMS_projekat.Controller;
using SiMS_projekat.Model;

namespace SiMS_projekat.View
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Window
    {
        private UserController userController = new UserController();
        private int id;
        public RegistrationPage(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void registrationBtn_Click(object sender, RoutedEventArgs e)
        {
            if(jmbgTextBox.Text == "" || nameTextBox.Text == "" || surnameTextBox.Text == "" || 
               emailTextBox.Text == "" || passwordTextBox.Text == "" || mobileTextBox.Text == "" || 
               comboBox.Text == "")
            {
                MessageBox.Show("Unesite sve navedene podatke!");
                return;
            }

            if(jmbgTextBox.Text.Length != 13)
            {
                MessageBox.Show("Potrebno je da unesete 13 karaktera za JMBG!");
                return;
            }

            bool checkJmbgEmail = checkJmbgOrEmail(jmbgTextBox.Text, emailTextBox.Text);
            if (checkJmbgEmail)
            {
                MessageBox.Show("Uneli ste vec postojeci E-mail ili JMBG!");
                return;
            }
            User user = new User();
            user.UserId = id;
            user.Jmbg = jmbgTextBox.Text;
            user.Name = nameTextBox.Text;
            user.Surname = surnameTextBox.Text;
            user.Email = emailTextBox.Text;
            user.Password = passwordTextBox.Text;
            user.MobilePhone = mobileTextBox.Text;
            user.UserType = comboBox.Text;
            user.Blocked = (bool) blockedCheckBox.IsChecked;
            userController.Add(user);
            ViewAllUsersPage.usersDataGrid.ItemsSource = userController.GetAll();
            this.Hide();

        }

        public bool checkJmbgOrEmail(String jmbg, String email)
        {
            List<User> users = userController.GetAll();
            for(int i = 0; i < users.Count(); i++)
            {
                if(users[i].Jmbg == jmbg || users[i].Email == email)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
