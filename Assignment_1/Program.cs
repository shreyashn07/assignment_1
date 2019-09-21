using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_1
{
    class MainClass
    {
        static void Main(string[] args)
        {
            int a = 1, b = 22;
            // printSelfDividingNumbers(a, b);

            //int n2 = 7;
            //printSeries(n2);

            //int n3 = 5;
            //printTriangle(n3);

            //int[] J = new int[] { 1, 3 };
            //int[] S = new int[] { 1, 3, 3, 2, 2, 2, 2, 2 };
            //int r4 = numJewelsInStones(J, S);
            //Console.WriteLine(r4);

            //int[] arr1 = new int[] { 1, 2, 5, 6, 7, 8, 9 };
            //int[] arr2 = new int[] { 1, 2, 3, 4, 5 };
            //int[] r5 = getLargestCommonSubArray(arr1, arr2);
            //displayArray(r5);

            solvePuzzle();

        }

        public static void displayArray(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i]);
            }
            Console.Write("\n");
        }
        public static void printSelfDividingNumbers(int x, int y)
        {
            try
            {
                for (int i = x; i <= y; i++)
                {
                    bool var = true;
                    int num = i;
                    //int a[10];
                    while (num > 0)
                    {

                        int q = num % 10;
                        if ((q != 0) && (i % q == 0))
                        { var = true; }
                        else
                        {
                            var = false;
                            break;
                        }
                        num = num / 10;
                        //Console.Write("Self dividing Number {0}",i);



                    }
                    if (var)
                    { Console.WriteLine("Self dividing Number:{0}", i); }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void printSeries(int n)
        {
            try
            {

                for (int i = 0, j = 1; i < n; j++)
                {

                    for (int l = 1; (i < n) && (l <= j); l++)
                    {
                        Console.WriteLine(j);
                        i++;
                    }



                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void printTriangle(int n)
        {
            try
            {
                // Write your code here
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j < i; j++)
                    {
                        Console.Write(" ");
                    }
                    for (int j = 1; j <= ((n * 2) - (2 * i - 1)); j++)
                    {
                        Console.Write("*");
                    }
                    Console.Write("\n");
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }
        }


        public static int numJewelsInStones(int[] J, int[] S)
        {
            try
            {
                int count = 0;
                for (int i = 0; i < S.Length; i++)
                {
                    for (int j = 0; j < J.Length; j++)
                    {
                        if (S[i] == J[j])
                        { count++; }
                    }

                }
                return count;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing numJewelsInStones()");
            }

            return 0;
        }

        public static int[] getLargestCommonSubArray(int[] a, int[] b)
        {
            int result = 0;
            int m = a.Length;
            int n = b.Length;
            int[,] len = new int[2, m];
            int currRow = 0;
            int end = 0;


            try
            {

                for (int i = 0; i <= m; i++)
                {
                    for (int j = 0; j <= n; j++)
                    {
                        if (i == 0 || j == 0)
                        {
                            len[currRow, j] = 0;
                        }
                        else if (a[i - 1] == b[j - 1])
                        {
                            len[currRow, j] = len[1 - currRow, j - 1] + 1;
                            if (len[currRow, j] > result)
                            {
                                result = len[currRow, j];
                                end = i - 1;
                            }
                        }
                        else
                        {
                            len[currRow, j] = 0;
                        }
                    }

                    currRow = 1 - currRow;
                }
                if (result == 0)
                    return null;
                int[] resp = new int[result - (end - result + 1)];

                for (int i = end - result + 1, index = 0; i < result; i++, index++)
                {
                    resp[index] = a[i];

                }
                return resp;


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null; // return the actual array
        }



        public static void solvePuzzle()
        {
            try
            {
                // Write your code here
                Dictionary<char, int> dict = new Dictionary<char, int>();
                Console.WriteLine("Enter the string 1");
                String string1 = Console.ReadLine();
                Console.WriteLine("Enter the String 2");
                String string2 = Console.ReadLine();
                Console.WriteLine("Enter the Result String 3");
                String string3 = Console.ReadLine();
                String fin = String.Concat(string1, string2, string3);
                var unique = new HashSet<char>(fin);
                List<char> unichar = unique.ToList();
                Char[] str1 = string1.ToCharArray();
                Char[] str2 = string2.ToCharArray();
                Char[] str3 = string3.ToCharArray();

                

                int k = unique.Count;
                List<int> myList = new List<int>();
                for (int i = 0; i < 20; i++)
                {
                    myList.Add(i);

                }
                List<int> a = new List<int>();
                for (int j = 0; j < 20; j++)
                {
                    a.Add(myList[j]);
                }
                List<List<int>> result = new List<List<int>>();
                result = choose(a, k);
                foreach (var sublist in result)
                {

                    for (int i = 0; i < sublist.Count; i++)
                    {
                        dict.Add(unichar[i], sublist[i]);
                    }

                    
                    



                    
                    //for (int i =string1.Length-1 ; i >=0; i--)
                    //{
                        findsum(dict, str1, str2, str3);
                    //    dict.TryGetValue(str1[i], out aa);
                    //    dict.TryGetValue(str2[i], out b);
                    //    dict.TryGetValue(str3[i], out c);
                    //    if (aa + b == c)
                    //    {
                    //        flag = true;

                    //    }
                    //    else
                    //    {
                    //        flag = false;
                    //        break;
                    //    }

                    //}
                    //if (flag)
                    //    foreach (var x in sublist)
                    //    { Console.Write("NUmbers are {0}", x); }

                    dict.Clear();
                }



            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void findsum(Dictionary<char,int> dict,Char[] str1,Char[] str2,Char[] str3) {
            int carry = 0, a = 0, b = 0, c = 0,sum=0,comp,index=0;
            bool flag = false;
            index = str3.Length - 1;
            for (int i = str1.Length - 1; i >= 0; i--,index--)
            {
                dict.TryGetValue(str1[i], out a);
                dict.TryGetValue(str2[i], out b);
                dict.TryGetValue(str3[index], out c);
                sum = a + b + carry;
                carry = sum / 10;
                comp = sum % 10;
                
                if (comp == c)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    break;
                }

            }
            if ((str3.Length == str1.Length) && carry > 0)
                flag = false;
            
            if (str3.Length > str2.Length)
            {
                dict.TryGetValue(str3[index], out a);
                if (a != carry)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                foreach (KeyValuePair<Char, int> item in dict)
                {
                    Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
                }
                Console.WriteLine("----------------------------------End of Solution--");
            }


        }
        public static List<List<int>> choose(List<int> a, int k)
        {
            List<List<int>> allPermutations = new List<List<int>>();
            enumerate(a, a.Count, k, allPermutations);




            return allPermutations;
        }

        public static void enumerate(List<int> a, int n, int k, List<List<int>> allPermutations) {

            if (k == 0)
            {
                List<int> singlePermutation = new List<int>();
                for (int i = n; i < a.Count; i++)
                {
                    singlePermutation.Add(a[i]);
                }
                allPermutations.Add(singlePermutation);
                return;
            }
            for (int i = 0; i < n; i++)
            {
                swap(a, i, n - 1);
                enumerate(a, n - 1, k - 1, allPermutations);
                swap(a, i, n - 1);
            }

        }


        public static void swap(List<int> a, int i, int j) {

            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;

        }

    }

}


    
