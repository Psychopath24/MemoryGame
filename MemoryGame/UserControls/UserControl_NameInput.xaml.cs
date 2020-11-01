﻿using System;
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
using MemoryGame.Classes;

namespace MemoryGame.UserControls
{
    /// <summary>
    /// Interaction logic for UserControl_NameInput.xaml
    /// </summary>
    public partial class UserControl_NameInput : UserControl
    {
        public UserControl_NameInput()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Assigns a new ContinueGame usercontrol object to the content.
        /// By: Mark Hooijberg
        /// Updated by: Duncan Dreize
        /// </summary>
        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            Content = new ContinueGame();
        }

        /// <summary>
        /// Start a new game with configuration.
        /// By: Mark Hooijberg
        /// </summary>
        private void Btn_Continue_Click(object sender, RoutedEventArgs e)
        {
            Game game = new Game(new GameConfig()
            {
                FieldHeight = 4,
                FieldWidth = 4,
                PlayerName1 = tbx_player1.Text,
                PlayerName2 = tbx_player2.Text,
                startScore = 100,
                StartPlayer = Game.PlayerTurn.Player1,
                Thema = (string) cbbx_thema.SelectedItem
            });
            Content = new UserControl_GameField(game);
        }
    }
}
