using System.Diagnostics.SymbolStore;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pract1WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Button> buttons;
        List<Button> buttons_copy;
        Random random = new Random();
        string player_symbol = "X";
        string bot_symbol = "O";
        int Victories;
        int Loss;
        int Draws;

        public MainWindow()
        {
            InitializeComponent();
            buttons = new List<Button> { Button_1, Button_2, Button_3, Button_4, Button_5, Button_6, Button_7, Button_8, Button_9 };
            buttons_copy = new List<Button> { Button_1, Button_2, Button_3, Button_4, Button_5, Button_6, Button_7, Button_8, Button_9 };
        }

        private void Game_Button_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = true;
            (sender as Button).Content = player_symbol;
            ((Button)sender).IsEnabled = false;
            
            
            Button pressed_button = (sender as Button);
            buttons_copy.Remove(pressed_button);
            try
            {
                int knopka = random.Next(buttons_copy.Count);
                buttons_copy[knopka].Content = bot_symbol;
                buttons_copy[knopka].IsEnabled = false;

                pressed_button = buttons_copy[knopka];
                buttons_copy.Remove(pressed_button);
            }
            catch 
            {
            }
            if (Check_Result(player_symbol) == "Victory")
            {
                TextBox_1.Text = "Victory!";
                Victories++;
                Text1.Text = Victories.ToString();
                block_buttons();
            }
            else if (Check_Result(bot_symbol) == "Victory")
            {
                TextBox_1.Text = "Loss!";
                Loss++;
                Text3.Text = Loss.ToString();
                block_buttons();
            }
            else if (Check_Result(bot_symbol) == "Ничья" && Check_Result(player_symbol) == "Ничья")
            {
                TextBox_1.Text = "Draw...";
                Draws++;
                Text2.Text = Draws.ToString();
                block_buttons();
            }
        }
        
        private string Check_Result(string symbol)
        {
            if (buttons[0].Content == symbol && buttons[1].Content == symbol && buttons[2].Content == symbol)
            {
                return "Victory";
            }
            else if (buttons[3].Content == symbol && buttons[4].Content == symbol && buttons[5].Content == symbol) 
            {
                return "Victory";
            }
            else if (buttons[6].Content == symbol && buttons[7].Content == symbol && buttons[8].Content == symbol)
            {
                return "Victory";
            }
            else if (buttons[0].Content == symbol && buttons[3].Content == symbol && buttons[6].Content == symbol)
            {
                return "Victory";
            }
            else if (buttons[1].Content == symbol && buttons[4].Content == symbol && buttons[7].Content == symbol)
            {
                return "Victory";
            }
            else if (buttons[2].Content == symbol && buttons[5].Content == symbol && buttons[8].Content == symbol)
            {
                return "Victory";
            }
            else if (buttons[0].Content == symbol && buttons[4].Content == symbol && buttons[8].Content == symbol)
            {
                return "Victory";
            }
            else if (buttons[2].Content == symbol && buttons[4].Content == symbol && buttons[6].Content == symbol)
            {
                return "Victory";
            }
            else
            {
                if (buttons_copy.Count == 0)
                {
                    return "Ничья";
                }
                else
                {
                    return "";
                }
            }
        }
        private void block_buttons()
        {
            foreach (Button i in buttons)
            {
                i.IsEnabled = false;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBox_1.Text = "=Your result=";
            foreach (var button in buttons)
            {
                button.IsEnabled = true;
                button.Content = "";
            }
            buttons_copy.Clear();
            foreach (var button in buttons)
            {
                buttons_copy.Add(button);
            }
            if (player_symbol == "X" && bot_symbol == "O")
            {
                bot_symbol = "X";
                player_symbol = "O";
            }
            else
            {
                bot_symbol = "O";
                player_symbol = "X";
            }
        }
    }
}