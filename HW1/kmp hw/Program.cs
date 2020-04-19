using System;

namespace kmp_hw
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string: ");
            String string1 = Console.ReadLine();
            Console.Write("Enter a pattern: ");
            String string2 = Console.ReadLine();
            StringMatcher(string1, string2);
            Console.ReadLine();
        }

        public static int[] ComputePrefix(string P)
        {
            // length of the previous longest prefix suffix 
            int M = P.Length;
            int[] pi = new int[M];
            int len = 0;
            int i = 1;
            pi[0] = 0; // lps[0] is always 0 

            // the loop calculates lps[i] for i = 1 to M-1 
            while (i < M)
            {
                if (P[i] == P[len])
                {
                    len++;
                    pi[i] = len;
                    i++;
                }
                else // (pat[i] != pat[len]) 
                {
                    // This is tricky. Consider the example. 
                    // AAACAAAA and i = 7. The idea is similar 
                    // to search step. 
                    if (len != 0)
                    {
                        len = pi[len - 1];

                        // Also, note that we do not increment 
                        // i here 
                    }
                    else // if (len == 0) 
                    {
                        pi[i] = len;
                        i++;
                    }
                }
            }
            return pi;
        }

        public static void StringMatcher(string T, string P)
        {
            int n = T.Length;
            int m = P.Length;
            int[] pi = ComputePrefix(P);
            int q = 0;
            int i = 0; // index for txt[] 

            while (i < n)
            {
                if (P[q] == T[i])
                {
                    q++;
                    i++;
                }
                if (q == m)
                {
                    Console.WriteLine("Pattern found starting at shift " + (i - q));
                    q = pi[q - 1];
                }

                // mismatch after j matches 
                else if (i < n && P[q] != T[i])
                {
                    // Do not match lps[0..lps[j-1]] characters, 
                    // they will match anyway 
                    if (q != 0)
                        q = pi[q - 1];
                    else
                        i = i + 1;
                }
            }
        }
    }
}
