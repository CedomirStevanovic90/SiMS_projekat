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
    /// Interaction logic for FarmaceutHomepage.xaml
    /// </summary>
    public partial class FarmaceutHomepage : Window
    {
        private string Jmbg;
        private string UserType;
        public FarmaceutHomepage(string jmbg, string userType)
        {
            InitializeComponent();
            this.Jmbg = jmbg;
            this.UserType = userType;
        }

        private void medicinesBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewAllMedicinesPage viewAllMedicinesPage = new ViewAllMedicinesPage(Jmbg, UserType);
            viewAllMedicinesPage.Show();
            this.Hide();
        }

        private void medicinesOnHoldBtn_Click(object sender, RoutedEventArgs e)
        {
            MedicineOnHoldPage medicineOnHoldPage = new MedicineOnHoldPage(Jmbg, UserType);
            medicineOnHoldPage.Show();
            this.Hide();
        }
    }
}
