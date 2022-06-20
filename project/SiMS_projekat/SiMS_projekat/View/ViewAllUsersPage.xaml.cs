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
    /// Interaction logic for ViewAllUsersPage.xaml
    /// </summary>
    public partial class ViewAllUsersPage : Window
    {
        private UserController userController = new UserController();
        public static DataGrid usersDataGrid;
        private List<User> users;
        private List<User> filteredUsers;
        public ViewAllUsersPage()
        {
            InitializeComponent();
            users = userController.GetAll();
            myUsersDataGrid.ItemsSource = users;
            usersDataGrid = myUsersDataGrid;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            UpravnikHomepage upravnikHomepage = new UpravnikHomepage();
            upravnikHomepage.Show();
            this.Hide();
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = userController.GetAll().Last().UserId + 1;
            RegistrationPage registrationPage = new RegistrationPage(id);
            registrationPage.Show();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (myUsersDataGrid.SelectedItem as User).UserId;
            UpdateUserPage updateUserPage = new UpdateUserPage(id);
            updateUserPage.Show();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (myUsersDataGrid.SelectedItem as User).UserId;
            userController.Delete(id);
            List<User> updatedUsers = userController.GetAll();
            usersDataGrid.ItemsSource = updatedUsers;
        }

        private void comboBoxSorting_DropDownClosed(object sender, EventArgs e)
        {
            //List<User> users = userController.GetAll();
            filteredUsers = userController.GetAll();
            filteringUsers();
            sortingUsers();
            usersDataGrid.ItemsSource = filteredUsers;
        }

        private void sortingUsers()
        {
            if (comboBoxSorting.Text == "Sort by name (A-Z)")
            {
                filteredUsers = filteredUsers.OrderBy(u => u.Name).ToList();
            }
            else if (comboBoxSorting.Text == "Sort by name (Z-A)")
            {
                filteredUsers = filteredUsers.OrderByDescending(u => u.Name).ToList();
            }
            else if (comboBoxSorting.Text == "Sort by surname (A-Z)")
            {
                filteredUsers = filteredUsers.OrderBy(u => u.Surname).ToList();
            }
            else if (comboBoxSorting.Text == "Sort by surname (Z-A)")
            {
                filteredUsers = filteredUsers.OrderByDescending(u => u.Surname).ToList();
            }
        }

        private void comboBoxFiltering_DropDownClosed(object sender, EventArgs e)
        {
            //List<User> users = userController.GetAll();
            filteredUsers = userController.GetAll();
            filteringUsers();
            sortingUsers();
            usersDataGrid.ItemsSource = filteredUsers;
        }

        private void filteringUsers()
        {
            if (comboBoxFiltering.Text == "Filter by Manager")
            {
                filteredUsers = filteredUsers.Where(u => u.UserType == "Manager").ToList();
            }
            else if (comboBoxFiltering.Text == "Filter by Doctor")
            {
                filteredUsers = filteredUsers.Where(u => u.UserType == "Doctor").ToList();
            }
            else if (comboBoxFiltering.Text == "Filter by Pharmacist")
            {
                filteredUsers = filteredUsers.Where(u => u.UserType == "Pharmacist").ToList();
            }
            else if (comboBoxFiltering.Text == "No filter")
            {
                filteredUsers = userController.GetAll();
            }
        }
    }
}
