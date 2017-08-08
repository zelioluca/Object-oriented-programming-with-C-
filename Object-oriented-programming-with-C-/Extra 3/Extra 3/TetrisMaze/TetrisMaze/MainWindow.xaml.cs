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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TetrisMaze
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public  Game game;
        private DispatcherTimer dispatcherTimer;
        private int tickInMillis = 100;

        public MainWindow()
        {
            InitializeComponent();
            game = new Game(canvas); 
        }

        private void Tick_ball(object sender, EventArgs e)
        {
           
            if (dispatcherTimer != null)
            {
                if (game.Draw())
                {
                    dispatcherTimer.Stop();
                    dispatcherTimer = null;
                    game.Next = true;
                    Init();
                }
                CommandManager.InvalidateRequerySuggested();
            }
        }
        private void Init()
        {
            tickInMillis -= 20;

            if (game.Init())
            {
                dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(Tick_ball);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, tickInMillis);
                dispatcherTimer.Start();
            }
        }

       
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
           game.ChangeDirection(e.Key);
        }
        private void canvas_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
        }
    }




}
