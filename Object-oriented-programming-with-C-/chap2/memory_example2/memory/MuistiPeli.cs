using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace memory
{
    class MemoryGame
    {
        //contains references to Canvases in UI to shorten the code
        Canvas[] canvases;
        //knows the "content" of canvases
        private string[] content;
        //amount of canvases in UI 4x4, 6x6, 8x8, 10X10
        int slots = 4 * 4;
        //content of canvases, unturned or turned
        private string imagepath = @"c:\temp\img\";
        private string imageending = ".png";
        //first turned canvas
        private Canvas first;
        //second turned canvas
        private Canvas second;
        //true, if first and second content is the same 
        private bool IsPair;
        //true, if all pairs are found
        private bool IsReady;
        //counts the amount of turned canvases
        private int turned;
        //amount of pairs not found, in the beginning half of amount of canvases 
        private int pairs;
        //board where the canvases reside
        private MemoryBoard board;

        /// <summary>
        /// default constructor
        /// </summary>
        public MemoryGame()
        { }
        /// <summary>
        /// parameterized constructor to receive reference to board
        /// </summary>
        /// <param name="gameboard"></param>
        public MemoryGame(UserControl gameboard)
        {
            this.board = (MemoryBoard)gameboard;
            
        }
        /// <summary>
        ///start a new game by calling init and resetting relevant fields
        /// </summary>
        public void NewGame(int slots = 4*4)
        {
            this.slots = slots;
            pairs = slots / 2;
            board.Init();
            board.result.Text = "";
            Init();
            Suffle();
        }
        /// <summary>
        ///add images to canvasses
        /// </summary>
        private void Init()
        {
            canvases = new Canvas[slots];
            board.grid.Children.CopyTo(canvases, 0);
            content = new string[slots];
            for (int i = 0, j = 0; i < slots; i++, j++)
            {
                //fill half of the canvases and copy the same to the rest
                if (j == slots / 2) j = 0;
                //add the image to content table into corresponding place
                content[i] = imagepath + j.ToString() + imageending;
            }
            pairs = slots / 2;
            turned = 0;
        }
        /// <summary>
        /// empty, unturned canvas
        /// </summary>
        /// <param name="canvas">canvas with "empty" image</param>
        public void Empty(Canvas canvas)
        {
            AddImage(canvas, 100);
        }
        ///<summary>
        ///suffle the content table by randomly swapping element from 
        ///first half with element from second half
        ///</summary>
        private void Suffle()
        {
            Random rnd = new Random();
            for (int i = 0; i < slots / 2; i++)
            {
                string help = content[i];
                int helpindex = rnd.Next(slots / 2, slots);
                content[i] = content[helpindex];
                content[helpindex] = help;
            }
        }
        /// <summary>
        /// add image to canvas
        /// </summary>
        /// <param name="canvas">canvas to get the image</param>
        /// <param name="i">index of the canvas in container (Children)</param>
        private void AddImage(Canvas canvas, int i)
        {
            try
            {
                ImageBrush b1 = new ImageBrush();
                Uri uri = new Uri((i == 100) ? (imagepath + i.ToString() + imageending) : content[i], UriKind.Absolute);
                ImageSource img = new System.Windows.Media.Imaging.BitmapImage(uri);
                b1.SetValue(ImageBrush.ImageSourceProperty, img);
                b1.Stretch = Stretch.None;
                canvas.Background = b1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Check the location and name of  " + imagepath + " folder");
            }
        }
        /// <summary>
        /// EventHandler dispatched from MemoryBoard
        /// </summary>
        /// <param name="sender">canvas that raised the event</param>
        public bool Pelaa(object sender)
        {            
            bool end = false;
            
            Canvas canvas = (Canvas)sender;

            //if there is two turned that are not a pair
            if (!IsPair && first != null && second != null)
            {
                Empty(first);
                Empty(second);
                first.IsEnabled = true;
                second.IsEnabled = true;
                first = second = null;
            }
            //if there is two turned that are a pair
            else if (IsPair && first != null && second != null)
            {
                first = second = null;
                IsPair = false;
            }
            //turn the canvas and show the content
            AddImage(canvas, board.grid.Children.IndexOf(canvas));
            //update amount of turned canvases
            turned++;
            board.result.Text = String.Format("tries {0}, pairs left {1}", turned, pairs);
            //if the turned canvas is the first
            if (first == null)
            {
                first = canvas;
                first.IsEnabled = false;
            }
            //if the turned canvas is the second
            else if (second == null)
            {
                try
                {
                    second = canvas;
                    second.IsEnabled = false;
                    //if the pair is found
                    if (content[board.grid.Children.IndexOf(first)] == content[board.grid.Children.IndexOf(second)])
                    {
                        //update amount of pairs left and show the situation to the user
                        --pairs;
                        board.result.Text = String.Format("tries {0}, pairs left {1}", turned, pairs);
                        IsPair = true;
                        IsReady = true;
                        //are all canvases turned
                        foreach (var v in canvases)
                        {
                            if (((Canvas)v).IsEnabled)
                                IsReady = false;
                        }
                        //if all are turned 
                        if (IsReady)
                        {
                            board.result.Text = String.Format("tries {0}, pairs left {1}", turned, pairs);
                            //kysytään valitaanko uusi game, ja käyttäjä valitsee uuden
                            if (MessageBox.Show("New game?", "Well done", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                            {
                                NewGame();
                            }
                            //user selected no so close the program
                            else
                            {
                                end = true;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Slow down, please", "UUPS not so fast");
                }
            }
            return end;
        }
        /// <summary>
        /// show the image in the canvas
        /// </summary>
        public void Show()
        {
            int index = 0;
            foreach (var v in canvases)
            {
                  AddImage((Canvas)v, index++);
            }
        }
    }
}
