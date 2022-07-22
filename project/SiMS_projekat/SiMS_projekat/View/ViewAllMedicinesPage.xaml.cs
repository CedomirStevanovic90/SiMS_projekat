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
            viewSetup();
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
            medicineDataGrid.ItemsSource = medicineController.GetAll();
        }

        private void comboBoxSorting_DropDownClosed(object sender, EventArgs e)
        {
            filteredMedicines = medicineController.GetAll();
            acceptedMedicines = medicineController.sortingAcceptedMedicines(comboBoxSorting.Text, userType, acceptedMedicines);
            rejectedMedicines = medicineController.sortingRejectedMedicines(comboBoxSorting.Text, userType, rejectedMedicines);
            filteredMedicines = medicineController.sortingAllMedicines(comboBoxSorting.Text, filteredMedicines);
            medicineDataGrid.ItemsSource = filteredMedicines;
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            filteredMedicines = medicineController.GetAll();
            acceptedMedicines = medicineController.searchingAcceptedMedicines(searchComboBox.Text, searchTextBox.Text, userType,
                    medicines, acceptedMedicines);
            rejectedMedicines = medicineController.searchingRejectedMedicines(searchComboBox.Text, searchTextBox.Text, userType,
                    medicines, rejectedMedicines);
            filteredMedicines = medicineController.searchingAllMedicines(searchComboBox.Text, searchTextBox.Text, medicines,
                filteredMedicines);
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

        private void viewSetup()
        {
            if (userType == "Manager")
            {
                acceptedAndRejectedBtn.IsEnabled = false;
            }
            else if (userType == "Doctor")
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
    }
}
