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
using System.Data.Entity;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Player> players = new List<Player>();
        public MainWindow()
        {
            InitializeComponent();
            FillTable();
        }

        private void FillTable()
        {
            players.Clear();

            using (SoccerContainer db = new SoccerContainer())
            {
                foreach (Player u in db.PlayerSet)
                {
                    players.Add(u);
                }

                DataGridPlayer.ItemsSource = db.PlayerSet.Local.ToBindingList();
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WinPlayer winPlayer = new WinPlayer();
            if (!winPlayer.ShowDialog().HasValue) return;

            using (SoccerContainer db = new SoccerContainer())
            {
                Player player = new Player();
                player.Age = int.Parse(winPlayer.TextBoxAge.Text);
                player.Name = winPlayer.TextBoxName.Text;
                player.Position = winPlayer.ComboBoxPos.Text;
                player.TeamId = int.Parse(winPlayer.ComboBoxTeam.SelectedValue.ToString());
                db.PlayerSet.Add(player);
                db.SaveChanges();

            }
            FillTable();
        }

        private void ButtonChange_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridPlayer.Items.Count>0)
            {
                var index = DataGridPlayer.SelectedItem;
                if (index != null)
                {
                    int id = int.Parse((DataGridPlayer.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);
                
                    WinPlayer winPlayer = new WinPlayer();
               
                    using (SoccerContainer db = new SoccerContainer())
                
                    {

                    
                        Player player = db.PlayerSet.Find(id);
                    
                        winPlayer.TextBoxName.Text = player.Name;
                    
                        winPlayer.TextBoxAge.Text = player.Age.ToString();
                    
                        winPlayer.ComboBoxPos.Text = player.Position;
                        winPlayer.ComboBoxTeam.SelectedIndex = winPlayer.teams.FindIndex(item => item.Id == player.TeamId);

                    
                        if (!winPlayer.ShowDialog().HasValue) return;

                    
                        player.Age = int.Parse(winPlayer.TextBoxAge.Text);
                    
                        player.Name = winPlayer.TextBoxName.Text;
                    
                        player.Position = winPlayer.ComboBoxPos.Text;
                    
                        db.SaveChanges();

                
                    } 
                }
                
            }
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridPlayer.Items.Count > 0)
            {
                var index = DataGridPlayer.SelectedItem;
                if (index != null)
                {
                    int id = int.Parse((DataGridPlayer.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);
                    using (SoccerContainer db = new SoccerContainer())
                    {
                        Player player = db.PlayerSet.Find(id);
                        db.PlayerSet.Remove(player);
                        db.SaveChanges();
                    }
                }
            }
            FillTable();
        }

        private void ButtonTeam_Click(object sender, RoutedEventArgs e)
        {
            WinTeam form = new WinTeam();
            form.Show();
            Close();
        }

        private void ButtonLinq_Click(object sender, RoutedEventArgs e)
        {
            WinLinq winLinq = new WinLinq();
            winLinq.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WinLinq2 winLinq = new WinLinq2();
            winLinq.Show();
            this.Hide();
        }

        private void ButtonWinSql_Click(object sender, RoutedEventArgs e)
        {
            WinSql winSql = new WinSql();
            winSql.Show();
            this.Hide();
        }
    }
}
