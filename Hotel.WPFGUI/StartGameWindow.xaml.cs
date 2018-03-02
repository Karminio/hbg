using HotelEngine;
using System.Windows;
using System.Windows.Controls;

namespace WpfGUI
{
    /// <summary>
    /// Interaction logic for StartGameWindow.xaml
    /// </summary>
    public partial class StartGameWindow : Window
    {
        GameLogicObj theLogic;

        public StartGameWindow(GameLogicObj logic)
        {
            InitializeComponent();
            theLogic = logic;
            rbSolo.IsChecked = true;
        }

        private void btAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (txtPlayerName.Text == "")
            {
                MessageBox.Show("Please type a name for the player");
                return;
            }

            if (!theLogic.AddPlayer(txtPlayerName.Text, "Red"))
            {
                MessageBox.Show("A player with this name has already been defined");
                return;
            }

            lbPlayers.Items.Add(txtPlayerName.Text);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            string name = ((RadioButton)sender).Name;

            if (name.Equals("rbSolo"))
            {
                tabLAN.IsEnabled = false;
                tabInternet.IsEnabled = false;
            }
            else if (name.Equals("rbLAN"))
            {
                tabLAN.IsEnabled = true;
                tabInternet.IsEnabled = false;
            }
            else
            {
                tabLAN.IsEnabled = false;
                tabInternet.IsEnabled = true;
            }
        }

        private void btOK_Click(object sender, RoutedEventArgs e)
        {

        }



    }
}
