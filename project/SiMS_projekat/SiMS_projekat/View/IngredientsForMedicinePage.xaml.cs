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
    /// Interaction logic for IngredientsForMedicinePage.xaml
    /// </summary>
    public partial class IngredientsForMedicinePage : Window
    {
        private IngredientController ingredientController = new IngredientController();
        public static DataGrid ingredientsDataGrid;
        private List<Ingredient> ingredients;
        public IngredientsForMedicinePage()
        {
            InitializeComponent();
            ingredients = ingredientController.GetAll();
            ViewIngredients();
        }

        private void addIngredientBtn_Click(object sender, RoutedEventArgs e)
        {
            AddIngredientToMedicine();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ViewIngredients()
        {
            if (CreateNewMedicinePage.ingredientsForMedicine.Count() >= 1)
            {
                myIngredientsDataGrid.ItemsSource = CreateNewMedicinePage.remainingIngredients;
                ingredientsDataGrid = myIngredientsDataGrid;
            }
            else
            {
                myIngredientsDataGrid.ItemsSource = ingredients;
                ingredientsDataGrid = myIngredientsDataGrid;
            }
        }

        private void AddIngredientToMedicine()
        {
            Ingredient ingredient = (myIngredientsDataGrid.SelectedItem as Ingredient);
            ingredients.Remove(ingredient);
            CreateNewMedicinePage.remainingIngredients = ingredients;
            CreateNewMedicinePage.ingredientsForMedicine.Add(ingredient);
            myIngredientsDataGrid.ItemsSource = ingredients;
            myIngredientsDataGrid.Items.Refresh();
        }
    }
}
