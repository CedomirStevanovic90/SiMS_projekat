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
    /// Interaction logic for ViewAllMedicinesPage.xaml
    /// </summary>
    public partial class ViewAllMedicinesPage : Window
    {
        private MedicineController medicineController = new MedicineController();
        private IngredientController ingredientController = new IngredientController();
        public static DataGrid medicineDataGrid;
        private List<Medicine> medicines;
        private List<Medicine> filteredMedicines;
        private List<Medicine> acceptedMedicines;
        private List<Medicine> rejectedMedicines;
        private string userType;
        private string Jmbg;
        public ViewAllMedicinesPage(string jmbg, string userType)
        {
            InitializeComponent();
            this.userType = userType;
            medicines = medicineController.GetAll();
            myMedicinesDataGrid.ItemsSource = medicines;
            medicineDataGrid = myMedicinesDataGrid;
            this.Jmbg = jmbg;
            if(userType == "Manager")
            {
                acceptedAndRejectedBtn.IsEnabled = false;
            }
            else if(userType == "Doctor")
            {
                acceptedAndRejectedBtn.IsEnabled = false;
                createBtn.IsEnabled = false;
                myMedicinesDataGrid.Columns[8].Visibility = Visibility.Hidden;
                myMedicinesDataGrid.Columns[10].Visibility = Visibility.Hidden;
            }
            else
            {
                createBtn.IsEnabled = false;
                myMedicinesDataGrid.Columns[8].Visibility = Visibility.Hidden;
                myMedicinesDataGrid.Columns[10].Visibility = Visibility.Hidden;
                acceptedMedicines = medicineController.GetAll().Where(m => m.Accepted == true).ToList();
                rejectedMedicines = medicineController.GetAll().Where(m => m.Rejected == true).ToList();
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            if(userType == "Manager")
            {
                UpravnikHomepage upravnikHomepage = new UpravnikHomepage();
                upravnikHomepage.Show();
            }
            else if(userType == "Doctor")
            {
                LekarHomepage lekarHomepage = new LekarHomepage(Jmbg, userType);
                lekarHomepage.Show();
            }
            else if (userType == "Pharmacist")
            {
                FarmaceutHomepage farmaceutHomepage = new FarmaceutHomepage(Jmbg, userType);
                farmaceutHomepage.Show();
            }

            this.Hide();
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateNewMedicinePage createNewMedicinePage = new CreateNewMedicinePage();
            createNewMedicinePage.Show();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            string id = (myMedicinesDataGrid.SelectedItem as Medicine).MedicineCode;
            UpdateMedicinePage updateMedicinePage = new UpdateMedicinePage(id);
            updateMedicinePage.Show();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            string id = (myMedicinesDataGrid.SelectedItem as Medicine).MedicineCode;
            medicineController.Delete(id);
            List<Medicine> updatedMedicines = medicineController.GetAll();
            medicineDataGrid.ItemsSource = updatedMedicines;
        }

        private void comboBoxSorting_DropDownClosed(object sender, EventArgs e)
        {
            filteredMedicines = medicineController.GetAll();
            sortingMedicines();
            medicineDataGrid.ItemsSource = filteredMedicines;
        }

        private void sortingMedicines()
        {
            if (comboBoxSorting.Text == "Sort by name (A-Z)")
            {
                if (userType == "Pharmacist")
                {
                    acceptedMedicines = acceptedMedicines.OrderBy(m => m.Name).ToList();
                    rejectedMedicines = rejectedMedicines.OrderBy(m => m.Name).ToList();
                }
                filteredMedicines = filteredMedicines.OrderBy(m => m.Name).ToList();
            }
            else if (comboBoxSorting.Text == "Sort by name (Z-A)")
            {
                if (userType == "Pharmacist")
                {
                    acceptedMedicines = acceptedMedicines.OrderByDescending(m => m.Name).ToList();
                    rejectedMedicines = rejectedMedicines.OrderByDescending(m => m.Name).ToList();
                }
                filteredMedicines = filteredMedicines.OrderByDescending(m => m.Name).ToList();
            }
            else if (comboBoxSorting.Text == "Sort by price (Low - High)")
            {
                if(userType == "Pharmacist")
                {
                    acceptedMedicines = acceptedMedicines.OrderBy(m => m.Price).ToList();
                    rejectedMedicines = rejectedMedicines.OrderBy(m => m.Price).ToList();
                }
                filteredMedicines = filteredMedicines.OrderBy(m => m.Price).ToList();
            }
            else if (comboBoxSorting.Text == "Sort by price (High - Low)")
            {
                if (userType == "Pharmacist")
                {
                    acceptedMedicines = acceptedMedicines.OrderByDescending(m => m.Price).ToList();
                    rejectedMedicines = rejectedMedicines.OrderByDescending(m => m.Price).ToList();
                }
                filteredMedicines = filteredMedicines.OrderByDescending(m => m.Price).ToList();
            }
            else if (comboBoxSorting.Text == "Sort by quantity (Low - High)")
            {
                if (userType == "Pharmacist")
                {
                    acceptedMedicines = acceptedMedicines.OrderBy(m => m.Quantity).ToList();
                    rejectedMedicines = rejectedMedicines.OrderBy(m => m.Quantity).ToList();
                }
                filteredMedicines = filteredMedicines.OrderBy(m => m.Quantity).ToList();
            }
            else if (comboBoxSorting.Text == "Sort by quantity (High - Low)")
            {
                if (userType == "Pharmacist")
                {
                    acceptedMedicines = acceptedMedicines.OrderByDescending(m => m.Quantity).ToList();
                    rejectedMedicines = rejectedMedicines.OrderByDescending(m => m.Quantity).ToList();
                }
                filteredMedicines = filteredMedicines.OrderByDescending(m => m.Quantity).ToList();
            }
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            filteredMedicines = medicineController.GetAll();
            if(searchComboBox.Text == "Search by Medicine Code")
            {
                if (userType == "Pharmacist")
                {
                    acceptedMedicines = acceptedMedicines.Where(i => i.MedicineCode.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
                    rejectedMedicines = rejectedMedicines.Where(i => i.MedicineCode.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
                }
                filteredMedicines = filteredMedicines.Where(i => i.MedicineCode.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            }
            else if(searchComboBox.Text == "Search by Name")
            {
                if (userType == "Pharmacist")
                {
                    acceptedMedicines = acceptedMedicines.Where(i => i.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
                    rejectedMedicines = rejectedMedicines.Where(i => i.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
                }
                filteredMedicines = filteredMedicines.Where(i => i.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            }
            else if (searchComboBox.Text == "Search by Producer")
            {
                if (userType == "Pharmacist")
                {
                    acceptedMedicines = acceptedMedicines.Where(i => i.Producer.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
                    rejectedMedicines = rejectedMedicines.Where(i => i.Producer.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
                }
                filteredMedicines = filteredMedicines.Where(i => i.Producer.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            }
            else if (searchComboBox.Text == "Search by Quantity")
            {
                if (userType == "Pharmacist")
                {
                    acceptedMedicines = acceptedMedicines.Where(i => i.Quantity == int.Parse(searchTextBox.Text)).ToList();
                    rejectedMedicines = rejectedMedicines.Where(i => i.Quantity == int.Parse(searchTextBox.Text)).ToList();
                }
                filteredMedicines = filteredMedicines.Where(i => i.Quantity == int.Parse(searchTextBox.Text)).ToList();
            }
            else if (searchComboBox.Text == "Search by Price range")
            {
                string[] splittedRange = searchTextBox.Text.Split('-');
                int priceFrom = int.Parse(splittedRange[0]);
                int priceTo = int.Parse(splittedRange[1]);
                if (userType == "Pharmacist")
                {
                    acceptedMedicines = acceptedMedicines.Where(i => i.Price >= priceFrom && i.Price < priceTo).ToList();
                    rejectedMedicines = rejectedMedicines.Where(i => i.Price >= priceFrom && i.Price < priceTo).ToList();
                }
                filteredMedicines = filteredMedicines.Where(i => i.Price >= priceFrom && i.Price < priceTo).ToList();
            }
            else if (searchComboBox.Text == "Search by Ingredients")
            {
                List<Medicine> searchedMedicine = new List<Medicine>();
                List<string> ingredientAND = new List<string>();
                string[] splittedOR;
                string[] splittedAND = searchTextBox.Text.Split('&');
                List<string> ingredientsOR = new List<string>();
                List<Medicine> finalMedicines = new List<Medicine>();
                for (int i = 0; i < splittedAND.Length; i++)
                {
                    if(splittedAND[i].Contains('|') == true)
                    {
                        splittedOR = splittedAND[i].Split('|');
                        for(int s = 0; s < splittedOR.Length; s++)
                        {
                            ingredientsOR.Add(splittedOR[s].Replace("(", string.Empty).Replace(")", string.Empty));
                        }
                    }
                    else
                    {
                        ingredientAND.Add(splittedAND[i]);
                    }
                }
                for (int i = 0; i < medicines.Count(); i++)
                {
                    List<string> ingredientsMedicine = new List<string>();
                    foreach (var ins in ingredientController.GetAll())
                    {
                        foreach (var im in medicines[i].Ingredients)
                        {
                            if (ins.IngredientId == im.IngredientId)
                            {
                                ingredientsMedicine.Add(ins.Name);
                            }
                        }
                    }

                    if (ingredientAND.All(ingredientsMedicine.Contains))
                    {
                        searchedMedicine.Add(medicines[i]);
                    }
                }
                for(int im = 0; im < searchedMedicine.Count(); im++)
                {
                    List<string> ingredientMedicine = new List<string>();
                    foreach (var ins in ingredientController.GetAll())
                    {
                        foreach (var iss in searchedMedicine[im].Ingredients)
                        {
                            if (ins.IngredientId == iss.IngredientId)
                            {
                                ingredientMedicine.Add(ins.Name);
                            }
                        }
                    }
                    if (ingredientsOR.Any(ingredientMedicine.Contains))
                    {
                        finalMedicines.Add(searchedMedicine[im]);
                    }

                }
                if(finalMedicines.Count() == 0)
                {
                    if (userType == "Pharmacist")
                    {
                        acceptedMedicines = searchedMedicine.Where(m => m.Accepted == true).ToList();
                        rejectedMedicines = searchedMedicine.Where(m => m.Rejected == true).ToList();
                    }
                    medicineDataGrid.ItemsSource = searchedMedicine;
                }
                else
                {
                    if (userType == "Pharmacist")
                    {
                        acceptedMedicines = finalMedicines.Where(m => m.Accepted == true).ToList();
                        rejectedMedicines = finalMedicines.Where(m => m.Rejected == true).ToList();
                    }
                    medicineDataGrid.ItemsSource = finalMedicines;
                }
                medicineDataGrid.Items.Refresh();
                return;
            }
            else if (searchComboBox.Text == "No Search")
            {
                if (userType == "Pharmacist")
                {
                    acceptedMedicines = medicineController.GetAll().Where(m => m.Accepted == true).ToList();
                    rejectedMedicines = medicineController.GetAll().Where(m => m.Rejected == true).ToList();
                }
                filteredMedicines = medicineController.GetAll();
            }
            medicineDataGrid.ItemsSource = filteredMedicines;
        }

        private void ingredientsBtn_Click(object sender, RoutedEventArgs e)
        {
            string code = (myMedicinesDataGrid.SelectedItem as Medicine).MedicineCode;
            Medicine medicine = medicineController.GetAll().FirstOrDefault(m => m.MedicineCode == code);
            List<Ingredient> medicineIngredients = new List<Ingredient>();
            foreach(var i in ingredientController.GetAll())
            {
                foreach(var im in medicine.Ingredients)
                {
                    if(i.IngredientId == im.IngredientId)
                    {
                        medicineIngredients.Add(i);
                    }
                }
            }
            if(medicineIngredients.Count() == 0)
            {
                MessageBox.Show("Za dati lek nisu navedeni sastojci!");
            }
            else
            {
                MedicineIngredients medicineIngredientss = new MedicineIngredients(medicineIngredients);
                medicineIngredientss.Show();
            }                    
        }

        private void acceptedAndRejectedBtn_Click(object sender, RoutedEventArgs e)
        {
            AcceptedAndRejectedMedicines acceptedAndRejectedMedicines = new AcceptedAndRejectedMedicines(acceptedMedicines, rejectedMedicines);
            acceptedAndRejectedMedicines.Show();
        }

        private void purchaseBtn_Click(object sender, RoutedEventArgs e)
        {
            string code = (myMedicinesDataGrid.SelectedItem as Medicine).MedicineCode;
            PurchasePage purchasePage = new PurchasePage(code);
            purchasePage.Show();
        }
    }
}
