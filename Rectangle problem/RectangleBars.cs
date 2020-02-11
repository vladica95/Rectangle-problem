using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangle_problem
{
    class RectangleBars
    {
        private int[] arrayOfHeights;


        public RectangleBars()
        {
            Console.WriteLine("Enter how many bars exist :");
            int numberOfBars = Int32.Parse(Console.ReadLine());
            ArrayOfHeights = new int[numberOfBars];
            Console.WriteLine("Enter height of bars :");
            for (int i = 0; i < numberOfBars; i++)
            {
                ArrayOfHeights[i] = Int32.Parse(Console.ReadLine());
            }
        }
        public int[] ArrayOfHeights
        {
            get => arrayOfHeights;
            set => arrayOfHeights = value;
        }

        private int Partition(int[] someArray,int lowBoundary, int highBoundary)
        {
            int partElement = someArray[highBoundary];
            int partIndex = (lowBoundary - 1); 
            for (int j = lowBoundary; j < highBoundary; j++)
            {
                if (someArray[j] <= partElement)
                {
                    partIndex++;

                    int temp = someArray[partIndex];
                    someArray[partIndex] = someArray[j];
                    someArray[j] = temp;
                }
            }
            int temp1 = someArray[partIndex + 1];
            someArray[partIndex + 1] = someArray[highBoundary];
            someArray[highBoundary] = temp1;

            return partIndex + 1;
        }

        private void SortArray(int[] someArray, int lowBoundary, int highBoundary)
        {

            if (lowBoundary < highBoundary)
            {
                int partIndex = Partition(someArray, lowBoundary, highBoundary);
                SortArray(someArray,lowBoundary, partIndex - 1);
                SortArray(someArray,partIndex + 1, highBoundary);
            }
        }
        private int[] SimplifiedArray()
        {
            int[] simplifiedArray = new int[ArrayOfHeights.Length];
            Array.Copy(ArrayOfHeights,simplifiedArray , ArrayOfHeights.Length);
            SortArray(simplifiedArray ,0,simplifiedArray .Length-1);
            int[] newArray = new int[simplifiedArray .Length];
            int tempCounter = 1;
            newArray[0] = simplifiedArray [0];
            for (int i = 1; i < simplifiedArray .Length; i++)
            {
                if (simplifiedArray [i] != newArray[tempCounter - 1])
                {
                    newArray[tempCounter] = simplifiedArray [i];
                    tempCounter++;
                }
            }
            int[] newNewArray = new int[tempCounter];
            
            Array.Copy(newArray, newNewArray, tempCounter);
            return newNewArray;
        }

        public int BiggestRectangle()
        {

            int[] simpleArray = SimplifiedArray();
            int biggestOne = 0;


            for (int i = 0; i < simpleArray.Length; i++)
            {
                int compareHeight = simpleArray[i];
                int lineCounter = 0;
                int biggestLine = 0;
                int j = 0;
                
                while (j < ArrayOfHeights.Length)
                {
                    if (compareHeight <= ArrayOfHeights[j])
                    {
                        lineCounter++;
                    }
                    else
                    {
                        if (biggestLine < lineCounter)
                        {
                            biggestLine = lineCounter;
                        }
                        lineCounter = 0;
                    }
                    j++;
                }
                if (biggestLine < lineCounter && j >= ArrayOfHeights.Length)
                {
                    biggestLine = lineCounter;
                }
                int area = compareHeight * biggestLine;
                if (area > biggestOne)
                {
                    biggestOne = area;
                }
            }

            return biggestOne;
        }
    }
}
