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
            usersDataGrid.ItemsSource = userController.GetAll();
        }

        private void comboBoxSorting_DropDownClosed(object sender, EventArgs e)
        {
            filteredUsers = userController.GetAll();
            FilterUsers();
            SortUsers();
            usersDataGrid.ItemsSource = filteredUsers;
        }

        private void comboBoxFiltering_DropDownClosed(object sender, EventArgs e)
        {
            filteredUsers = userController.GetAll();
            FilterUsers();
            SortUsers();
            usersDataGrid.ItemsSource = filteredUsers;
        }

        private void SortUsers()
        {
            if (comboBoxSorting.Text.Equals("Sort by name (A-Z)"))
            {
                filteredUsers = userController.SortUsersByNameAsc(filteredUsers);
            }
            else if (comboBoxSorting.Text.Equals("Sort by name (Z-A)"))
            {
                filteredUsers = userController.SortUsersByNameDesc(filteredUsers);
            }
            else if (comboBoxSorting.Text.Equals("Sort by surname (A-Z)"))
            {
                filteredUsers = userController.SortUsersBySurnameAsc(filteredUsers);
            }
            else if (comboBoxSorting.Text.Equals("Sort by surname (Z-A)"))
            {
                filteredUsers = userController.SortUsersBySurnameDesc(filteredUsers);
            }
        }

        private void FilterUsers()
        {
            if (comboBoxFiltering.Text.Equals("Filter by Manager"))
            {
                filteredUsers = userController.FilterAllManagers(filteredUsers);
            }
            else if (comboBoxFiltering.Text.Equals("Filter by Doctor"))
            {
                filteredUsers = userController.FilterAllDoctors(filteredUsers);
            }
            else if (comboBoxFiltering.Text.Equals("Filter by Pharmacist"))
            {
                filteredUsers = userController.FilterAllPharmacists(filteredUsers);
            }
        }
    }
}
