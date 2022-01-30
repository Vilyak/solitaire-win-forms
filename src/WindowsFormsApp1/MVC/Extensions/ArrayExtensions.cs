using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.MVC.Extensions
{
    public static class ArrayExtensions
    {
        public static void swapValues<T>(this T[] source, long index1, long index2)
        {
            if (index1 >= 0 && index2 >= 0 && index1 <= source.Length && index2 <= source.Length)
            {
                T temp = source[index1];
                source[index1] = source[index2];
                source[index2] = temp;
            }
        }
    }
}
