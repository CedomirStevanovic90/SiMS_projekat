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
        private string id;
        private Medicine medicine;
        private List<Medicine> medicines;
        public UpdateMedicinePage(string id)
        {
            InitializeComponent();
            this.id = id;
            medicines = medicineController.GetAll();
            for (int i = 0; i < medicines.Count(); i++)
            {
                if (medicines[i].MedicineCode == id)
                {
                    medicine = medicines[i];
                }
            }
            nameTextBox.Text = medicine.Name;
            producerTextBox.Text = medicine.Producer;
            quantityTextBox.Text = medicine.Quantity.ToString();
            priceTextBox.Text = medicine.Price.ToString();
            acceptedCheckBox.IsChecked = medicine.Accepted;
            rejectedCheckBox.IsChecked = medicine.Rejected;
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            medicine.Name = nameTextBox.Text;
            medicine.Producer = producerTextBox.Text;
            medicine.Quantity = int.Parse(quantityTextBox.Text);
            medicine.Price = double.Parse(priceTextBox.Text);
            medicine.Accepted = (bool)acceptedCheckBox.IsChecked;
            medicine.Rejected = (bool)rejectedCheckBox.IsChecked;
            medicineController.Update(medicine);
            List<Medicine> updatedMedicines = medicineController.GetAll();
            ViewAllMedicinesPage.medicineDataGrid.ItemsSource = updatedMedicines;
            this.Hide();
        }
    }
}
