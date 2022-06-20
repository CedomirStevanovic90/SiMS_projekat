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

namespace SiMS_projekat.View
{
    /// <summary>
    /// Interaction logic for UpravnikHomepage.xaml
    /// </summary>
    public partial class UpravnikHomepage : Window
    {
        public UpravnikHomepage()
        {
            InitializeComponent();
        }

        

        private void usersBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewAllUsersPage viewAllUsersPage = new ViewAllUsersPage();
            viewAllUsersPage.Show();
            this.Hide();
        }

        private void medicationsBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewAllMedicinesPage viewAllMedicinesPage = new ViewAllMedicinesPage(null, "Manager");
            viewAllMedicinesPage.Show();
            this.Hide();
        }
    }
}
