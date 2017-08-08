using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication1
{
    class Game
    {
        private int counter;
        internal void Play(object sender)
        {
            MessageBox.Show(((Button)sender).Content.ToString(),
                (counter++).ToString());
        }
    }
}
