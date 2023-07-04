using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;

namespace QuestGame
{
    internal class Game
    {
        int money;
        float healthy, happy;
        State state;
        QuestData data;
        MainWindow window;

        int messageIndent;
        public Game(MainWindow window)
        {
            this.window = window;
            string json = File.ReadAllText("QuestData.json");

            // Десериализация JSON данных в объекты C#
            data = JsonConvert.DeserializeObject<QuestData>(json);
            money = 1500;
            healthy = 50;
            happy = 50;

            changeVisualStats();

            messageIndent = 0;
            SetState(data.states[0]);
        }

        void changeVisualStats()
        {
            window.Money.Content = Convert.ToString(money);
            window.Health.Width = healthy / 100 * 70;
            window.Happy.Width = happy / 100 * 70;
        }

        void SetState(State state)
        {
            this.state = state;
            GetMessage(state.text);
            CreateChoicesBottoms();
        }

        void CreateChoicesBottoms()
        {
            int index = 0;
            int buttonIndent = 0;
            foreach (var choise in this.state.choices)
            {
                // Создание элемента TextBox
                TextBlock textBox = new TextBlock();
                textBox.Text = choise.text;
                textBox.Foreground = getColorFromHex("#ffffff");
                textBox.HorizontalAlignment = HorizontalAlignment.Center;
                textBox.VerticalAlignment = VerticalAlignment.Center;
                textBox.TextWrapping = TextWrapping.Wrap;
                textBox.MaxWidth = 400;

                // Измерение размера текста
                textBox.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                Size textSize = textBox.DesiredSize;

                Border border = new Border();
                border.CornerRadius = new CornerRadius(3); // Установите половину значения Width или Height для создания круглой формы
                border.BorderBrush = getColorFromHex("#2f6ea5"); // Цвет границы
                border.VerticalAlignment = VerticalAlignment.Top;
                border.BorderThickness = new Thickness(2);

                border.Width = 440; // Добавьте отступы или нужные размеры
                border.Height = textSize.Height + 10; // Добавьте отступы или нужные размеры
                border.Margin = new Thickness(0, messageIndent, 0, 0);

                border.MouseEnter += (sender, e) =>
                {
                    ((Border)sender).Background = getColorFromHex("#2f6ea5");
                };

                border.MouseLeave += (sender, e) =>
                {
                    ((Border)sender).Background = null;
                };

                // Добавление кнопки внутри рамки
                border.Child = textBox;

                border.HorizontalAlignment = HorizontalAlignment.Center;

                border.MouseLeftButtonDown += (sender, e) =>
                {
                    window.ChatInput.Children.Clear();
                    SendMessage(choise.text);
                    try
                    {
                        money += choise.effects.money;
                        healthy += choise.effects.health;
                        happy += choise.effects.happiness;

                        if (healthy < 0 || happy < 0)
                        {
                            if (healthy < 0)
                                healthy = 0;
                            if (happy < 0)
                                happy = 0;
                            GetMessage("Вы не выдерживаете все эти муки и уходите в мир иной!");
                            window.Main.Children.Remove(window.ChatInputBackground);
                        } else
                        {
                            SetState(data.states[choise.nextState - 1]);
                        }
                        changeVisualStats();
                    }
                    catch (Exception ex)
                    {
                        window.Main.Children.Remove(window.ChatInputBackground);
                    }
                };

                border.Margin = new Thickness(0, buttonIndent, 0, 0);
                window.ChatInput.Children.Add(border);

                index += 1;
                buttonIndent += (int)border.Height + 10;
                
            }
        }

        private Brush getColorFromHex(string hex) => (Brush)(new BrushConverter().ConvertFrom(hex));

        private Border createBorder(string hexColor, string text, HorizontalAlignment horizontal)
        {
            Border border = new Border();
            border.Background = getColorFromHex(hexColor);
            border.VerticalAlignment = VerticalAlignment.Top;
            border.HorizontalAlignment = horizontal;
            border.BorderThickness = new Thickness(1); // Толщина границы
            border.BorderBrush = getColorFromHex(hexColor); // Цвет границы
            border.CornerRadius = new CornerRadius(3); // Округление углов


            // Создание элемента TextBox
            TextBlock textBox = new TextBlock();
            textBox.Text = text;
            textBox.Foreground = getColorFromHex("#ffffff");
            textBox.HorizontalAlignment = HorizontalAlignment.Center;
            textBox.VerticalAlignment = VerticalAlignment.Center;
            textBox.TextWrapping = TextWrapping.Wrap;
            textBox.MaxWidth = 200;

            // Добавление TextBox в Border
            border.Child = textBox;

            // Измерение размера текста
            textBox.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            Size textSize = textBox.DesiredSize;

            // Установка размеров Border на основе размера текста
            border.Width = textSize.Width + 10; // Добавьте отступы или нужные размеры
            border.Height = textSize.Height + 10; // Добавьте отступы или нужные размеры
            border.Margin = new Thickness(0, messageIndent, 0, 0);
            return border;
        }

        private void GetMessage(string text)
        {
            Border border = createBorder("#182533", text, HorizontalAlignment.Left);
            messageIndent += (int)border.Height + 10;
            window.ChatHistory.Children.Add(border);
        }

        private void SendMessage(string Message)
        {
            Border border = createBorder("#2b5278", Message, HorizontalAlignment.Right);
            messageIndent += (int)border.Height + 10;
            window.ChatHistory.Children.Add(border);
        }
    }
}
