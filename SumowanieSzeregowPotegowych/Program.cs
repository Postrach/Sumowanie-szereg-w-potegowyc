using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumowanieSzeregowPotegowych
{
    class Program
    {
        #region auxiliary functions
        
        public static double silnia(double x)
        {
            if (x == 1.0)
            {
                return 1.0;
            }
            else
            {
                return x * silnia(x - 1.0);
            }
        }

        public static double Power(double x, double n) {
            //returns x to the power of n
            double w = 1.0;
            for (int i = 0; i < n; i++)
            {
                w *= x;
            }

            return w;
        }

        public static double Cosinus(double x)
        {
            int precision = 10;
            double result = 1.0;
            for (int i = 1; i <= precision; i++)
            {
                if (i % 2 == 1)
                {
                    result -= Power(x, (double)i * 2.0) / (silnia((double)i * 2.0));
                }
                else
                {
                    result += Power(x, (double)i * 2.0) / (silnia((double)i * 2.0));
                }
            }
            return result;
        }

        public static double Log10(double n) {
            int precision = 20;
            double result = 0.0;
            double topPart = 1;

            result += (((topPart) / (Power(n, (double)1))) / (silnia((double)1)) * (Power(n - 1.0, (double)1)));
            for (int i = 2; i < precision; i++)
            {
                if (i % 2 == 1) {
                    result += (((topPart) * ((double)i - 1) / (Power(n,(double)i))) / (silnia((double)i)) * (Power(n - 1.0, (double)i)));
                    topPart = (topPart) * ((double)i - 1);
                }
                else {
                    result += (((-topPart*((double)i-1)) / (Power(n, (double)i))) / (silnia((double)i)) * (Power(n - 1.0, (double)i)));
                    topPart = -topPart * ((double)i - 1);
                }

                
            }

            return result;
        }

        public static double Log_OnePlusX(double x) {
            double w = x;
            int precision = 30;

            for (int i = 2; i < precision; i++)
            {
                if (i % 2 == 1)
                {
                    w += Power(x, 2.0) / (double)i;
                }
                else
                {
                    w -= Power(x, 2.0) / (double)i;
                }
            }

            return w;
        }

        #endregion

        #region main functions

        public static double TaylorWithAddingFromTheBeginning( int n, double x = 0)
        {
            return x;
        }

        public static void TaylorWithAddingFromTheEnd()
        {

        }

        public static void CreateNextFromPreviousWithAddingFromTheBeginning()
        {

        }

        public static void CreateNextFromPreviousWithAddingFromTheEnd()
        {

        }

        public static double BuiltInFunctions(double x = 0) {
            return Math.Cos(x) * Math.Log(1.0 + x);
        }

        #endregion

        static void Main(string[] args)
        {
            #region variables
            int counter = 0;

            //to get 1e6 arguments you need to have: range = 0.8 and step = 0.0000016
            double range = 0.8; //from -range to range                       
            double step = 0.0000016; //step by which argument is incremented                   

            double averageError = 0.0;
            double highestError = 0.0;
            double smallestError = 1000000.0;
            #endregion

            for (double i = -range; i < range; )
            {
                Console.WriteLine("Current argument: "+ i);
                double output = ((Cosinus(i) * Log_OnePlusX(i)) - BuiltInFunctions(i)) / BuiltInFunctions(i);
                //Console.WriteLine("Bład względny wynosi: " + output );
                if (averageError < 0)
                {
                    averageError *= -1;
                }
                if (smallestError < 0)
                {
                    smallestError *= -1;
                }
                if (highestError < 0)
                {
                    highestError *= -1;
                }
                averageError += output;
                if (output < smallestError) {
                    smallestError = output;
                }

                if (output > highestError) {
                    highestError = output;
                }
                i += step;
                counter++;
            }

            Console.WriteLine("Amount of arguments: " + counter);
            
            Console.WriteLine("Average error: " + averageError/1000000.0);
            Console.WriteLine("Smalles error: " + smallestError);
            Console.WriteLine("Highest error: " + highestError);
            /*
            for (double i = -0.8; i < 0.8; )
            {
                Console.WriteLine("---------------------------------------\ni:{0}\n Mine Cos: \t{1}\n Builtin Cos: \t{2}\n\n Mine Log: \t{3}\n Builtin Log:\t{4}\n\n Mine sum:\t{5}\n Builtin sum:\t{6}", i, Cosinus(i), Math.Cos(i), Log_OnePlusX(i), Math.Log(1.0 + i), (Cosinus(i) * Log_OnePlusX(i)), BuiltInFunctions(i));
                
                i += 0.2;
            }
            //Console.WriteLine(Math.Log(1.0 + 0.5) + "\n" + Log_OnePlusX(0.5));
            */
            Console.ReadKey();
        }


    }
}
