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
    /// Логика взаимодействия для AddTrans1.xaml
    /// </summary>
    public partial class AddTrans1 : Window
    {
        public AddTrans1()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            using (GIBDDContainer db = new GIBDDContainer())
            {
               Transports trans = new Transports();
                trans.VIN = TBVIn.Text;
                trans.Manuf = int.Parse(CBMark.Text);
                trans. Color = int.Parse(TBNumberColor.Text);
                trans.Engine_Type = int.Parse(TBTypeEngine.Text);
                trans.TypeOfDrive = int.Parse(TBTypePrivod.Text);
                trans.Weight = int.Parse(TBWeight.Text);
                trans.Year = int.Parse(TBdateAuto.Text);
                db.Transports.Add(trans);
                db.SaveChanges();


            }
            Voditeli NewGIBDD = new Voditeli();
            NewGIBDD.Show();
            this.Hide();
        }
    }
}
