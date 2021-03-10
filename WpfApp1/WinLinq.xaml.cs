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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для WinLinq.xaml
    /// </summary>
    public partial class WinLinq : Window
    {
        public WinLinq()
        {
            InitializeComponent();
        }

        private void ButtonWhere_Click(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                var player = db.PlayerSet.Where(z => z.Age > 30).ToList();
                DataGridResult.ItemsSource = player;
            }
        }

        private void ButtonFind_Click(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                Player player = db.PlayerSet.Find(2);
                TextBoxResult.Text = player.Name;
            }
        }

        private void ButtonFirst_Click(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                Player player = db.PlayerSet.First(p => p.TeamId == 2);
                TextBoxResult.Text = player.Name;
            }
        }

        private void ButtonFirstOrDefault_Click(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                Player player = db.PlayerSet.FirstOrDefault(p => p.TeamId == 2);
                if (player != null) TextBoxResult.Text = player.Name;
                else MessageBox.Show(" В этой команде нет игроков");
            }
        }

        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                var player = db.PlayerSet.Select(p => new
                {
                    Name = p.Name,
                    Age = p.Age,
                    Position = p.Position
                }).ToList();
                DataGridResult.ItemsSource = player;
            }
        }

        private void ButtonSort_Click(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                var player = db.PlayerSet.Select(p => new
                {
                    Name = p.Name,
                    Age = p.Age,
                    Position = p.Position

                }).OrderBy(p => p.Position).ThenBy(p => p.Name).ToList();
                DataGridResult.ItemsSource = player;
            }
        }

        List<Player> players = new List<Player>();

        private void ButtonDesc_Click(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                var player = db.PlayerSet.OrderByDescending(c => c.Name).ToList();
                DataGridResult.ItemsSource = player;
            }
        }

        private void ButtonGroup_Click(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                var player = db.PlayerSet.GroupBy(p => p.Position).Select(q => new
                {
                    Name = q.Key,
                    Count = q.Count()
                }).ToList();
                DataGridResult.ItemsSource = player;
            }
        }

        private void ButtonThenBy_Click(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                var player = db.PlayerSet.Select(p => new
                {
                    Name = p.Name,
                    Age = p.Age,
                    Position = p.Position
                    
                }).OrderBy(p =>p.Position).ThenBy(p=>p.Name).ToList();
                DataGridResult.ItemsSource = player;
            }
        }

        private void ButtonGroupBy_Click(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                var player = from p in db.PlayerSet group p by p.Position; foreach (var g in player) foreach (var p in g) players.Add(p); 
                
                DataGridResult.ItemsSource = players;
            }
        }
    }
}
