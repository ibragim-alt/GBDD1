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
    /// Логика взаимодействия для AddVoditel.xaml
    /// </summary>
    public partial class AddVoditel : Window
    {
        public AddVoditel()
        {
            InitializeComponent();
        }
        string path;
        string path1;
        string path2;

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
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

        private bool CheckEmail (string email)
        {
            if (email.IndexOf("@") > 0 && email.IndexOf(".") > 0)
            {
                if (email.Split('@')[1].Split('.').Length ==2)
                {
                    return true;
                }
            }
            return false;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxId.Text.Length != 0)
            {
                if (TextBoxSurname.Text.Length != 0)
                {
                    if (TextBoxName.Text.Length != 0)
                    {
                        if (TextBoxMiddleName.Text.Length != 0)
                        {
                            if (TextBoxPasport.Text.Length != 0)
                            {
                                if (TextBoxAdressReg.Text.Length != 0 || TextBoxAdress.Text.Length != 0)
                                {
                                    if (TextBoxPhone.Text.Length != 0)
                                    {
                                        if (TextBoxEmail.Text.Length != 0 && CheckEmail(TextBoxEmail.Text) == true)
                                        {
                                            if (path != null)
                                            {
                                                using (GIBDDContainer db = new GIBDDContainer())
                                                {
                                                    Drivers driver = new Drivers();
                                                    driver.address = TextBoxAdress.Text;
                                                    driver.addressLife = TextBoxAdressReg.Text;
                                                    driver.company = TextBoxWork.Text;
                                                    driver.descreption = TextBoxNote.Text;
                                                    driver.email = TextBoxEmail.Text;
                                                    driver.phone = TextBoxPhone.Text;
                                                    driver.name = TextBoxName.Text;
                                                    driver.lastname = TextBoxSurname.Text;
                                                    driver.middlename = TextBoxMiddleName.Text;

                                                    driver.photo = path.Substring(path.LastIndexOf("\\") + 1);
                                                    driver.postCode = int.Parse(TextBoxId.Text);
                                                    
                                                    db.Drivers.Add(driver);
                                                    db.SaveChanges();


                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Не заполнено поле Email");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Не заполнено поле Телефон");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Не заполнены поля адресс проживания и адресс регитсрации");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Не заполнено поле серия и номер паспорта");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Не заполнено поле Отчество");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не заполнено поле Имя");
                    }
                }
                else
                {
                    MessageBox.Show("Не заполнено поле Фамилия");
                }
            }
            else 
            {
                MessageBox.Show("Не заполнено поле ID");
            }
            
                
                                
        }
    }
}
