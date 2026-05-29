using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        Dictionary<string, string> responses = new Dictionary<string, string>()
        {
            {"Phishing", "Phishing is a type of cyberattack where someone pretends to be a trusted person to trick you into giving up sensitive information"},
            {"Typical warning signs", "Typical warning signs of phishing include: urgent language, requests for OTPs, suspicious links, or misspellings"},
            {"Hello", "Hello there, how may I help you today?"},
            {"Wi-Fi & Internet", "Avoid logging into sensitive accounts using public Wi-Fi. Use a trusted VPN on public networks."},
            {"Home Wi-Fi", "Change default passwords on home routers"},
            {"What is SQL?", "Structured Query Language"}
        };

        private string historyFile = "History/chat_history.txt";

        public MainWindow()
        {
            InitializeComponent();
            PlayGreetings();

            BotMessage("Hello, my name is Cyra, your online cyber security chatbot. How may I help you?");
        }

        private void PlayGreetings()
        {
            try
            {
                string path = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "voice.wav"
                );

                SoundPlayer player = new SoundPlayer(path);

                player.Load();

                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = UserInput.Text.Trim();

            if (string.IsNullOrEmpty(userMessage))
            {
                BotMessage("Please type something to interact with the chatbot.");
                return;
            }

            
            AddUserMessage(userMessage);

            // Save user message
            SaveMessage("USER", userMessage);

            // Check chatbot responses
            bool found = false;

            foreach (var item in responses)
            {
                if (userMessage.ToLower().Contains(item.Key.ToLower()))
                {
                    BotMessage(item.Value);

                    SaveMessage("BOT", item.Value);

                    found = true;
                    break;
                }
            }

            
            if (!found)
            {
                string defaultResponse = "Sorry, I do not understand that yet.";

                BotMessage(defaultResponse);

                SaveMessage("BOT", defaultResponse);
            }

          
            UserInput.Clear();
        }

        
        public void BotMessage(string message)
        {
            StackPanel stack = new StackPanel();

            TextBlock time = new TextBlock()
            {
                Text = DateTime.Now.ToString("HH:mm"),
                Foreground = Brushes.DarkGray,
                FontSize = 11
            };

            Border border = new Border()
            {
                Background = Brushes.DarkGoldenrod,
                CornerRadius = new CornerRadius(12),
                Padding = new Thickness(10),
                Margin = new Thickness(5),
                MaxWidth = 400,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            TextBlock text = new TextBlock()
            {
                Text = "Bot: " + message,
                Foreground = Brushes.White,
                FontSize = 16,
                TextWrapping = TextWrapping.Wrap
            };

            border.Child = text;

            stack.Children.Add(time);
            stack.Children.Add(border);

            ChatPanel.Children.Add(stack);
        }

       
        private void AddUserMessage(string message)
        {
            StackPanel stack = new StackPanel()
            {
                HorizontalAlignment = HorizontalAlignment.Right
            };

            TextBlock time = new TextBlock()
            {
                Text = DateTime.Now.ToString("HH:mm"),
                Foreground = Brushes.LightGray,
                FontSize = 11,
                HorizontalAlignment = HorizontalAlignment.Right
            };

            Border border = new Border()
            {
                Background = Brushes.DarkGray,
                CornerRadius = new CornerRadius(12),
                Padding = new Thickness(10),
                Margin = new Thickness(10),
                MaxWidth = 400,
                HorizontalAlignment = HorizontalAlignment.Right
            };

            TextBlock text = new TextBlock()
            {
                Text = "You: " + message,
                Foreground = Brushes.White,
                FontSize = 16,
                TextWrapping = TextWrapping.Wrap
            };

            border.Child = text;

            stack.Children.Add(time);
            stack.Children.Add(border);

            ChatPanel.Children.Add(stack);
        }

       //saving the chat history
        private void SaveMessage(string user, string message)
        {
            Directory.CreateDirectory("History");

            string line =
                $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{user}] {message}";

            File.AppendAllText(historyFile, line + Environment.NewLine);
        }
    }
}