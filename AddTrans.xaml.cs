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
            using (GIBDDContainer db = new GIBDDContainer())
            {
                if (TBDriver.Text.Length !=0)
                {
                    string[] fols = TBDriver.Text.Split();
                    string firstname = fols[1];
                    string lastname = fols[0];
                    string middlename = fols[2];
                    Class1 class1 = new Class1();
                    Drivers drivers1 = db.Drivers.FirstOrDefault(p => p.name == firstname && p.lastname == lastname && p.middlename == middlename);
                    if(drivers1 !=null)
                    { if (class1.CheckVIN(TBVIn.Text) == true)
                        {
                            if (TBVIn.Text.Length == 17 && TBMark.Text.Length != 0 && TBNumberColor.Text.Length != 0 && TBTypeEngine.Text.Length != 0 && TBTypeTs.Text.Length != 0 && TBModel.Text.Length != 0 && TBdateAuto.Text.Length != 0 && TBWeight.Text.Length != 0)
                            {
                                Transports tran = new Transports();
                                Manufacture manufacture = db.Manufacture.FirstOrDefault(c => c.Name == TBMark.Text);
                                tran.Manuf = manufacture.ID_manuf;
                                ColorCars color = db.ColorCars.FirstOrDefault(c => c.ColorName == TBNumberColor.Text);
                                tran.Color = color.ColorNum;
                                EngineType engine = db.EngineType.FirstOrDefault(c => c.NameRu == TBTypeEngine.Text);
                                tran.Engine_Type = engine.Id_Engine;
                                tran.ID_Drivers = drivers1.Id;
                                Transports trans = db.Transports.FirstOrDefault(c => c.VIN == TBVIn.Text);
                                tran.VIN = trans.VIN;
                                tran.Weight = int.Parse(TBWeight.Text);
                                tran.Year = int.Parse(TBdateAuto.Text);
                                TypeOfDrive typeOfDrive = db.TypeOfDrive.FirstOrDefault(c => c.TypeDrive == TBTypeTs.Text);
                                tran.TypeOfDrive = typeOfDrive.IDTypeOfDrive;

                                db.Transports.Add(tran);
                                db.SaveChanges();
                                WinTrans winTrans = new WinTrans();
                                winTrans.Show();
                                this.Close();
                            }
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("Водитель не найден");
                        AddVoditel addVoditel = new AddVoditel();
                        addVoditel.TextBoxSurname.Text = lastname;

                        addVoditel.Show();

                    }

                }
                 else
                        {
                            MessageBox.Show("Введите владельца");
                        }

            }
           
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Voditeli voditeli = new Voditeli();
            voditeli.Show();

            this.Hide();
        }
    }            
            
}   