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
    /// Interaction logic for MedicineOnHoldPage.xaml
    /// </summary>
    public partial class MedicineOnHoldPage : Window
    {
        private string Jmbg;
        private string UserType;
        public static DataGrid medicineOnHoldDataGrid;
        private MedicineController medicineController = new MedicineController();
        public MedicineOnHoldPage(string jmbg, string userType)
        {
            InitializeComponent();
            this.Jmbg = jmbg;
            this.UserType = userType;
            myMedicinesOnHoldDataGrid.ItemsSource = medicineController.GetAll().Where(m => m.Accepted == false);
            medicineOnHoldDataGrid = myMedicinesOnHoldDataGrid;
        }

        private void acceptBtn_Click(object sender, RoutedEventArgs e)
        {
            string id = (myMedicinesOnHoldDataGrid.SelectedItem as Medicine).MedicineCode;
            Medicine medicine = medicineController.GetById(id);

            if(medicineController.IsMedicineAccepted(Jmbg, medicine))
            {
                MessageBox.Show("Vec prihvaceno!");
                return;
            }

            if (UserType.Equals("Doctor"))
            {
                medicine = medicineController.AcceptMedicineByDoctor(medicine);
            }
            else if (UserType.Equals("Pharmacist"))
            {
                medicine = medicineController.AcceptMedicineByPharmacist(medicine);
            }

            if (medicine.DoctorCounter == 1 && medicine.PharmacistCounter == 2)
            {
                medicine = medicineController.AcceptMedicine(medicine);
            }
            string details = Jmbg + ";";
            medicine.AcceptedDetails = medicine.AcceptedDetails + details;
            medicineController.Update(medicine);
            MessageBox.Show("Prihvaceno!");
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UserType.Equals("Doctor"))
            {
                LekarHomepage lekarHomepage = new LekarHomepage(Jmbg, UserType);
                lekarHomepage.Show();
                this.Hide();
            }
            else if (UserType.Equals("Pharmacist"))
            {
                FarmaceutHomepage farmaceutHomepage = new FarmaceutHomepage(Jmbg, UserType);
                farmaceutHomepage.Show();
                this.Hide();
            }
        }

        private void rejectBtn_Click(object sender, RoutedEventArgs e)
        {
            string id = (myMedicinesOnHoldDataGrid.SelectedItem as Medicine).MedicineCode;
            Medicine medicine = medicineController.GetById(id);
            if(medicineController.IsMedicineAccepted(Jmbg, medicine))
            {
                MessageBox.Show("Prethodno ste vec odobrili ovaj lek, tako da nije moguce odbijanje!");
                return;
            }
            RejectedReason rejectedReason = new RejectedReason(id, Jmbg);
            rejectedReason.Show();
        }
    }
}
