using System;
using System.Collections.Generic;

namespace Memory_only
{
    [Serializable]
    class MemoryGame : Game
    {
         /// <summary>
        /// state of game, how many pairs are left to be turned
        /// </summary>
        private int pairs;
        /// <summary>
        /// state of the game, which pairs are found (for deserialization)
        /// </summary>
        private Dictionary<int, int> found = new Dictionary<int, int>();
        /// <summary>
        /// to suffle the content table
        /// </summary>
        Random rnd = new Random();

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="amount">amount of places</param>
        public MemoryGame(int amount)
        {
            this.places = amount;
            content = new char[amount, amount];
        }

        /// <summary>
        /// returns the content of given element
        /// </summary>
        /// <param name="index">index of element in the content table</param>
        /// <returns></returns>
        public char Content(int index)
        {
            moves++;
            return content[index / places, index % places];
        }

        /// <summary>
        /// finds already found pairs in the found dictionary (for deserialization)
        /// </summary>
        /// <param name="index">the key index</param>
        /// <param name="first">the pair's content </param>
        /// <returns>content of the second value in the pair</returns>
        public char Found(int index, out int pair)
        {
            char first = Markers.Empty;
            pair = -1;
            if (found.TryGetValue(index, out pair))
            {
                first = content[index / places, index % places];
            }
            return first;
        }

        /// <summary>
        /// resets the logical board by setting to value to be empty mark
        /// empties moves and pairs
        /// </summary>
        public override void Reset()
        {

            for (int i = 0; i < places; i++)
                for (int j = 0; j < places; j++)
                {
                    content[i, j] = Markers.Empty; //empty
                }
            moves = 0;
            pairs = places * places / 2;
            Init();
            Suffle();
        }

        /// <summary>
        /// creates the logical content board and fills it
        /// </summary>
        private void Init()
        {
            //fills half of the contnet table first and then the latter half with the same chars
            content = new char[places, places];
            for (int i = 0, j = 0; i < places * places; i++, j++)
                {
                    if (i == places * places / 2)
                        j = 0; 
                content[i / places, i % places] = Markers.Selection[j];
            }
            moves = 0;
        }

        /// <summary>
        /// suffles the content, takes the first half and randomly picks a place in the later half and 
        /// swatps the content
        /// </summary>
        private void Suffle()
        {
            for (int i = 0; i < places; i++)
                for (int j = 0; j < places; j++)
                {
                char apu = content[i,j];
                int apuindex = rnd.Next(places / 2, places);
                content[i,j] = content[apuindex / places, apuindex % places];
                content[apuindex / places, apuindex % places] = apu;
            }
        }

        /// <summary>
        /// checks if the given elements in content are the same
        /// and add them to found Dictionary
        /// </summary>
        /// <param name="i">first element</param>
        /// <param name="j">second element</param>
        /// <returns></returns>
        public bool isPair(int i, int j)
        {
            bool result = false;
            if (content[i / places, i % places].Equals(content[j / places, j % places]))
            {
                result = true;
                --pairs;
                found.Add(i, j);
            }
            return result;
        }

        /// <summary>
        ///  returns the statistics 
        /// </summary>
        /// <returns></returns>
        public string Statistics()
        {
            return String.Format("moves {0}, pairs left {1}", moves, pairs);
        }
    }
}
