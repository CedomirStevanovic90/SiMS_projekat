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
            this.Jmbg = jmbg;
            medicines = medicineController.GetAll();
            acceptedMedicines = medicineController.GetAll().Where(m => m.Accepted == true).ToList();
            rejectedMedicines = medicineController.GetAll().Where(m => m.Rejected == true).ToList();
            myMedicinesDataGrid.ItemsSource = medicines;
            medicineDataGrid = myMedicinesDataGrid;
            ViewSetup();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            if(userType.Equals("Manager"))
            {
                UpravnikHomepage upravnikHomepage = new UpravnikHomepage();
                upravnikHomepage.Show();
            }
            else if(userType.Equals("Doctor"))
            {
                LekarHomepage lekarHomepage = new LekarHomepage(Jmbg, userType);
                lekarHomepage.Show();
            }
            else if (userType.Equals("Pharmacist"))
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
            string code = (myMedicinesDataGrid.SelectedItem as Medicine).MedicineCode;
            UpdateMedicinePage updateMedicinePage = new UpdateMedicinePage(code);
            updateMedicinePage.Show();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            string code = (myMedicinesDataGrid.SelectedItem as Medicine).MedicineCode;
            medicineController.Delete(code);
            medicineDataGrid.ItemsSource = medicineController.GetAll();
        }

        private void comboBoxSorting_DropDownClosed(object sender, EventArgs e)
        {
            filteredMedicines = medicineController.GetAll();
            SortMedicines();
            medicineDataGrid.ItemsSource = filteredMedicines;
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            filteredMedicines = medicineController.GetAll();
            SearchMedicines();
            medicineDataGrid.ItemsSource = filteredMedicines;
        }

        private void ingredientsBtn_Click(object sender, RoutedEventArgs e)
        { 
            List<Ingredient> medicineIngredients = medicineController.GetMedicineIngredients(
                (myMedicinesDataGrid.SelectedItem as Medicine).MedicineCode, ingredientController.GetAll());
            ViewIngredientsForMedicine(medicineIngredients);
        }

        private static void ViewIngredientsForMedicine(List<Ingredient> medicineIngredients)
        {
            if (medicineIngredients.Count() == 0)
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

        private void SortMedicines()
        {
            if (comboBoxSorting.Text.Equals("Sort by name (A-Z)"))
            {
                filteredMedicines = medicineController.SortMedicinesByNameAsc(filteredMedicines);
                acceptedMedicines = medicineController.SortMedicinesByNameAsc(acceptedMedicines);
                rejectedMedicines = medicineController.SortMedicinesByNameAsc(rejectedMedicines);
            }
            else if (comboBoxSorting.Text.Equals("Sort by name (Z-A)"))
            {
                filteredMedicines = medicineController.SortMedicinesByNameDesc(filteredMedicines);
                acceptedMedicines = medicineController.SortMedicinesByNameDesc(acceptedMedicines);
                rejectedMedicines = medicineController.SortMedicinesByNameDesc(rejectedMedicines);
            }
            else if (comboBoxSorting.Text.Equals("Sort by price (Low - High)"))
            {
                filteredMedicines = medicineController.SortMedicinesByPriceAsc(filteredMedicines);
                acceptedMedicines = medicineController.SortMedicinesByPriceAsc(acceptedMedicines);
                rejectedMedicines = medicineController.SortMedicinesByPriceAsc(rejectedMedicines);
            }
            else if (comboBoxSorting.Text.Equals("Sort by price (High - Low)"))
            {
                filteredMedicines = medicineController.SortMedicinesByPriceDesc(filteredMedicines);
                acceptedMedicines = medicineController.SortMedicinesByPriceDesc(acceptedMedicines);
                rejectedMedicines = medicineController.SortMedicinesByPriceDesc(rejectedMedicines);
            }
            else if (comboBoxSorting.Text.Equals("Sort by quantity (Low - High)"))
            {
                filteredMedicines = medicineController.SortMedicinesByQuantityAsc(filteredMedicines);
                acceptedMedicines = medicineController.SortMedicinesByQuantityAsc(acceptedMedicines);
                rejectedMedicines = medicineController.SortMedicinesByQuantityAsc(rejectedMedicines);
            }
            else if (comboBoxSorting.Text.Equals("Sort by quantity (High - Low)"))
            {
                filteredMedicines = medicineController.SortMedicinesByQuantityDesc(filteredMedicines);
                acceptedMedicines = medicineController.SortMedicinesByQuantityDesc(acceptedMedicines);
                rejectedMedicines = medicineController.SortMedicinesByQuantityDesc(rejectedMedicines);
            }
        }

        private void SearchMedicines()
        {
            if (searchComboBox.Text.Equals("Search by Medicine Code"))
            {
                filteredMedicines = medicineController.SearchMedicinesByMedicineCode(searchTextBox.Text, filteredMedicines);
                acceptedMedicines = medicineController.SearchMedicinesByMedicineCode(searchTextBox.Text, acceptedMedicines);
                rejectedMedicines = medicineController.SearchMedicinesByMedicineCode(searchTextBox.Text, rejectedMedicines);
            }
            else if (searchComboBox.Text.Equals("Search by Name"))
            {
                filteredMedicines = medicineController.SearchMedicinesByName(searchTextBox.Text, filteredMedicines);
                acceptedMedicines = medicineController.SearchMedicinesByName(searchTextBox.Text, acceptedMedicines);
                rejectedMedicines = medicineController.SearchMedicinesByName(searchTextBox.Text, rejectedMedicines);
            }
            else if (searchComboBox.Text.Equals("Search by Producer"))
            {
                filteredMedicines = medicineController.SearchMedicinesByProducer(searchTextBox.Text, filteredMedicines);
                acceptedMedicines = medicineController.SearchMedicinesByProducer(searchTextBox.Text, acceptedMedicines);
                rejectedMedicines = medicineController.SearchMedicinesByProducer(searchTextBox.Text, rejectedMedicines);
            }
            else if (searchComboBox.Text.Equals("Search by Quantity"))
            {
                filteredMedicines = medicineController.SearchMedicinesByQuantity(searchTextBox.Text, filteredMedicines);
                acceptedMedicines = medicineController.SearchMedicinesByQuantity(searchTextBox.Text, acceptedMedicines);
                rejectedMedicines = medicineController.SearchMedicinesByQuantity(searchTextBox.Text, rejectedMedicines);
            }
            else if (searchComboBox.Text.Equals("Search by Price range"))
            {
                filteredMedicines = medicineController.SearchMedicinesByPriceRange(searchTextBox.Text, filteredMedicines);
                acceptedMedicines = medicineController.SearchMedicinesByPriceRange(searchTextBox.Text, acceptedMedicines);
                rejectedMedicines = medicineController.SearchMedicinesByPriceRange(searchTextBox.Text, rejectedMedicines);
            }
            else if (searchComboBox.Text.Equals("Search by Ingredients"))
            {
                filteredMedicines = medicineController.SearchMedicinesByIngredients(searchTextBox.Text, filteredMedicines);
                acceptedMedicines = medicineController.SearchMedicinesByIngredients(searchTextBox.Text, acceptedMedicines);
                rejectedMedicines = medicineController.SearchMedicinesByIngredients(searchTextBox.Text, rejectedMedicines);
            }
        }

        private void ViewSetup()
        {
            if (userType.Equals("Manager"))
            {
                acceptedAndRejectedBtn.IsEnabled = false;
            }
            else if (userType.Equals("Doctor"))
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
            }
        }
    }
}
