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
        public UpdateUserPage(int id)
        {
            InitializeComponent();
            this.id = id;
            ViewUpdateUser();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateUser();
            ViewAllUsersPage.usersDataGrid.ItemsSource = userController.GetAll();
            this.Hide();
        }

        private void ViewUpdateUser()
        {
            user = userController.GetById(id);
            jmbgTextBox.Text = user.Jmbg;
            nameTextBox.Text = user.Name;
            surnameTextBox.Text = user.Surname;
            emailTextBox.Text = user.Email;
            passwordTextBox.Text = user.Password;
            mobileTextBox.Text = user.MobilePhone;
            comboBox.Text = user.UserType;
            blockedCheckBox.IsChecked = user.Blocked;
        }

        private void UpdateUser()
        {
            user.Jmbg = jmbgTextBox.Text;
            user.Name = nameTextBox.Text;
            user.Surname = surnameTextBox.Text;
            user.Email = emailTextBox.Text;
            user.Password = passwordTextBox.Text;
            user.MobilePhone = mobileTextBox.Text;
            user.UserType = comboBox.Text;
            user.Blocked = (bool)blockedCheckBox.IsChecked;
            userController.Update(user);
        }
    }
}
