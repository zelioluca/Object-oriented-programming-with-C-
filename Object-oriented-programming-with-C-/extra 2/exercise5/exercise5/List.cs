using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace exercise5
{
    class List: Data
    {
        public uint x;
        public double y;
        public string meter;

        public uint X { get { return x; } set { x = value; } }
        public double Y {get { return Math.Round(y, 2); } set { y = value; } }
        public string Meter { get { return meter; } set { meter = value; } }

       // public MainWindow window { get; set; }

        //public List() { }

        public List(uint x, double y, string meter)
        {
            this.x = x;
            this.y = y;
            this.meter = meter; 
        }

        //List<List> MasterList = new List<List> { };

        public override string ToString()
        {
            return String.Format("x: {0:N0} y: {1:##0.00} {2}", x, y, meter);
        }

        
    }
}
