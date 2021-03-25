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
        List<Transports> transports = new List<Transports>();
        List<Dtp> dtps = new List<Dtp>();
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
            
                if (DataGridVod.Items.Count > 0)
                {
                    var index = DataGridVod.SelectedItem;
                    if (index != null)
                    {
                        int id = int.Parse((DataGridVod.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);

                        CardDriver card = new CardDriver();
                        //MakeVod make = new MakeVod();

                        using (GIBDDContainer db = new GIBDDContainer())

                        {

                            Drivers drivers = db.Drivers.Find(id);
                            licence licence = db.licence.FirstOrDefault(p=>p.idDriver==id);

                            card.TBName.Text = drivers.name;
                            card.TBSurname.Text = drivers.lastname;
                            card.TBMiddleName.Text = drivers.middlename;
                            
                            card.TBDateIssue.Text = licence.licenceDate.ToString();
                            card.TBDateExpire.Text = licence.expireDate.ToString();
                            card.TBCategory.Text = licence.categories;
                            card.TBLifeAdress.Text = drivers.addressLife;

                            var licences = db.licence.Where(p => p.idDriver == id).ToList();
                            card.DataGridCardDriver.ItemsSource = licences;





                            //MessageBox.Show(.ShowDialog().HasValue.ToString());
                            if (!card.ShowDialog().HasValue) return;

                            drivers.name = card.TBName.Text;
                            drivers.lastname = card.TBSurname.Text;
                            drivers.middlename = card.TBMiddleName.Text;
                            licence.licenceDate = DateTime.Parse(card.TBDateIssue.Text);
                            licence.expireDate = DateTime.Parse(card.TBDateExpire.Text);
                            licence.categories = card.TBCategory.Text;
                            drivers.addressLife = card.TBLifeAdress.Text;



                            db.SaveChanges();
                            FillTable();

                        }
                    }

                }
            
        }

        private void ButtonTS_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridVod.SelectedItem;
            WinTrans winTrans = new WinTrans();
            if (index ==null)
            {
                winTrans.Show();
                this.Hide();
                using (GIBDDContainer db = new GIBDDContainer())
                {
                    foreach (Transports t in db.Transports)
                        transports.Add(t);
                    winTrans.DGTrans.ItemsSource = db.Transports.Local.ToBindingList();
                }
            }
            else 
            {
              
                int id = int.Parse((DataGridVod.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);
               
                using (GIBDDContainer db = new GIBDDContainer())
                {
                    var transport = db.Transports.Where(p => p.ID_Drivers == id).ToList();
                    
                    winTrans.DGTrans.ItemsSource = transport;
                      winTrans.Show();
                   
                this.Hide();
                }
            }
            

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var index = DataGridVod.SelectedItem;
            WinDTP win = new WinDTP();
            if (index == null)
            {
                win.Show();
                this.Hide();
                using (GIBDDContainer db = new GIBDDContainer())
                {
                    foreach (Dtp t in db.Dtp)
                        dtps.Add(t);
                    win.DGdtp.ItemsSource = db.Dtp.Local.ToBindingList();
                }
            }
            else
            {

                int id = int.Parse((DataGridVod.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);

                using (GIBDDContainer db = new GIBDDContainer())
                {
                    var dtp = db.Dtp.Where(p => p.IdDrivers == id).ToList();

                    win.DGdtp.ItemsSource = dtp;
                    win.Show();

                    this.Hide();
                }
            }
        }

        
    }
}
