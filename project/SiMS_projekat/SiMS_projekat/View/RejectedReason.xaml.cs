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
        private Medicine medicine = new Medicine();
        private string code;
        private string Jmbg;
        public RejectedReason(string id, string jmbg)
        {
            InitializeComponent();
            this.code = id;
            this.Jmbg = jmbg;
            medicine = medicineController.GetAll().FirstOrDefault(m => m.MedicineCode == id);
        }

        private void acceptBtn_Click(object sender, RoutedEventArgs e)
        {
            if(acceptTextBox.Text == "")
            {
                MessageBox.Show("Unesite komentar!");
            }
            else
            {
                User user = userController.GetAll().FirstOrDefault(u => u.Jmbg == Jmbg);
                string details = user.Name + " " + user.Surname + " " + acceptTextBox.Text + ".";
                medicine.RejectedDetails = medicine.RejectedDetails + details;
                medicine.Rejected = true;
                medicineController.Update(medicine);
                this.Hide();
            }
        }
    }
}
