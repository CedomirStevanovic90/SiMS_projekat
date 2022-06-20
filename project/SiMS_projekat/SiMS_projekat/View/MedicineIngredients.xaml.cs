﻿using System;
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
using SiMS_projekat.Model;

namespace SiMS_projekat.View
{
    /// <summary>
    /// Interaction logic for MedicineIngredients.xaml
    /// </summary>
    public partial class MedicineIngredients : Window
    {
        private List<Ingredient> ingredients;
        internal MedicineIngredients(List<Ingredient> ingredients)
        {
            InitializeComponent();
            this.ingredients = ingredients;
            myMedicineIngredientsDataGrid.ItemsSource = ingredients;
        }
    }
}
