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
        public int id;
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CardVod2 cardVod2 = new CardVod2();
            cardVod2.Show();
            this.Hide();
        }
    }
}
