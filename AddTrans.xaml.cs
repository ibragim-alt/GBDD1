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
    /// Логика взаимодействия для AddTrans.xaml
    /// </summary>
    public partial class AddTrans : Window
    {
        public AddTrans()
        {
            InitializeComponent();

        }
        public string path;

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

            if (TBVIn.Text.Length != 0)
            {
                if (TBMark.Text.Length != 0)
                {
                    if (TBModel.Text.Length != 0)
                    {
                        if (TBTypeTs.Text.Length != 0)
                        {
                            if (TBCategory.Text.Length != 0)
                            {
                                if (TBdateAuto.Text.Length != 0)
                                {
                                    if (TBNumberColor.Text.Length != 0)
                                    {
                                        if (TBWeight.Text.Length != 0)
                                        {
                                            if (TBTypeEngine.Text.Length != 0)
                                            {
                                                if (TBWeightLbs.Text.Length != 0)
                                                {
                                                    if (TBTypePrivod.Text.Length != 0)
                                                    {
                                                        if (path != null)
                                                        {
                                                            using (GIBDDContainer db = new GIBDDContainer())
                                                            {
                                                                Transports tran = new Transports();

                                                                tran.VIN = TBVIn.Text;
                                                                tran.ID_Drivers = int.Parse(TBDriver.Text);
                                                                tran.Manuf = int.Parse(TBMark.Text);
                                                                tran.Color = int.Parse(TBNumberColor.Text);
                                                                tran.Engine_Type = int.Parse(TBTypeEngine.Text);
                                                                tran.TypeOfDrive = TBTypePrivod.Text;
                                                                db.Transports.Add(tran);
                                                                db.SaveChanges();

                                                            }
                                                            WinTrans wTran = new WinTrans();
                                                            wTran.Show();
                                                            this.Hide();
                                                        }

                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Не заполнено поле Тип привода");
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Не заполнено поле Вес автомобиля(кг)");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Не заполнено поле Тип двигателя");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Не заполнено поле Вес автомобиля");
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("Не заполнено поле Номер цвета");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Не заполнено поле год выпуска ");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Не заполнено поле категория ТС");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Не заполнено поле Тип ТС");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не заполнено поле Модель");
                    }
                }
                else
                {
                    MessageBox.Show("Не заполнено поле Марка");
                }
            }
            else
            {
                MessageBox.Show("Не заполнено поле VIN");
            }
        }            
     }       
}   