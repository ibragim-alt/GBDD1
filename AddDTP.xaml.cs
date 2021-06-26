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
    /// Логика взаимодействия для AddDTP.xaml
    /// </summary>
    public partial class AddDTP : Window
    {
        List<Drivers> driver = new List<Drivers>();
        
        public AddDTP()
        {
            InitializeComponent();
        }
        public string path;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TBAdd.Text.Split().Length ==3)
            {
                string[] owner = TBAdd.Text.Split();
                string firstname = owner[1];
                string lastname = owner[0];
                string middlename = owner[2];

                using (GIBDDContainer db = new GIBDDContainer())
                {
                    Drivers drivers = db.Drivers.FirstOrDefault(c => c.name == firstname && c.lastname == lastname && c.middlename == middlename);
                    if (drivers != null)
                    {
                        licence licence = db.licence.FirstOrDefault(p => p.idDriver == drivers.Id);
                        driver.Add(new Drivers { lastname = owner[0], middlename = owner[2], name = owner[1] });
                        LBAdd.Items.Add(TBAdd.Text+", Лицензия: "+ licence.licenceNum);
                        TBAdd.Clear();

                    }
                    else { MessageBox.Show("ФИО не правильно");
                        return;
                    }
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.JPG, *.PNG) | *.jpg; *.png;";
            if (dialog.ShowDialog() == true)
            {
                path = dialog.FileName;
                ImagePhoto.Stretch = Stretch.Uniform;
                ImagePhoto.Source = new BitmapImage(new Uri(path));
            }
            string path2 = Assembly.GetExecutingAssembly().Location.ToString();
            File.Copy(path, path2.Substring(0, path2.LastIndexOf("\\")) + "\\photo1\\" + path.Substring(path.LastIndexOf("\\") + 1), true);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.JPG, *.PNG) | *.jpg; *.png;";
            if (dialog.ShowDialog() == true)
            {
                path = dialog.FileName;
                ImagePhoto1.Stretch = Stretch.Uniform;
                ImagePhoto1.Source = new BitmapImage(new Uri(path));
            }
            string path2 = Assembly.GetExecutingAssembly().Location.ToString();
            File.Copy(path, path2.Substring(0, path2.LastIndexOf("\\")) + "\\photo1\\" + path.Substring(path.LastIndexOf("\\") + 1), true);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.JPG, *.PNG) | *.jpg; *.png;";
            if (dialog.ShowDialog() == true)
            {
                path = dialog.FileName;
                ImagePhoto2.Stretch = Stretch.Uniform;
                ImagePhoto2.Source = new BitmapImage(new Uri(path));
            }
            string path2 = Assembly.GetExecutingAssembly().Location.ToString();
            File.Copy(path, path2.Substring(0, path2.LastIndexOf("\\")) + "\\photo1\\" + path.Substring(path.LastIndexOf("\\") + 1), true);
        }
    }
}
