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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SemiColonSeparatedStringEditor
{
    public partial class MainWindow : Window
    {
        public SemiColonSepearatedStringListModel data_model = new SemiColonSepearatedStringListModel();
        public MainWindow()
        {
            InitializeComponent();
            gridSeparatedItemModel.DataContext = data_model;
        }
        private void btnSeparate_Click(object sender, RoutedEventArgs e)
        {
            data_model.SetString(txtSeparatedString.Text);
        }
        private void btnMerge_Click(object sender, RoutedEventArgs e)
        {
            data_model.MergeString();
        }
        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            data_model.SeparatedList.Remove((sender as Button).Tag as ItemModel);
        }
    }
}
