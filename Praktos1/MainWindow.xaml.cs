using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading;
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

namespace Praktos1
{
    public partial class MainWindow : Window
    {
        int RandomIndex;
        Random random = new Random();
        Button[] Buttons;
        int countDisabled = 0;
        int CountBotWins = 0;
        int CountUserWins = 0;
        int CountDraws = 0;
        bool flag;
        int X_or_0 = 0;
        string UserXili0;
        string BotXili0;

        public MainWindow()
        {
            InitializeComponent();
            Buttons = new Button[9] { B1, B2, B3, B4, B5, B6, B7, B8, B9 };
        }

        public void Botik()
        {
            if (flag == false)
            {
                RandomIndex = random.Next(0, 8);

                while (Buttons[RandomIndex].IsEnabled == false)
                {
                    RandomIndex = random.Next(0, 8);
                }
                if (X_or_0%2 == 0) 
                {
                    Buttons[RandomIndex].IsEnabled = false; Buttons[RandomIndex].Content = "0";
                }
                else if (X_or_0%2 == 1)
                {
                    Buttons[RandomIndex].IsEnabled = false; Buttons[RandomIndex].Content = "X";
                }
            }
            CheckBotWin();
        }
        public void ResetGame()
        {
            foreach(var item in Buttons)
            {
                item.IsEnabled = true; item.Content = "";
            }
            X_or_0 += 1;
        }
        public void CheckUserWin()
        {
            if (X_or_0 % 2 == 0)
            {
                UserXili0 = "X";
            }
            else
            {
                UserXili0 = "0";
            }
            if (B1.Content == UserXili0 && B2.Content == UserXili0 && B3.Content == UserXili0 ||
                B4.Content == UserXili0 && B5.Content == UserXili0 && B6.Content == UserXili0 ||
                B7.Content == UserXili0 && B8.Content == UserXili0 && B9.Content == UserXili0 ||
                B1.Content == UserXili0 && B5.Content == UserXili0 && B9.Content == UserXili0 ||
                B3.Content == UserXili0 && B5.Content == UserXili0 && B7.Content == UserXili0 ||
                B1.Content == UserXili0 && B4.Content == UserXili0 && B7.Content == UserXili0 ||
                B2.Content == UserXili0 && B5.Content == UserXili0 && B8.Content == UserXili0 ||
                B3.Content == UserXili0 && B6.Content == UserXili0 && B9.Content == UserXili0)
            {
                CountUserWins += 1;
                UserWins.Text = "Кол-во ваших побед: " + CountUserWins.ToString();
                MessageBox.Show("Выйграли вы");
                flag = true;
                ResetGame();
            }
        }
        public void CheckBotWin()
        {
            if (X_or_0 % 2 == 0)
            {
                BotXili0 = "0";
            }
            else
            {
                BotXili0 = "X";
            }
            if (B1.Content == BotXili0 && B2.Content == BotXili0 && B3.Content == BotXili0 ||
                B4.Content == BotXili0 && B5.Content == BotXili0 && B6.Content == BotXili0 ||
                B7.Content == BotXili0 && B8.Content == BotXili0 && B9.Content == BotXili0 ||
                B1.Content == BotXili0 && B5.Content == BotXili0 && B9.Content == BotXili0 ||
                B3.Content == BotXili0 && B5.Content == BotXili0 && B7.Content == BotXili0 ||
                B1.Content == BotXili0 && B4.Content == BotXili0 && B7.Content == BotXili0 ||
                B2.Content == BotXili0 && B5.Content == BotXili0 && B8.Content == BotXili0 ||
                B3.Content == BotXili0 && B6.Content == BotXili0 && B9.Content == BotXili0)
            {
                CountBotWins += 1;
                BotWins.Text = "Кол-во побед бота: " + CountBotWins.ToString();
                MessageBox.Show("Выйграл ботик");
                flag = true;
                ResetGame();
            }
        }
        public void CheckDraw()
        {
            foreach (var item in Buttons) 
            {
                if (item.IsEnabled == false)
                {
                    countDisabled += 1;
                }
            }
            if (countDisabled == 9)
            {
                CountDraws += 1;
                Draws.Text = "Кол-во ничьих: " + CountDraws.ToString();
                MessageBox.Show("Ничья");
                flag = true;
                ResetGame();
            }
            else
            {
                countDisabled = 0;
            }
        }
        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            CountUserWins = 0;
            UserWins.Text = "Кол-во ваших побед: " + CountUserWins.ToString();
            CountBotWins = 0;
            BotWins.Text = "Кол-во побед бота: " + CountBotWins.ToString();
            CountDraws = 0;
            Draws.Text = "Кол-во ничьих: " + CountDraws.ToString();
            ResetGame();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            flag = false;
            if (X_or_0 % 2 == 0)
            {
                (sender as Button).IsEnabled = false; (sender as Button).Content = "X";
            }
            else if (X_or_0 % 2 == 1)
            {
                (sender as Button).IsEnabled = false; (sender as Button).Content = "0";
            }
            CheckUserWin();
            CheckDraw();
            Botik();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            start_game.Visibility = Visibility.Hidden;
            foreach(var item in Buttons)
            {
                item.IsEnabled = true;
            }
        }
    }
}
