using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//Self Reflection: This assignment as a whole helped me in learning collections and applying logic
//to solve simple logical problems, i have included my self reflection with each function
namespace Assignment_1
{
    class MainClass
    {
        static void Main(string[] args)
        {
            int a = 1, b = 22;
            Console.WriteLine("Self Dividing numbers are:");
            printSelfDividingNumbers(a, b);
            Console.WriteLine("\n");

            int n2 = 7;
            Console.WriteLine("Series of number when n:{0}", n2);

            printSeries(n2);
            Console.WriteLine("\n");


            int n3 = 5;
            printTriangle(n3);
            Console.WriteLine("\n");

            int[] J = new int[] { 1, 3 };
            int[] S = new int[] { 1, 3, 3, 2, 2, 2, 2, 2 };
            int r4 = numJewelsInStones(J, S);
            Console.WriteLine("Number of Jewels:");
            Console.WriteLine(r4);
            Console.WriteLine("\n");

            int[] arr1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] arr2 = new int[] { 1, 2, 5, 7, 8, 9, 10 };
            int[] r5 = getLargestCommonSubArray(arr1, arr2);
            Console.Write("arr1: ");
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.Write(arr1[i]);
            }
            Console.Write("\n");
            Console.Write("arr2: ");
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.Write(arr2[i]);
            }
            Console.Write("\n");
            displayArray(r5);

            solvePuzzle();

        }
        //Display function to display array
        public static void displayArray(int[] a)
        {

            Console.WriteLine("Common Sub-Array of array 1 and array 2");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i]);
            }
            Console.Write("\n");
        }
        //Logic:Take the range
        //2.for each number ,run the modulo 10 to fetch the last digit of the number
        //3.Divide the number by obtained by modulo 10 operation,if it gets divided ,contiue by diving the number by 10 and passing it on for next iteration
        //4.if it doesnt divide, break the loop and proceed for the next number
        //5.print the number if it was divided with zero reminder with all its constituents
        //Self Reflection: It helped me to learn more about modulo operation
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
                        //modulus of a number gives the reminder and modulus of smaller number and bigger number is always a smaller number
                        int q = num % 10;
                        if ((q != 0) && (i % q == 0))
                        { var = true; }
                        else
                        {
                            var = false;
                            //Break the loop , if the number is not self dividing , go for the next number
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

        //Logic:i is used as the counter , j is used an content to print and l is used as counter to print the numbers
        //Self Reflection:It helped me learn more about nested loops
        public static void printSeries(int n)
        {
            try
            {
                //
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
        //Logic:// we need to print less stars each time when loop repeates ,the number of stars should decrement in
        //order of 2,4 and goes on
        //Self Reflection: This helped me to learn the logic of printing patterns, now i have huge space to explore.
        public static void printTriangle(int n)
        {
            try
            {
                
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

        //Logic: Compare each element with the element in the outer loop, return the result if they are equal.
        //Self Reflection : I learnt about the comparision of one element with other
        public static int numJewelsInStones(int[] J, int[] S)
        {
            try
            {
                int count = 0;
                for (int i = 0; i < S.Length; i++)
                {
                    for (int j = 0; j < J.Length; j++)
                    {
                        //if the stone is equal , increase the count and return it end of the loop
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
            //This is dynamic programming approach where the results from the previous computation is saved for
            //the future use, we can do this program by declaring 2d array , whenver there is a character match , we
            //put a number in that index using the below formula
            //if(input1==input2)
            //mat[i][j]=mat[i-1][j-1]+1
            //The previous elements in the diagonal contains the length of the common substring until the last character
            //i found more optmized solution in the below link, i used this as an reference
            //https://www.geeksforgeeks.org/print-longest-common-substring/
            //I have modifed the solution according to our needs handling all corner case (if arrays of same lenght is found ,
            //return the last array)
            //Self Reflection: This helped me to learn about optimization techniques and dynamic programming
            //and space complexity

        
        public static int[] getLargestCommonSubArray(int[] a, int[] b)
        {
            int result = 0;
            int m = a.Length;
            int n = b.Length;
            

            int[,] len = new int[2, n+m];
            int currRow = 0;
            //We will store the end index of the common substring in a variable which will help us easy traversal in future
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
                            //When we find a common character , we take the lenght of the previous subarray from the
                            //other row, we can use 1 d array also, then we need to traverse from right to left
                            len[currRow, j] = len[1 - currRow, j - 1] + 1;
                            //We need >= to handle the corner case of handling common sub arrays of equal lenght
                            if (len[currRow, j] >= result)
                            {
                                //if the lenght of the subarray is bigger than the previously found, we store the result and
                                //we change the end pointer position
                                result = len[currRow, j];
                                end = i - 1;
                            }
                        }
                        else
                        {
                            
                            len[currRow, j] = 0;
                        }
                    }
                    //Alternating between two rows since we are comparing two rows
    
                    currRow = 1 - currRow;
                }
                if (result == 0)
                    return null;
                //Response should be as big as the result
                int[] resp = new int[result];
                //to print the common sub array , we will start the loop from i =end pointer minus the maxlength which gives
                //us the starting index in the array.
                for (int i = end - result + 1, index = 0; index < result; i++, index++)
                {
                    resp[index] = a[i];

                }
                return resp;


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
            
        }


        // Algorithm
        //1.Get unique chracters from the string
        //2.Generate all permutations of size k from list of size n
        //3.Asign each character with number from the permutations generated
        //4.Run the addition and see if permutations fits the bill, if yes print the permutation with character
        //Reference for permutation function https://stackoverflow.com/a/44954815
        //Self Reflection: This one helped me learn more about collections,recursion and crypt arithmetic
        public static void solvePuzzle()
        {
            try
            {
                
                Dictionary<char, int> dict = new Dictionary<char, int>();
                Console.WriteLine("Enter the string 1");
                String string1 = Console.ReadLine();
                Console.WriteLine("Enter the String 2");
                String string2 = Console.ReadLine();
                Console.WriteLine("Enter the Result String 3");
                String string3 = Console.ReadLine();
                String fin = String.Concat(string1, string2, string3);
                //I need the common characters in the string, i am using the hashset
                //to get the unique chracters, it removes the duplicates
                var unique = new HashSet<char>(fin);
                List<char> unichar = unique.ToList();
                Char[] str1 = string1.ToCharArray();
                Char[] str2 = string2.ToCharArray();
                Char[] str3 = string3.ToCharArray();

                

                int k = unique.Count;
                List<int> myList = new List<int>();
                for (int i = 0; i < 10; i++)
                {
                    //i am preserving the pool of numbers which are used to genrate all permutations, hence i will create
                    //a list which will have all the numbers , i wont use the same for any modifications
                    myList.Add(i);

                }
                List<int> a = new List<int>();
                //I am using 0 to 10 for program to run light, we can go until 20 , which gives solution to more
                //problems ,if the program doesnt work for any string , we just need to increase the pool numbers for it
                //work efficiently
                for (int j = 0; j < 10; j++)
                {
                    //a would be the list which will be used to generate all permutations
                    a.Add(myList[j]);
                }
                List<List<int>> result = new List<List<int>>();
                //choose returns all the permutations possible.
                result = choose(a, k);
                foreach (var sublist in result)
                {

                    for (int i = 0; i < sublist.Count; i++)
                    {
                        //Using dictionary(hashmap) to assign map each chracter with the numerical value
                        dict.Add(unichar[i], sublist[i]);
                    }
                    //findsum will permform the addition for one permutation from the list and prints it if it finds a
                    //fitting value
                    findsum(dict, str1, str2, str3);
                    
                    //I am clearing the dictionary to assign a different permutaion from the list of permutations
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
            //I am doing a array simple addition 
            for (int i = str1.Length - 1; i >= 0; i--,index--)
            {
                //get the number associated with the chracter at str[i] position
                dict.TryGetValue(str1[i], out a);
                dict.TryGetValue(str2[i], out b);
                dict.TryGetValue(str3[index], out c);
                sum = a + b + carry;
                //Carry as name suggests will be used in the next iteration for addition of the numbers.
                carry = sum / 10;
                comp = sum % 10;
                
                if (comp == c)
                {
                    flag = true;
                }
                else
                {
                    //Flag will become false when there is mismatch in added values
                    flag = false;
                    break;
                }

            }
            //There are some solutions which can fit the values but will end up having a carry for the next variable
            //and since resultant string and strings in addition are equal in length , they are no left over chracters for the
            //carry, so i discard such solutions
            if ((str3.Length == str1.Length) && carry > 0)
                flag = false;
            //if the resultant string is longer than the strings in addition, we need have the carry to fit the value for a chracter
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
            //Each list is permutaion , list of list contains all the permutations possible
            List<List<int>> allPermutations = new List<List<int>>();
            enumerate(a, a.Count, k, allPermutations);




            return allPermutations;
        }

        public static void enumerate(List<int> a, int n, int k, List<List<int>> allPermutations) {

            if (k == 0)
            {
                //if the k is zero , then we have swapped k numbers so we can add k numbers
                //to list starting from i is equal to n
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
                //we keep swapping numbers in recursive fashion , we will call enumeration everytime with
                //n lesser than 1 and k lesser than one
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


    
