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
using SiMS_projekat.Model;

namespace SiMS_projekat.View
{
    /// <summary>
    /// Interaction logic for AcceptedAndRejectedMedicines.xaml
    /// </summary>
    public partial class AcceptedAndRejectedMedicines : Window
    {
        internal AcceptedAndRejectedMedicines(List<Medicine> accepted, List<Medicine> rejected)
        {
            InitializeComponent();
            myMedicinesAcceptedDataGrid.ItemsSource = accepted;
            myMedicinesRejectedDataGrid.ItemsSource = rejected;
        }
    }
}
