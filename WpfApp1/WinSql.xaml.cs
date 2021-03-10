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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для WinSql.xaml
    /// </summary>
    public partial class WinSql : Window
    {
        public WinSql()
        {
            InitializeComponent();
        }

        private void ButtonAll_Click(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                var player = db.Database.SqlQuery<Player>("Select * from PlayerSet").ToList();
                DataGridWinSql.ItemsSource = player;
                
            }


        }

        private void ButtonAny_Click(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                var player = db.Database.SqlQuery<Player>("Select * from PlayerSet where Age >30").ToList();
                DataGridWinSql.ItemsSource = player;

            }
        }

        private void ButtonParam_Click(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@name", "А%");

                var player = db.Database.SqlQuery<Player>("Select * from PlayerSet where Name Like @name", param).ToList();
                DataGridWinSql.ItemsSource = player;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                int numberOfRowInserted = db.Database.ExecuteSqlCommand("Insert into PlayerSet values ('Погребняк', 'Нападающий', 24, 5)");
                int numberOfRowUpdated = db.Database.ExecuteSqlCommand("Update  PlayerSet Set Name='Погребняк' where Id=24");
                int numberOfDeleted = db.Database.ExecuteSqlCommand("Delete from PlayerSet values where Id=28");
                LabelCount.Content = numberOfRowInserted.ToString()+ "\n" + numberOfRowUpdated.ToString()+ "\n"
            }    
        }
    }
}
