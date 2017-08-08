using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace exercise5
{
    public class Lista
    {
        protected uint x; //data private    //protected
        protected double y;
        protected string meter;

        public uint X { get { return x; } set { x = value; } }      //property public
        public double Y {get { return Math.Round(y, 2); } set { y = value; } }
        public string Meter { get { return meter; } set { meter = value; } }

       // public MainWindow window { get; set; }

        public Lista() { }

        public Lista(uint x, double y, string meter)
        {
            this.x = x;
            this.y = y;
            this.meter = meter; 
        }

        public override string ToString()
        {
            return String.Format("x: {0:N0} y: {1:##0.00} {2}", x, y, meter);
        }

        
    }
}
