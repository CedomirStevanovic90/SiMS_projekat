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
    /// Interaction logic for RejectedReason.xaml
    /// </summary>
    public partial class RejectedReason : Window
    {
        private MedicineController medicineController = new MedicineController();
        private UserController userController = new UserController();
        private string medicineCode;
        private string Jmbg;
        public RejectedReason(string medicineCode, string jmbg)
        {
            InitializeComponent();
            this.medicineCode = medicineCode;
            this.Jmbg = jmbg;
        }

        private void acceptBtn_Click(object sender, RoutedEventArgs e)
        {
            if(acceptTextBox.Text.Equals(""))
            {
                MessageBox.Show("Unesite komentar!");
            }
            else
            {
                medicineController.SetReasonForRejectingMedicine(acceptTextBox.Text, medicineCode, userController.GetAll().FirstOrDefault(u => u.Jmbg == Jmbg));
                this.Hide();
            }
        }
    }
}
