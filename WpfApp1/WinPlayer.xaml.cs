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
    /// Логика взаимодействия для WinPlayer.xaml
    /// </summary>
    /// 

    
    public partial class WinPlayer : Window
    {
        public List<Team> teams = new List<Team>();
        public WinPlayer()
        {
            InitializeComponent();
            using (SoccerContainer db = new SoccerContainer())
            {
                teams.Clear();
                teams = db.TeamSet.ToList();
                ComboBoxTeam.ItemsSource = teams;
                ComboBoxTeam.DisplayMemberPath = "Name";
                ComboBoxTeam.SelectedValuePath = "Id";
            }
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
