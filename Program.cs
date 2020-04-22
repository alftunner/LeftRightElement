using System;
using static System.Console;

namespace LeftRightElement
{
    class Program
    {
        static void InitArray(int[]arr, int size)
        {
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(-20, 20);
            }
        }
        static void OutputArray(int[]arr, int size)
        {
            for (int i = 0; i < size; i++)
            {
                Write($"{arr[i]} ");
            }
            WriteLine();
        }
        static (int l_index, int r_index) RightLeft(int[]arr, int size)
        {
            int right = arr[0];
            int r_index = 0;
            int left = arr[size - 1];
            int l_index = 0;
            for (int i = 0; i < size; i++)
            {
                if(arr[i] < 0)
                {
                    right = arr[i];
                    r_index = i;
                }
            }
            for (int j = size-1; j >= 0; j--)
            {
                if(arr[j] < 0)
                {
                    left = arr[j];
                    l_index = j;
                }
            }
            return (l_index, r_index);
        }
        static void QuickSort(int[]arr, int left, int right)
        {
            int temp;
            int i = left;
            int j = right;
            int p = arr[(right - left) / 2 + left];
            while(i<=j)
            {
                while (arr[i] < p && i <= right) i++;
                while (arr[j] > p && j >= left) j--;
                if(i<=j)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++; j--;
                }
            }
            if (left < j) QuickSort(arr, left, j);
            if (right > i) QuickSort(arr, i, right);
        }
        static void Main(string[] args)
        {
            int[] array = new int[20];
            InitArray(array, 20);
            OutputArray(array, 20);
            var leftRight = RightLeft(array, 20);
            QuickSort(array, leftRight.l_index+1, leftRight.r_index-1);
            OutputArray(array, 20);
            
        }
    }
}
