using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Threading;

namespace WPF_22._05._2024
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        bool goLeft, goRight, goDown, goUp;
        DispatcherTimer timer = new DispatcherTimer();
        int speed = 10;
        int playerspeed = 10;
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (goLeft == true && Canvas.GetLeft(Black) > 5)
            {
                Canvas.SetLeft(Black, Canvas.GetLeft(Black) - playerspeed);
            }

            if (goRight == true && Canvas.GetLeft(Black) + (Black.Width + 20) < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(Black, Canvas.GetLeft(Black) + playerspeed);
            }

            if (goUp == true && Canvas.GetTop(Black) > 5)
            {
                Canvas.SetTop(Black, Canvas.GetTop(Black) - playerspeed);
            }

            if (goDown == true && Canvas.GetTop(Black) + (Black.Height + 30) < Application.Current.MainWindow.Height)
            {
                Canvas.SetTop(Black, Canvas.GetTop(Black) + playerspeed);
            }
        }

        private void MeinButton1_Click(object sender, RoutedEventArgs e)
        {
            MeinTabControl.SelectedIndex = 1;
        }

        private void MeinButton2_Click(object sender, RoutedEventArgs e)
        {
            MeinGrid2.Background = new SolidColorBrush(Color.FromRgb((byte)random.Next(1, 255), (byte)random.Next(1, 255), (byte)random.Next(1, 255)));
            MeinBorder2.Background = new SolidColorBrush(Color.FromRgb((byte)random.Next(1, 255), (byte)random.Next(1, 255), (byte)random.Next(1, 255)));
            MeinBorder2.BorderBrush = new SolidColorBrush(Color.FromRgb((byte)random.Next(1, 255), (byte)random.Next(1, 255), (byte)random.Next(1, 255)));
        }

        private void MeinRectangle3_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.OriginalSource is Rectangle)
            {
                MeinRectangle3.Fill = new SolidColorBrush(Color.FromRgb((byte)random.Next(1, 255), (byte)random.Next(1, 255), (byte)random.Next(1, 255)));
                MeinRectangle3.Stroke = new SolidColorBrush(Color.FromRgb((byte)random.Next(1, 255), (byte)random.Next(1, 255), (byte)random.Next(1, 255)));
                MeinLabel3.Visibility = Visibility.Visible;
            }

            else
            {
                MeinLabel3.Visibility= Visibility.Hidden;
            }
        }

        private void MeinRectangle3_MouseEnter(object sender, MouseEventArgs e)
        {
            MeinRectangle3.Fill = new SolidColorBrush(Color.FromRgb((byte)random.Next(1, 255), (byte)random.Next(1, 255), (byte)random.Next(1, 255)));
            MeinRectangle3.Stroke = new SolidColorBrush(Color.FromRgb((byte)random.Next(1, 255), (byte)random.Next(1, 255), (byte)random.Next(1, 255)));
            MeinLabel3.Visibility = Visibility.Visible;
        }

        private void MeinRectangle3_MouseLeave(object sender, MouseEventArgs e)
        {
            MeinRectangle3.Fill = Brushes.BlueViolet;
            MeinRectangle3.Stroke = Brushes.Black;
            MeinLabel3.Visibility = Visibility.Hidden;

        }

        private void MeinCanvas4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                goLeft = false;
            }

            if (e.Key == Key.Right)
            {
                goRight = false;
            }

            if (e.Key == Key.Down)
            {
                goDown = false;

            }

            if (e.Key == Key.Up)
            {
                goUp = false;
            }
        }

        private void MeinCanvas4_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Left)
            {
                goLeft = true;
            }

            if(e.Key == Key.Right)
            {
                goRight = true;
            }

            if(e.Key == Key.Down)
            {
                goDown = true;
            
            }

            if(e.Key == Key.Up)
            {
                goUp = true;
            }
        }
    }
}
