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
    /// Interaction logic for UpdateMedicinePage.xaml
    /// </summary>
    public partial class UpdateMedicinePage : Window
    {
        private MedicineController medicineController = new MedicineController();
        private string medicineCode;
        private Medicine medicine;
        public UpdateMedicinePage(string medicineCode)
        {
            InitializeComponent();
            this.medicineCode = medicineCode;
            ViewUpdateMedicine();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateMedicine();
            ViewAllMedicinesPage.medicineDataGrid.ItemsSource = medicineController.GetAll();
            this.Hide();
        }

        private void ViewUpdateMedicine()
        {
            medicine = medicineController.GetById(medicineCode);
            nameTextBox.Text = medicine.Name;
            producerTextBox.Text = medicine.Producer;
            quantityTextBox.Text = medicine.Quantity.ToString();
            priceTextBox.Text = medicine.Price.ToString();
            acceptedCheckBox.IsChecked = medicine.Accepted;
            rejectedCheckBox.IsChecked = medicine.Rejected;
        }

        private void UpdateMedicine()
        {
            medicine.Name = nameTextBox.Text;
            medicine.Producer = producerTextBox.Text;
            medicine.Quantity = int.Parse(quantityTextBox.Text);
            medicine.Price = double.Parse(priceTextBox.Text);
            medicine.Accepted = (bool)acceptedCheckBox.IsChecked;
            if (!medicine.Accepted)
            {
                medicine.PharmacistCounter = 0;
                medicine.DoctorCounter = 0;
                medicine.AcceptedDetails = null;
            }
            medicine.Rejected = (bool)rejectedCheckBox.IsChecked;
            medicineController.Update(medicine);
        }
    }
}
