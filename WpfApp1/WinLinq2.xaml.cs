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
    /// Логика взаимодействия для WinLinq2.xaml
    /// </summary>
    public partial class WinLinq2 : Window
    {
        public WinLinq2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                var player = db.PlayerSet.Join(db.TeamSet, p => p.TeamId, c => c.Id, (p, c) => new
                {
                    Name = p.Name,
                    Team = c.Name,
                    Coach = c.Coach

                }).ToList();

                DataGridLinq2.ItemsSource = player;
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                var player = (from p in db.PlayerSet join c in db.TeamSet on p.TeamId equals c.Id select new { Name = p.Name, Team = c.Name, Coach = c.Coach }).ToList();
                DataGridLinq2.ItemsSource = player;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                var player = (db.PlayerSet.Where(q => q.TeamId == 1).Union(db.PlayerSet.Where(w => w.Position.Contains("Нападающий")))).ToList();
                DataGridLinq2.ItemsSource = player;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                var result = (db.PlayerSet.Select(w => new { Name = w.Name }).Union(db.TeamSet.Select(r => new { Name = r.Name }))).ToList();
                DataGridLinq2.ItemsSource = result;
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                var player = (db.PlayerSet.Where(q => q.TeamId == 1).Intersect(db.PlayerSet.Where(w => w.Position.Contains("Нападающий")))).ToList();
                DataGridLinq2.ItemsSource = player;
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                var player = (db.PlayerSet.Where(q => q.TeamId == 1).Except(db.PlayerSet.Where(w => w.Position.Contains("Нападающий")))).ToList();
                DataGridLinq2.ItemsSource = player;
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Hide();
        }

        private void ButtonCount1_Click(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                int number1 = db.PlayerSet.Count();
                TextBoxResult.Text = number1.ToString();
            }
                
        }

        private void BittonCount1_Click(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                int number2 = db.PlayerSet.Count(p => p.Position.Contains("Нападающий"));
                TextBoxResult.Text = number2.ToString();
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                int minAge = db.PlayerSet.Min(p => p.Age);
                TextBoxResult.Text = minAge.ToString();
            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                int maxAge = db.PlayerSet.Max(p => p.Age);
                TextBoxResult.Text = maxAge.ToString();
            }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                double avgAge = db.PlayerSet.Where(p => p.Position.Contains("Нападающий")).Average(p => p.Age);
                TextBoxResult.Text = avgAge.ToString();
            }
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                int sum1 = db.PlayerSet.Sum(p => p.Age);
                TextBoxResult.Text = sum1.ToString();
            }
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            using (SoccerContainer db = new SoccerContainer())
            {
                int sum2 = db.PlayerSet.Where(p => p.Position.Contains("Нападающий")).Sum(p => p.Age);
                TextBoxResult.Text = sum2.ToString();
            }
        }
    }
}
