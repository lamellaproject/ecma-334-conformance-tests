/*
Rules: E10-3-5-array-element
Authority: ECMA-334 7th ed 10.3.5
Version: 7.3
Expected: reject
Mutate: int[] target=(int[])source;
Into: int[] target=default(int[]);
Csc: CS0030
*/
using System;


class Program
{
    static void Main()
    {
        long[] source=null; int[] target=(int[])source;
    }
}
