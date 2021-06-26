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
using VIN_LIB;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для AddTrans.xaml
    /// </summary>
    public partial class AddTrans : Window
    {
        public AddTrans()
        {
            InitializeComponent();

        }
        

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Class1 class1 = new Class1();
            using (GIBDDContainer db = new GIBDDContainer())
            {

                
                if (class1.CheckVIN(TBVIn.Text) == true)
                { 
                    Transports tran = new Transports();
                    tran.VIN = TBVIn.Text;
                    tran.ID_Drivers = int.Parse(TBDriver.Text);
                    tran.Manuf = int.Parse(TBMark.Text);
                    tran.Color = int.Parse(TBNumberColor.Text);
                    tran.Engine_Type = int.Parse(TBTypeEngine.Text);
                    tran.TypeOfDrive = int.Parse(TBTypePrivod.Text);
                    tran.Year = int.Parse(TBdateAuto.Text);
                    tran.Weight = int.Parse(TBWeight.Text);

                    db.Transports.Add(tran);
                    db.SaveChanges();
                    MessageBox.Show("Транспортное средство добавлено");
                    Voditeli vod = new Voditeli();
                }
                else
                {
                    MessageBox.Show("VIN номер не правльный");
                }
            }


        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Voditeli voditeli = new Voditeli();
            voditeli.Show();

            this.Hide();
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            if (DGTS.Items.Count > 0)
            {
                var index = DGTS.SelectedItem;
                string id = ((DGTS.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);
                using (GIBDDContainer db = new GIBDDContainer())
                {
                    Transports tran = db.Transports.Find(id);
                    TBVIn.Text = tran.VIN;
                    TBDriver.Text = tran.ID_Drivers.ToString();
                    TBMark.Text = tran.Manuf.ToString();
                    TBNumberColor.Text = tran.Color.ToString();
                    TBTypeEngine.Text = tran.Engine_Type.ToString();
                    TBTypePrivod.Text = tran.TypeOfDrive.ToString();
                    TBdateAuto.Text = tran.Year.ToString();
                    TBWeight.Text = tran.Weight.ToString();



                }
            }
        }

        private void ButtonChange_Click(object sender, RoutedEventArgs e)
        {
            using (GIBDDContainer db = new GIBDDContainer())
            {
                Transports tran = db.Transports.Find(TBVIn.Text);
                tran.VIN = TBVIn.Text;
                tran.ID_Drivers = int.Parse(TBDriver.Text);
                tran.Manuf = int.Parse(TBMark.Text);
                tran.Color = int.Parse(TBNumberColor.Text);
                tran.Engine_Type = int.Parse(TBTypeEngine.Text);
                tran.TypeOfDrive = int.Parse(TBTypePrivod.Text);
                tran.Year = int.Parse(TBdateAuto.Text);
                tran.Weight = int.Parse(TBWeight.Text);

                db.SaveChanges();
                MessageBox.Show("ТС изменено");
            }
        }
    }            
            
}   