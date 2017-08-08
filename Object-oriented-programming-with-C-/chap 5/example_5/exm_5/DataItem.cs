using System;

namespace example_5
{
    /// <summary>
    /// Items in the ObservableCollection, both getting and setting properties for
    /// fields that are suposed to be shown and modified in the GataGrd are defined
    /// </summary>
    public class DataItem
    {
        private uint x;
        private double y;
        private METERS meter;

        public uint X { get { return x; } set { x = value; } }
        public double Y { get { return Math.Round(y, 2); } set { y = value; } }
        public METERS.NAMES Meter { get { return meter.name; } set { meter.name = value; } }

        public DataItem() { }
        public DataItem(uint x, double y, METERS.NAMES name)
        {
            this.x = x;
            this.y = y;
            meter.name = name;
        }
        public override string ToString()
        {
            return String.Format("x: {0:N0} y: {1:##0.00} {2}", x, y, meter.name);
        }

    }
}
