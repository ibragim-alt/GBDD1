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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int k = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxLogin.Text == "Inspector" && PasswordBoxPass.Password == "Inspector")
            {
                MessageBox.Show("Успешный вход ");
            }
            else
            {
                MessageBox.Show("Данные неверны");
            }
            {

                k++;
                if (k >= 3)
                {
                    TextBoxLogin.IsEnabled = false;
                    ButtonOk.IsEnabled = false;
                    PasswordBoxPass.IsEnabled = false;
                    MessageBox.Show("Все попытки входа закончены.");


                }
                if (TextBoxLogin.Text.Length == 0)
                {
                    MessageBox.Show("Заполните поле логин");
                }

               
            }


        }


    }
}
