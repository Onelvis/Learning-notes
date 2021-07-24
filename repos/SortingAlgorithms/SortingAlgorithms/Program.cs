using System;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 4, 8, 5, 1, 6, 7, 9, 30, 45, 3, 2, 10};
            Console.WriteLine("[{0}]", string.Join(", ", MergeSort(array)));
        }

        public static int[] MergeSort(int[] array)
        {
            int middleIndex = array.Length / 2;
            int[] left = new int[middleIndex];
            int[] right = new int[array.Length - middleIndex];
            if (array.Length == 1) return array;
            Array.Copy(array, left, array.Length / 2);
            Array.Copy(array, middleIndex, right, 0, array.Length - middleIndex);
            left = MergeSort(left);
            right = MergeSort(right);
            return MergeArrays(left, right);
        }
        public static int[] MergeArrays(int[] left, int[] right)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            int[] mergedArray = new int[left.Length + right.Length];
            while (i < left.Length && j < right.Length)
            {
                if (left[i] < right[j])
                {
                    mergedArray[k] = left[i];
                    i++;
                    if (i == left.Length)
                    {
                        while (j < right.Length)
                        {
                            mergedArray[++k] = right[j++];
                        }
                    }
                }
                else
                {
                    mergedArray[k] = right[j];
                    j++;
                    if (j == right.Length)
                    {
                        while ( i < left.Length)
                        {
                            mergedArray[++k] = left[i++];
                        }
                    }
                }
                k++;
            }
            return mergedArray;
        }
    }
}