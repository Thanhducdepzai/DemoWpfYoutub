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

namespace _23_ComboBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Food> listName;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //listName = new List<string>() { "a", "b", "c" };
            //cbItemSource.ItemsSource = listName;

            // listName = new List<Food>() {
            //    new Food(){Name = "x", Price = "299.999"}, 
            //    new Food() {Name = "y", Price = "50.000"},

            //        new Food(){Name = "z", Price = "75.000"}
            //        };

            //cbItemSource.ItemsSource = listName;
            //cbItemSource.DisplayMemberPath = "Name";
            //cbItemSource.SelectedValuePath = "Price";
            //cbItemSource.SelectionChanged += cbItemSource_SelectionChanged;

            cbxColor.ItemsSource = typeof(Colors).GetProperties();
            cbFont.ItemsSource = Fonts.SystemFontFamilies;
        }

        //private void cbItemSource_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    MessageBox.Show(cbItemSource.SelectedItem.ToString());
        //}
    }

    public class Food
    {
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
