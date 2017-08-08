using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace pelitkirijasto
{
   public class MemoryGame:BoardGame
    {
        //new protected Canvas[] places;
        //ref to canvas
        new protected Canvas[] places;
        //Canvas[] canvasses;
        //contains references to Canvases in UI to shorten the code
        //Canvas[] canvases;
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

        public MemoryGame() //what is this?
        { }

        public MemoryGame(UserControl gameboard)
        {
            this.board = (MemoryBoard)gameboard; 
        }
        public void NewGame(int slots = 4*4)
        {
            this.slots = slots;
            pairs = slots / 2;
            board.Init();
            board.result.Text = "";
            Init();
            Suffle();
        }
       new  public void Init()
        {
            places = new Canvas[slots];
            board.grid.Children.CopyTo(places, 0);
            content = new string[slots];
            for (int i = 0, j = 0; i < slots; i++, j++)
            {
                if (j == slots / 2) j = 0;
                content[i] = imagepath + j.ToString() + imageending;
            }
            pairs = slots / 2;
            turned = 0;
        }
        public void Empty(Canvas canvas)
        {
            AddImage(canvas, 100);
        }

        public void Suffle()
        {
            Random rnd = new Random();
            for(int i=0; i <slots/2; i++)
            {
                string help = content[i];
                int helpindex = rnd.Next(slots / 2, slots);
                content[i] = content[helpindex];
                content[helpindex] = help; 
            }
        }
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
                MessageBox.Show(e.Message, "Check the location and name of " + imagepath + "folder");
            }
        }

        public bool Pelaa(object sender)
        {
            bool end = false;

            Canvas canvas = (Canvas)sender;

            if(!IsPair && first != null && second !=null)
            {
                Empty(first);
                Empty(second);
                first.IsEnabled = true;
                second.IsEnabled = true;
                first = second = null;
            }
            else if (IsPair && first !=null && second != null)
            {
                first = second = null;
                IsPair = false; 
            }
            AddImage(canvas, board.grid.Children.IndexOf(canvas));
            turned++;
            board.result.Text = String.Format("tries{0}, pairs left {1}", turned, pairs); 
            if(first == null)
            {
                first = canvas;
                first.IsEnabled = false; 
            }
            else if (second == null)
            {
                try
                {
                    second = canvas;
                    second.IsEnabled = false; 
                    if(content[board.grid.Children.IndexOf(first)] == content[board.grid.Children.IndexOf(second)])
                    {
                        --pairs;
                        board.result.Text = String.Format("tries {0}, pairs left {1}", turned, pairs);
                        IsPair = true;
                        IsReady = true; 

                        foreach(var v in places)
                        {
                            if (((Canvas)v).IsEnabled)
                                IsReady = false; 
                        }
                        if(IsReady)
                        {
                            board.result.Text = String.Format("tries {0}, pairs left {1}", turned, pairs);

                            MessageBox.Show("Well done!", "Board Games", MessageBoxButton.OK);

                            NewGame();
                            //if (MessageBox.Show("New game?", "Well done", MessageBoxButton.YesNo)== MessageBoxResult.Yes)
                            //{
                            //    NewGame();
                            //}
                            //else
                            //{
                            //    end = true; 
                            //}
                        }
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Slow down please", "UUPS not so fast");
                }
            }
            return end; 
        }
        public void Show()
        {
            int index = 0; 
            foreach(var v in places)
            {
                AddImage((Canvas)v, index++);
            }
        }
      }
}
