using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace _26_ListViewGridView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool isSort;
        public MainWindow()
        {
            InitializeComponent();
            isSort = false;
            List<User> items = new List<User>();
            items.Add(new User() { Name = "a", Age = 1, Mail = "a@gmail.com", Sex = Sextype.Male });
            items.Add(new User() { Name = "b", Age = 3, Mail = "a@gmail.com", Sex = Sextype.Male });
            items.Add(new User() { Name = "c", Age = 2, Mail = "a@gmail.com", Sex = Sextype.Female });
            lvUsers.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            //// PropertyGroupDescription groupDescription = new PropertyGroupDescription("Sex");
            // view.SortDescriptions.Add(new SortDescription("Age",ListSortDirection.Ascending));

            view.Filter = UserFilter;
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text)) return true;
            else return ((item as User).Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Mail { get; set; }
            public Sextype Sex { get; set; }
        }

        public enum Sextype { Male, Female };

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader header = sender as GridViewColumnHeader;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            if (isSort)
            {
                //view.SortDescriptions.Remove(new SortDescription("Age", ListSortDirection.Descending));

                //view.SortDescriptions.Add(new SortDescription("Age", ListSortDirection.Ascending));

                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription(header.Content.ToString(), ListSortDirection.Ascending));

            }
            else
            {
                //view.SortDescriptions.Remove(new SortDescription("Age", ListSortDirection.Ascending));

                //view.SortDescriptions.Add(new SortDescription("Age", ListSortDirection.Descending));
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription(header.Content.ToString(), ListSortDirection.Descending));

            }

            isSort = !isSort;

        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvUsers.ItemsSource).Refresh();
        }
    }
}
