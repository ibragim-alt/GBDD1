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
using Microsoft.Win32;
using System.Reflection;
using System.IO;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для WinDTP.xaml
    /// </summary>
    public partial class WinDTP : Window
    {
        public WinDTP()
        {
            InitializeComponent();
            FillTable();
        }

        private void FillTable()
        {
            using (GIBDDContainer db = new GIBDDContainer())
            {
                var pro = (from p in db.Dtp                                                    
                           select new {Data = p.Date + " " + p.Time.ToString().Substring(0, 5),
                               Victims = p.Victim,
                               Participant = db.Dtp.Where(b => b.IdFines == p.IdFines).Count(),
                               Classification = p.Description  }).ToList().Distinct();
                DGdtp.ItemsSource = pro;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddDTP addDTP = new AddDTP();
            addDTP.Show();
            this.Close();

        }
    }
}
