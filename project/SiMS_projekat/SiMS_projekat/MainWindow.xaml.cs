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
        private List<User> users;
        private UserController userController = new UserController();
        private MedicineController medicineController = new MedicineController();
        private int counter = 3;
        public MainWindow()
        {
            InitializeComponent();
            users = userController.GetAll();
            foreach(var m in medicineController.GetAll())
            {
                if(m.MedicinesPurchase != null)
                {
                    for(int i = 0; i < m.MedicinesPurchase.Count; i++)
                    {
                        if(m.MedicinesPurchase[i].Date < DateTime.Now)
                        {
                            m.Quantity += m.MedicinesPurchase[i].Quantity;
                            m.MedicinesPurchase.Remove(m.MedicinesPurchase[i]);
                            medicineController.Update(m);
                        }
                    }
                }
            }
        }

        private void signInBtn_Click(object sender, RoutedEventArgs e)
        {
            string email = emailBox.Text;
            string password = passwordBox.Password;
            User user = users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if(user == null)
            {
                int number = counter - 1;
                if(number == 0)
                {
                    MessageBox.Show("Iskoristili ste moguci broj pokusaja!");
                    this.Close();
                    return;
                }
                MessageBox.Show("Niste uneli dobre kredencijale!\n Preostali broj pokusaja: " + number);
                counter--;
                return;
            }
            if(user.Blocked == true)
            {
                MessageBox.Show("Korisnik sa unetim e-mailom i passwordom je blokiran!");
                return;
            }
            if (user.UserType.Equals("Manager"))
            {
                UpravnikHomepage upravnikHomepage = new UpravnikHomepage();
                upravnikHomepage.Show();
                this.Hide();

            }else if(user.UserType.Equals("Doctor"))
            {
                LekarHomepage lekarHomepage = new LekarHomepage(user.Jmbg, "Doctor");
                lekarHomepage.Show();
                this.Hide();
            }else if (user.UserType.Equals("Pharmacist"))
            {
                FarmaceutHomepage farmaceutHomepage = new FarmaceutHomepage(user.Jmbg, "Pharmacist");
                farmaceutHomepage.Show();
                this.Hide();
            }
        }
    }
}
