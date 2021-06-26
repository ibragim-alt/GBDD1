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
    /// Логика взаимодействия для Voditeli.xaml
    /// </summary>
    public partial class Voditeli : Window
    {
        List<Drivers> drivers = new List<Drivers>();
        List<Transports> transports = new List<Transports>();
        List<Dtp> dtps = new List<Dtp>();
        List<licence> licences1 = new List<licence>();
        public Voditeli()
        {
            InitializeComponent();
            FillTable();
        }

        public string path;

        public string path2;

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

        private void ButtonCarta_Click(object sender, RoutedEventArgs e)
        {
            CardDriver card = new CardDriver();
            
                if (DataGridVod.Items.Count > 0)
                {
                    var index = DataGridVod.SelectedItem;
                    if (index != null)
                    {
                        int id = int.Parse((DataGridVod.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);

                        using (GIBDDContainer db = new GIBDDContainer())
                        {
                            Drivers drivers = db.Drivers.Find(id);
                            var licence = db.licence.First(p=>p.idDriver==id);
                            card.TBNumberCard.Text = licence.licenceNum;
                            card.TBSurname.Text = drivers.lastname;
                            card.TBName.Text = drivers.name;                            
                            card.DPexpireDate.SelectedDate = licence.expireDate;
                            card.DPlicenceDate.SelectedDate = licence.licenceDate;
                            card.TBCategory.Text = licence.categories;                           
                            
                            card.TBDriver.Text = licence.idDriver.ToString();
                            string path = drivers.photo;
                            string path2 = Assembly.GetExecutingAssembly().Location.ToString();
                            string photo = path2.Substring(0, path2.LastIndexOf("\\")) + "\\photo\\" + path.Substring(path.LastIndexOf("\\") + 1);
                            card.Imagephoto.Source = new BitmapImage(new Uri(photo));
                        card.path = photo;
                        var licences = db.licence.Where(p => p.idDriver == id).ToList();
                        card.DataGridCardDriver.ItemsSource = licences; 
                        }
                    }
                card.Show();
                this.Hide();

            }
            
        }

        private void ButtonTS_Click(object sender, RoutedEventArgs e)
        {
            {
                using (GIBDDContainer db = new GIBDDContainer())
                {
                    AddTrans addTrans = new AddTrans();
                    var transport = db.Transports.Join(db.Manufacture, p => p.Manuf, c => c.ID_manuf, (p, c) => new { VIN = p.VIN, ID_Drivers = p.ID_Drivers, Manuf = c.Name, Year = p.Year, Weight = p.Weight, Color = p.Color, EngineType = p.Engine_Type, TypeOfDrive = p.TypeOfDrive }).ToList();
                    addTrans.DGTS.ItemsSource = transport;

                    addTrans.Show();
                    this.Hide();
                }

            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WinDTP winDTP = new WinDTP();
            winDTP.Show();
            this.Hide();

        }

       

        private void peredTS_Click(object sender, RoutedEventArgs e)
        {
            PeredTS peredTS = new PeredTS();
            peredTS.Show();
            this.Hide();
        }
    }
}
