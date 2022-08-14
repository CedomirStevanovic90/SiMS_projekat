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
        private string medicineCode;
        public PurchasePage(string medicineCode)
        {
            InitializeComponent();
            this.medicineCode = medicineCode;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if((!quantityTextBox.Text.Equals("")) && datePickerBox.Text.Equals(""))
            {
                medicineController.PurchaseMedicine(int.Parse(quantityTextBox.Text), medicineCode);
                ViewAllMedicinesPage.medicineDataGrid.ItemsSource = medicineController.GetAll();
                this.Hide();
            }
            else if ((!quantityTextBox.Text.Equals("")) && (!datePickerBox.Text.Equals("")))
            {
                medicineController.PurchaseMedicineAtSpecificTime(int.Parse(quantityTextBox.Text), DateTime.Parse(datePickerBox.Text), medicineCode);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Potrebno je da unesete kolicinu!");
            }
        }
    }
}
