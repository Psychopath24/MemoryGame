﻿using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for UserControl_EndScreen.xaml
    /// </summary>
    public partial class UserControl_EndScreen : UserControl
    {
        private Game _game;
        public UserControl_EndScreen(Game game)
        {
            InitializeComponent();
            _game = game;
            ShowScore(new string[] { game.Player1.Name, game.Player2.Name});
        }

        private void Btn_Play_Click(object sender, RoutedEventArgs e)
        {
            Content = new UserControl_NameInput();
        }

        private void Btn_MainMenu_Click(object sender, RoutedEventArgs e)
        {
            Content = new UserControl_MainMenu();
        }

        //Writes the winning player's score on a text file so it can be used for showing the Highscores. 
        //Also shows the players at the end who won and with which amount of points.
        //Created by: Duncan Dreize
        private void ShowScore(string[] names)
        {
            if (_game.Player1.Score > _game.Player2.Score)
            {

              
                using (StreamWriter Writer = File.AppendText(@"HighScores.txt"))
                {

                    Writer.Write(names[0] + " ");
                    Writer.Write(_game.Player1.Score);
                    Writer.WriteLine();
                    Writer.Flush();
                }
                lbl_winner_select.Content = names[0] + " has won with " + _game.Player1.Score + " points!";
                lbl_loser_select.Content = names[1] + " has lost with " + _game.Player2.Score + "points!";
            }
            else if (_game.Player1.Score < _game.Player2.Score)
            {
                using (StreamWriter Writer = File.AppendText(@"HighScores.txt"))
                {

                    Writer.Write(names[1] + " ");
                    Writer.Write(_game.Player2.Score);
                    Writer.WriteLine();
                    Writer.Flush();
                }
                lbl_winner_select.Content = names[1] + " has won with " + _game.Player2.Score + " points!";
                lbl_loser_select.Content = names[0] + " has lost with " + _game.Player1.Score + "points!";
            }
            else if (_game.Player1.Score == _game.Player2.Score) 
            {
                lbl_tie_select.Content = names[0] + " and " + names[1] + " have tied with " + _game.Player1.Score + " points!"; 
            }
            else
            {
                lbl_winner_select.Content = "Something went wrong!";
            }
        }
    }
    
    
}
