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
using SiMS_projekat.DTO;
using SiMS_projekat.Model;

namespace SiMS_projekat.View
{
    /// <summary>
    /// Interaction logic for PurchasePage.xaml
    /// </summary>
    public partial class PurchasePage : Window
    {
        private MedicineController medicineController = new MedicineController();
        private string code;
        private Medicine medicine;
        public PurchasePage(string code)
        {
            InitializeComponent();
            this.code = code;
            medicine = medicineController.GetAll().FirstOrDefault(m => m.MedicineCode == code);
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if(quantityTextBox.Text != "" && datePickerBox.Text == "")
            {
                medicine.Quantity += int.Parse(quantityTextBox.Text);
                medicineController.Update(medicine);
                ViewAllMedicinesPage.medicineDataGrid.ItemsSource = medicineController.GetAll();
                ViewAllMedicinesPage.medicineDataGrid.Items.Refresh();
                this.Hide();
            }
            else if (quantityTextBox.Text != "" && datePickerBox.Text != "")
            {
                MedicineDTO medicineDTO = new MedicineDTO();
                medicineDTO.Quantity = int.Parse(quantityTextBox.Text);
                medicineDTO.Date = DateTime.Parse(datePickerBox.Text);
                if(medicine.MedicinesPurchase == null)
                {
                    medicine.MedicinesPurchase = new List<MedicineDTO>();
                }
                medicine.MedicinesPurchase.Add(medicineDTO);
                medicineController.Update(medicine);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Potrebno je da unesete kolicinu!");
            }
        }
    }
}
