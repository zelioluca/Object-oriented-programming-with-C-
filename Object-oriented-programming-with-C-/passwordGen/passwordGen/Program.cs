using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordGen
{

    class Sorting
    {
        string[] LowerArr = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "z" };
        string[] SpecialArr = new string[] { "!", "#", "%", "/", "*", "+", "-", "@", "£", "$", "|", "-", "_" };
        string[] NumberArr = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string[] UpperArr = new string[24]; 

        public Sorting()
        {
           for(int i=0; i<LowerArr.Length; i++)
            {
                UpperArr[i]= LowerArr[i].ToUpper();

               
            } 
        }

        public void FisherYatesKnuth(string[] stringarr)     //shuffle function
        {
            var random = new Random();                      //I call again the class random 
            int i = stringarr.Length - 1;                   //index

            while (i > 0)
            {
                int s = random.Next(i);
                string temp = stringarr[i];                 //temp place 
                stringarr[i] = stringarr[s];                //swap
                stringarr[s] = temp;                        //swap 
                i--;                                        //i-1                                   
                
            }

        }

       




    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] LowerArr = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "z" };
            string[] SpecialArr = new string[] { "!", "#", "%", "/", "*", "+", "-", "@", "£", "$", "|", "-", "_" };
            string[] NumberArr = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            string[] UpperArr = new string[24];

            Random rnd = new Random();

            Sorting sorting = new Sorting();

            sorting.FisherYatesKnuth(LowerArr);
            sorting.FisherYatesKnuth(SpecialArr);
            sorting.FisherYatesKnuth(NumberArr);
            sorting.FisherYatesKnuth(UpperArr);

            Console.WriteLine("Password generator version 0.1");
            Console.WriteLine("Powered by Luca");

            Console.WriteLine("How many caracter do you want to set as new password:");
            int pass_lenght = Convert.ToInt32(Console.ReadLine());

            string[] Password = new string[pass_lenght];           //here 

            Console.WriteLine("Do you need number?");
            string isNumber = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Do you want special character?");
            string IsSpecial = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Do you want Upper character?");
            string IsUpper = Convert.ToString(Console.ReadLine());

            if (isNumber == "no" && IsSpecial == "no" && IsUpper == "no")
            {
                for (int i = 0; i <  pass_lenght; i++)
                {
                    int r = rnd.Next(i, 20);

                    Password[i] = LowerArr[r];
                }
            }

            if(isNumber == "yes" && IsSpecial == "no" && IsUpper =="no")
            {
                int part = (int)pass_lenght / 2; 

                for(int i=0; i< part; i++)
                {
                    int r = rnd.Next(i, 20); 
                    Password[i] = LowerArr[r];
                }
                for(int i = part; i<= (pass_lenght - part) +1; i++)
                {
                    int r = rnd.Next(i, 10);
                    Password[i] = NumberArr[r]; 
                }
            }
            if(isNumber =="yes" && IsSpecial == "yes" && IsUpper == "no")
            {
                int part = (int)pass_lenght / 3;
                
                for(int i=0; i<= part; i++)
                {
                    int r = rnd.Next(i, 20);
                    Password[i] = LowerArr[r];
                }
                for(int i = part; i<=(pass_lenght - part)+1; i++)
                {
                    int r = rnd.Next(i, 10);
                    Password[i] = NumberArr[r]; 
                }
                for(int i =(part + part); i<= pass_lenght; i++ )
                {
                    int r = rnd.Next(i, 12);
                    Password[i] = NumberArr[r]; 
                }
            }






            

        }
    }
}
