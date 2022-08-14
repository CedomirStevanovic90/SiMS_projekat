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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SiMS_projekat.Controller;
using SiMS_projekat.Model;
using SiMS_projekat.View;

namespace SiMS_projekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserController userController = new UserController();
        private MedicineController medicineController = new MedicineController();
        private int counter = 3;
        public MainWindow()
        {
            InitializeComponent();
            medicineController.OrderMedicine();
        }

        private void signInBtn_Click(object sender, RoutedEventArgs e)
        {
            User checkedUser = userController.FindLoggedUser(emailBox.Text, passwordBox.Password);
            if (checkedUser == null)
            {
                int number = counter - 1;
                if (number == 0)
                {
                    MessageBox.Show("Iskoristili ste moguci broj pokusaja!");
                    this.Close();
                    return;
                }
                MessageBox.Show("Niste uneli dobre kredencijale!\n Preostali broj pokusaja: " + number);
                counter--;
                return;
            }
            if (checkedUser.Blocked == true)
            {
                MessageBox.Show("Korisnik sa unetim e-mailom i passwordom je blokiran!");
                return;
            }
            if (checkedUser.UserType.Equals("Manager"))
            {
                UpravnikHomepage upravnikHomepage = new UpravnikHomepage();
                upravnikHomepage.Show();

            }
            else if (checkedUser.UserType.Equals("Doctor"))
            {
                LekarHomepage lekarHomepage = new LekarHomepage(checkedUser.Jmbg, "Doctor");
                lekarHomepage.Show();
            }
            else if (checkedUser.UserType.Equals("Pharmacist"))
            {
                FarmaceutHomepage farmaceutHomepage = new FarmaceutHomepage(checkedUser.Jmbg, "Pharmacist");
                farmaceutHomepage.Show();
            }
            this.Hide();
        }
    }
}
