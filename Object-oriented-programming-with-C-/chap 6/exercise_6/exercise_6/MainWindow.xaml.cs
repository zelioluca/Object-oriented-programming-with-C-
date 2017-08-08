using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace exercise_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Drawer drawer;
        private DispatcherTimer dispatcherTimer;
        private int tickInMillis = 100; //thread operation interval, should be smaller when  maze level is higher
        public MainWindow()
        {
            InitializeComponent();
            drawer = new Drawer(canvas);
        }

        /// <summary>
        /// draws the ball until the Door is hit
        /// </summary>
        private void Tick_ball(object sender, EventArgs e)
        {
            //  System.Windows.Threading.DispatcherTimer.Tick handler
            //  Updates the 
            //  InvalidateRequerySuggested on the CommandManager to force 
            //  the Command to raise the CanExecuteChanged event.
            if (dispatcherTimer != null)
            {
                if (drawer.Draw())
                {
                    dispatcherTimer.Stop();
                    dispatcherTimer = null;
                    drawer.next = true;
                    Init();
                }
                CommandManager.InvalidateRequerySuggested();
            }
        }

        /// <summary>
        /// after canvas is loaded the game is initialized
        /// </summary>
        private void canvas_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
        }

        /// <summary>
        /// initializes timer and starts it
        /// </summary>
        private void Init()
        {
            tickInMillis -= 20;

            if (drawer.Init())
            {
                dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(Tick_ball);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, tickInMillis);
                dispatcherTimer.Start();
            }
        }

        /// <summary>
        /// passes the key press event to drawer
        /// </summary>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            drawer.ChangeDirection(e.Key);
        }
    }
}
