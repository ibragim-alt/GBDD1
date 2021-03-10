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
    /// Логика взаимодействия для WinTeam.xaml
    /// </summary>
    public partial class WinTeam : Window
    {
        List<Team> teams = new List<Team>();
        public WinTeam()
        {
            InitializeComponent();
            FillTable();
        }
        private void FillTable()
        {
            teams.Clear();

            using (SoccerContainer db = new SoccerContainer())
            {
                foreach (Team u in db.TeamSet)
                {
                    teams.Add(u);
                }

                DataGridTeam.ItemsSource = db.TeamSet.Local.ToBindingList();
            }
        }

        private void ButtonTeam_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridTeam.Items.Count > 0)
            {
                var index = DataGridTeam.SelectedItem;
                if (index != null)
                {
                    int id = int.Parse((DataGridTeam.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);
                    using (SoccerContainer db = new SoccerContainer())
                    {
                        Team team = db.TeamSet.Find(id);
                        ListBoxPlayer.ItemsSource = team.PlayerSet.ToList();
                        ListBoxPlayer.DisplayMemberPath = "Name";
                    }
                }
                FillTable();
            }
        }
    }
}
