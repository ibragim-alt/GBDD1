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
using System.Data.Entity;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Voditeli.xaml
    /// </summary>
    public partial class Voditeli : Window
    {
        List<Drivers> drivers = new List<Drivers>();
        public Voditeli()
        {
            InitializeComponent();
            FillTable();
        }

        private void FillTable()
        {
            drivers.Clear();
            using (GIBDDContainer db = new GIBDDContainer())
            {
                foreach (Drivers u in db.Drivers)

                {
                    drivers.Add(u);
                }

                DataGridVod.ItemsSource = db.Drivers.Local.ToBindingList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
