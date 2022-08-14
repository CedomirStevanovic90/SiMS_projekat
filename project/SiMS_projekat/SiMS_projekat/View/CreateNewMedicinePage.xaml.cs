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
    /// Interaction logic for CreateNewMedicinePage.xaml
    /// </summary>
    public partial class CreateNewMedicinePage : Window
    {
        private MedicineController medicineController = new MedicineController();
        internal static List<Ingredient> ingredientsForMedicine;
        internal static List<Ingredient> remainingIngredients;
        public CreateNewMedicinePage()
        {
            InitializeComponent();
            ingredientsForMedicine = new List<Ingredient>();
            remainingIngredients = new List<Ingredient>();
        }

        private void addIngredientsBtn_Click(object sender, RoutedEventArgs e)
        {
            IngredientsForMedicinePage ingredientsForMedicinePage = new IngredientsForMedicinePage();
            ingredientsForMedicinePage.Show();
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            if (nameTextBox.Text.Equals("") || producerTextBox.Text.Equals("") || quantityTextBox.Text.Equals("") ||
               priceTextBox.Text.Equals(""))
            {
                MessageBox.Show("Unesite sve navedene podatke!");
                return;
            }
            AddNewMedicine();
            ViewAllMedicinesPage.medicineDataGrid.ItemsSource = medicineController.GetAll();
            this.Hide();
        }

        private void AddNewMedicine()
        {
            Medicine medicine = new Medicine();
            medicine.MedicineCode = DateTime.Now.GetHashCode().ToString().Substring(1);
            medicine.Name = nameTextBox.Text;
            medicine.Producer = producerTextBox.Text;
            medicine.Quantity = int.Parse(quantityTextBox.Text);
            medicine.Price = double.Parse(priceTextBox.Text);
            medicine.Accepted = (bool)acceptedCheckBox.IsChecked;
            medicine.Rejected = (bool)rejectedCheckBox.IsChecked;
            List<IngredientDTO> ingredientDTOs = new List<IngredientDTO>();
            foreach (var i in ingredientsForMedicine)
            {
                IngredientDTO ingredientDTO = new IngredientDTO();
                ingredientDTO.IngredientId = i.IngredientId;
                ingredientDTOs.Add(ingredientDTO);
            }
            medicine.Ingredients = ingredientDTOs;
            medicineController.Add(medicine);
        }
    }
}
