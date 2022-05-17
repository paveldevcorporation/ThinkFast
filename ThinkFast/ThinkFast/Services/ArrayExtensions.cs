using System;

namespace ThinkFast.Services
{
    public static class ArrayExtensions
    {
        public static void Shuffle<T>(this T[] arr)
        {
            Random rand = new Random();

            for (int i = arr.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                T tmp = arr[j];
                arr[j] = arr[i];
                arr[i] = tmp;
            }
        }
    }
}