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
            AddVoditel addVoditel = new AddVoditel();
            addVoditel.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            {
                if (DataGridVod.Items.Count > 0)
                {
                    var index = DataGridVod.SelectedItem;
                    if (index != null)
                    {
                        int id = int.Parse((DataGridVod.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);

                        MakeVod make = new MakeVod();

                        using (GIBDDContainer db = new GIBDDContainer())

                        {
                           

                            Drivers drivers = db.Drivers.Find(id);

                            make.TextBoxMakeName.Text = drivers.name;
                            make.TextBoxMakeSurname.Text = drivers.lastname;
                            make.TextBoxMakeMiddle.Text = drivers.middlename;
                            make.TextBoxMakePasportSeria.Text = drivers.passportSerial.ToString();
                            make.TextBoxMakePasportNumber.Text = drivers.passportNumber.ToString();
                            make.TextBoxMakeReg.Text = drivers.address;
                            make.TextBoxMakeLife.Text = drivers.addressLife;
                            make.TextBoxMakeWork.Text = drivers.company;
                            make.TextBoxMakeJobName.Text = drivers.jobname;
                            make.TextBoxMakePhone.Text = drivers.phone;
                            make.TextBoxMakeEmail.Text = drivers.email;
                           // MessageBox.Show(make.ShowDialog().HasValue.ToString());
                            if (!make.ShowDialog().HasValue) return;

                            drivers.name=make.TextBoxMakeName.Text;
                            drivers.lastname = make.TextBoxMakeSurname.Text;
                            drivers.middlename = make.TextBoxMakeMiddle.Text;
                            drivers.passportSerial=int.Parse(make.TextBoxMakePasportSeria.Text);
                            drivers.passportNumber = int.Parse(make.TextBoxMakePasportSeria.Text);
                            drivers.address = make.TextBoxMakeReg.Text;
                            drivers.addressLife = make.TextBoxMakeLife.Text;
                            drivers.company = make.TextBoxMakeWork.Text;
                            drivers.jobname = make.TextBoxMakeJobName.Text;
                            drivers.phone = make.TextBoxMakePhone.Text;
                            drivers.email = make.TextBoxMakeEmail.Text;

                            db.SaveChanges();
                            FillTable();

                        }
                    }

                }
            }
        }

        private void ButtonCarta_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
