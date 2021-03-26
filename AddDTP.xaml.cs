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
        public AddDTP()
        {
            InitializeComponent();
        }
        public string path;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddMember addMember = new AddMember();
            addMember.Show();
            this.Close();
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
            File.Copy(path, path2.Substring(0, path2.LastIndexOf("\\")) + "\\photo\\" + path.Substring(path.LastIndexOf("\\") + 1), true);
        }
    }
}
