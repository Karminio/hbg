using HotelEngine;
using System.Windows;

namespace WpfGUI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class GameMainWindow : Window
    {
        GameLogicObj theLogic;

        public GameMainWindow()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            theLogic = new GameLogicObj();

            StartGameWindow sgw = new StartGameWindow(theLogic);
            sgw.ShowDialog();

        }



    }
}
