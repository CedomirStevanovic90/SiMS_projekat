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
    /// Interaction logic for UpdateUserPage.xaml
    /// </summary>
    /// 
    public partial class UpdateUserPage : Window
    {
        private UserController userController = new UserController();
        private int id;
        private User user;
        private List<User> users;
        public UpdateUserPage(int id)
        {
            InitializeComponent();
            this.id = id;
            users = userController.GetAll();
            for (int i = 0; i < users.Count(); i++)
            {
                if (users[i].UserId == id)
                {
                    user = users[i];
                }
            }
            jmbgTextBox.Text = user.Jmbg;
            nameTextBox.Text = user.Name;
            surnameTextBox.Text = user.Surname;
            emailTextBox.Text = user.Email;
            passwordTextBox.Text = user.Password;
            mobileTextBox.Text = user.MobilePhone;
            comboBox.Text = user.UserType;
            blockedCheckBox.IsChecked = user.Blocked;
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            user.Jmbg = jmbgTextBox.Text;
            user.Name = nameTextBox.Text;
            user.Surname = surnameTextBox.Text;
            user.Email = emailTextBox.Text;
            user.Password = passwordTextBox.Text;
            user.MobilePhone = mobileTextBox.Text;
            user.UserType = comboBox.Text;
            user.Blocked = (bool) blockedCheckBox.IsChecked;
            userController.Update(user);
            List<User> updatedUsers = userController.GetAll();
            ViewAllUsersPage.usersDataGrid.ItemsSource = updatedUsers;
            this.Hide();
        }
    }
}
