namespace example_5
{
    public struct METERS
    {
        public enum NAMES { CENTER, RUISSALO, AIRPORT, OTHER};
        public NAMES name;
        public Markers mark;
        METERS(NAMES name, Markers mark)
        {
            this.name = name;
            this.mark = mark;
        }
    }
}
