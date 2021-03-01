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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (GIBDDContainer db = new GIBDDContainer())
            {
                Drivers driver = new Drivers();
                driver.address = TextBoxName.Text;
                driver.addressLife = TextBoxAdressReg.Text;
                driver.company = TextBoxWork.Text;
                driver.descreption = TextBoxNote.Text;
                driver.email = TextBoxEmail.Text;
                driver.phone = TextBoxPhone.Text;
                driver.name = TBSurname.Text;
                driver.lastname = TextBoxSurname.Text;
                driver.middlename = TextBoxMiddleName.Text;

                driver.photo = path.Substring(path.LastIndexOf("\\") + 1);
                driver.postCode = int.Parse(TextBoxId.Text);

                db.Drivers.Add(driver);
                db.SaveChanges();


            }
        }
    }
}
