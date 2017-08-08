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

namespace tetrisMazeVer2._0
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        private Game Game;

        
        private DispatcherTimer dispatcherTimer;
        private int tickInMillis = 100;
        public MainWindow()
        {
            InitializeComponent();
            
            Game = new Game(canvas, a1, a2, a3, b1, b2, b3, c1, c2, c3);
        }
        private void Tick_ball(object sender, EventArgs e)
        {
            if (dispatcherTimer != null)
            {
                if (Game.Draw())
                {
                    dispatcherTimer.Stop();
                    dispatcherTimer = null;
                    Game.next = true;
                    Init();
                }
                CommandManager.InvalidateRequerySuggested();
            }
        }
        private void canvas_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
        }
        private void Init()
        {
            tickInMillis -= 20;

            if (Game.Init())
            {
                dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(Tick_ball);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, tickInMillis);
                dispatcherTimer.Start(); 

            }
        }

       

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Game.ChangeDirection(e.Key); 
        }
    }
}
