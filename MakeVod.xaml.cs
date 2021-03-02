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
    /// Логика взаимодействия для MakeVod.xaml
    /// </summary>
    public partial class MakeVod : Window
    {
        public List<Drivers> drivers = new List<Drivers>();
        public MakeVod()
        {
            InitializeComponent();
            using (GIBDDContainer db = new GIBDDContainer())
            {
                drivers.Clear();
                drivers = db.Drivers.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
           
           // this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
           // this.Close();
        }
    }
}
