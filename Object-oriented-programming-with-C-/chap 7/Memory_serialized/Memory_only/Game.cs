using System;
using System.Collections.Generic;

namespace Memory_only
{
    [Serializable]
    public abstract class Game : IControl
    {
        protected int places;
        public int Places { get { return places; } set { places = value; } }
        //logic places*places table holding playmarks
        protected char[,] content;

        //state of game
        protected int moves;

        public int Moves
        {
            set { moves = value; }
            get { return moves; }
        }
        /// <summary>
        /// resets the logical board by setting to value to be empty mark
        /// </summary>
        public virtual void Reset()
        {
            for (int i = 0; i < places; i++)
                for (int j = 0; j < places; j++)
                {
                    content[i, j] = Markers.Empty; //empty
                }
            moves = 0;
        }

        /// <summary>
        /// places marks to the logical board
        /// </summary>
        public virtual void Set() { }
    }
}

