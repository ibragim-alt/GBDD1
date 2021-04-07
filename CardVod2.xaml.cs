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
    /// Логика взаимодействия для CardVod2.xaml
    /// </summary>
    public partial class CardVod2 : Window
    {
        public CardVod2()
        {
            InitializeComponent();
        }
        public int id;

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            
            using (GIBDDContainer db = new GIBDDContainer())
            {
                Drivers drivers = new Drivers();
                licence licence = new licence();
                drivers.name = TBName.Text;
                drivers.lastname = TBSurname.Text;
                drivers.middlename = TBMiddleName.Text;
                licence.licenceDate = Issue.SelectedDate;
                licence.expireDate = Date.SelectedDate;
                licence.categories = TBCategory.Text;
                drivers.addressLife = TBLifeAdress.Text;
                db.SaveChanges();


            }
             Voditeli vod = new Voditeli();
             vod.Show();
             this.Hide();
                
                                      
        }
    }
}
