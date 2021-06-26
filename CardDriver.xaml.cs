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
    /// Логика взаимодействия для CardDriver.xaml
    /// </summary>
    public partial class CardDriver : Window
    {
        List<licence> licences = new List<licence>();
        public CardDriver()
        {
            InitializeComponent();
            TBDriver.IsEnabled = false;
           
            
        }
        public string path;
        public int id;

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            using (GIBDDContainer db = new GIBDDContainer())
            {
                licence lic = new licence();
                lic.idDriver = int.Parse(TBDriver.Text);
                
                lic.categories = TBCategory.Text;
                lic.licenceNum = TBNumberCard.Text;
                lic.licenceDate = DPlicenceDate.SelectedDate;
                lic.expireDate = DPexpireDate.SelectedDate;
                db.licence.Add(lic);
                db.SaveChanges();
                MessageBox.Show("Данные добавлены");
                licences.Clear();
                foreach (licence u in db.licence)
                    licences.Add(u);
                DataGridCardDriver.ItemsSource = licences;

            }
        }

        private void ButtonChange_Click(object sender, RoutedEventArgs e)
        {
            if (path != null)
            {
                using (GIBDDContainer db = new GIBDDContainer())
                {
                    Drivers drivers = db.Drivers.Find(int.Parse(TBDriver.Text));
                    licence licen = db.licence.Find(TBNumberCard.Text);
                    licen.idDriver = int.Parse(TBDriver.Text);
                   
                    licen.categories = TBCategory.Text;
                    //licen.licenceNum = TBNumberCard.Text;
                    licen.licenceDate = DPlicenceDate.SelectedDate;
                    licen.expireDate = DPexpireDate.SelectedDate;
                    drivers.photo = path.Substring(path.LastIndexOf("\\") + 1);
                    db.SaveChanges();
                    MessageBox.Show("Данные изменены");
                    Voditeli voditeli = new Voditeli();
                    voditeli.Show();
                    this.Hide();
                }
            }
        }

        private void ButtonPhoto_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Image files(*.BMP, *.JPG, *.PNG)|*.bmp;*.jpg;*.png;*";
            if (dialog.ShowDialog() == true)
            {
                path = dialog.FileName;
                Imagephoto.Stretch = Stretch.Uniform;
                Imagephoto.Source = new BitmapImage(new Uri(path));

            }

            string path2 = Assembly.GetExecutingAssembly().Location.ToString();
            File.Copy(path, path2.Substring(0, path2.LastIndexOf("\\")) + "\\photo\\" + path.Substring(path.LastIndexOf("\\") + 1), true);
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Voditeli voditeli = new Voditeli();
            voditeli.Show();
            this.Close();
        }
    }
}
