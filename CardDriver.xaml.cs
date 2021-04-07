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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для CardDriver.xaml
    /// </summary>
    public partial class CardDriver : Window
    {
        //List<licence> licences = new List<licence>();
        public CardDriver()
        {
            InitializeComponent();
            
        }
        public string path;
        public int id;
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (path != null)
            {
                using (GIBDDContainer db = new GIBDDContainer())
                {
                    Drivers drivers = db.Drivers.Find(id);
                    licence licence = db.licence.FirstOrDefault(p => p.idDriver == id);
                    drivers.name = TBName.Text;
                    drivers.lastname = TBSurname.Text;
                    drivers.middlename = TBMiddleName.Text;
                    licence.licenceDate = DateTime.Parse(TBDateIssue.Text);
                    licence.expireDate = DateTime.Parse(TBDateExpire.Text);
                    licence.categories = TBCategory.Text;
                    drivers.addressLife = TBLifeAdress.Text;
                    db.SaveChanges();

                    Voditeli voditeli = new Voditeli();
                    voditeli.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Информация изменена");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CardVod2 cardVod2 = new CardVod2();
            cardVod2.Show();
            this.Hide();
        }
    }
}
