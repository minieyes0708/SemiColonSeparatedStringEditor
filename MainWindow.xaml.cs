using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            data_model.SeparatedList.Add(new ItemModel());
            scrSeparatedList.ScrollToEnd();
        }
        private void gridPathItem_Drop(object sender, DragEventArgs e)
        {
            Grid grid = sender as Grid;
            ItemModel move_target = grid.Tag as ItemModel;
            int insert_index = data_model.SeparatedList.IndexOf(move_target);
            if (e.Data.GetDataPresent(typeof(ItemModel)))
            {
                ItemModel to_be_moved = e.Data.GetData(typeof(ItemModel)) as ItemModel;
                data_model.SeparatedList.Remove(to_be_moved);
                data_model.SeparatedList.Insert(insert_index, to_be_moved);
            }
        }
        private void btnDrag_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Button btn = sender as Button;
            ItemModel item = btn.Tag as ItemModel;
            DragDrop.DoDragDrop(btn, item, DragDropEffects.Move);
        }
    }
}
