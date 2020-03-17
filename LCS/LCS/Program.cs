using System;

namespace LCS
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            String string1 = "";
            String string2 = "";

            Console.WriteLine("Enter the first string:");
            string1 = Console.ReadLine();

            Console.WriteLine("Enter the second string:");
            string2 = Console.ReadLine();

            Console.WriteLine("The LCS String is: " + LCS(string1, string2));

            Console.ReadLine();
        }

        public static String LCS(String string1, String string2)
        {
            char[] X = string1.ToCharArray();
            char[] Y = string2.ToCharArray();

            int[,] BTable = new int[X.Length + 1, Y.Length + 1];
            string[,] CTable = new string[X.Length + 1, Y.Length + 1];
            String LCSString = "";

            for (int i = 0; i <= X.Length; i++)
            {
                for (int j = 0; j <= Y.Length; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        BTable[i, j] = 0;
                        CTable[i, j] = "0";
                    }
                    else if ((X[i - 1]) == (Y[j - 1]))
                    {
                        BTable[i, j] = BTable[i - 1, j - 1] + 1;
                        CTable[i, j] = "d";
                    }
                    else if (BTable[i - 1, j] >= BTable[i, j - 1])
                    {
                        BTable[i, j] = BTable[i - 1, j];
                        CTable[i, j] = "\x2191";
                    }
                    else
                    {
                        BTable[i, j] = BTable[i, j - 1];
                        CTable[i, j] = "\x2190";
                    }
                }
            }

            string outB = " ";
            string outC = " ";
            string temps = "    ";
            for (int i = 0; i < Y.Length; i++)
            {
                temps += " " + Y[i] + " ";
            }
            Console.WriteLine(temps);

            for (int i = 0; i <= X.Length; i++)
            {
                if (i != 0)
                {
                    outB += X[i - 1];
                    outC += X[i - 1];
                }

                for (int j = 0; j <= Y.Length; j++)
                {
                    outB += " " + BTable[i, j] + " ";
                    outC += " " + CTable[i, j] + " ";
                }
                outB += "\n";
                outC += "\n";
            }
            Console.WriteLine(outB);
            Console.WriteLine();

            string temp2 = "    ";
            for (int i = 0; i < Y.Length; i++)
            {
                temp2 += " " + Y[i] + " ";
            }
            Console.WriteLine(temp2);

            Console.WriteLine(outC);
            Console.WriteLine();

            int row = X.Length;
            int col = Y.Length;
            String currentElement = CTable[row, col];
            for (int i = 0; i < row; i++)
            {
                if (CTable[i, col] == "d")
                {
                    LCSString += Y[col - 1];
                    break;
                }
            }
            currentElement = CTable[row - 1, col - 1];
            while (currentElement != "0")
            {
                if (CTable[row, col] == "d")
                {
                    LCSString += Y[col - 1];
                    currentElement = CTable[row - 1, col - 1];
                    col--;
                    row--;
                }
                else if (CTable[row, col] == "\x2190")
                {
                    currentElement = CTable[row, col - 1];
                    col--;
                }
                else
                {
                    currentElement = CTable[row - 1, col];
                    row--;
                }
            }

            String flipped = "";
            for (int i = (LCSString.Length - 1); i > 0; i--)
            {
                flipped += LCSString[i];
            }

            return flipped;
        }
    }
}