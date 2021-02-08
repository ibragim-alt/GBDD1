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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            int a = 0;
            if (TextBoxLogin.Text == TextBoxPasword.Text && TextBoxLogin.Text.Length > 0)
            {
                MessageBox.Show("Пользователь авторизован");
            }

            if (TextBoxLogin.Text != TextBoxPasword.Text)
            {
                a = a + 1;
                if (a > 3)
                {
                    MessageBox.Show("Попытки кончились");
                }

            }

            if (TextBoxLogin.Text.Length == 0)
            {
                MessageBox.Show("Логин отсутствует");
            }
            if (TextBoxPasword.Text.Length == 0)
            {
                MessageBox.Show("Пароль отсутствует");
            }


        }


    }
}
