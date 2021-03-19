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
            licence lic = new licence();
            using (GIBDDContainer db = new GIBDDContainer())
            {                       
                  lic.licenceDate =DateTime.Parse(TBDateIssue.Text);
                lic.idDriver = id;
                lic.expireDate = DateTime.Parse(TBDateExpire.Text);
                lic.categories = TBCategory.Text;
                lic.licenceNum = TBNumberCard.Text;                       
                db.licence.Add(lic);
                db.SaveChanges();


            }
                    Voditeli NewGIBDD = new Voditeli();
                    NewGIBDD.Show();
                    this.Hide();
                
                                      
        }
    }
}
