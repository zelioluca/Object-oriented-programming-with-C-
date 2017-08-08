using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise5
{
    class Data
    {
        public struct METERS
        {
            public enum NAMES { Italy, Bulgaria, Korea, Other }
            public NAMES name;
            public Coordinate2DDrawer.Markers mark;
            METERS(NAMES name, Coordinate2DDrawer.Markers mark)
            {
                this.name = name;
                this.mark = mark; 
            }

        }
        private string x;       
        public string y;
        public  string meter;
        public MainWindow window { get; set; }

        public List<string[]> textForGrid { get; set; }

        public string X { get { return x; } set { x = value; } }

        public string Y { get { return  y; } set { y = value; } }

        public string  Meter { get { return meter; } set { meter = value; } }



        public Data(string Col1, string Col2, string Col3)
        {
            X = Col1;
            Y = Col2;
        Meter = Col3;
            
        }
        public Data() { }
       
        //public Data(uint x, double y, METERS.NAMES name)
        //{
        //    this.x = x;
        //    this.y = y;
        //    meter.name = name;
            
        //}
        //public override string ToString()
        //{
        //    return String.Format("x: {0:N0} y: {1:##0.00} {2}", x, y, meter.name);
        //}

    }
}
