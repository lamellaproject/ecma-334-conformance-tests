/*
Rules: E10-2-8-array-element
Authority: ECMA-334 7th ed 10.2.8
Version: 7.3
Expected: reject
Mutate: long[] target=source;
Into: long[] target=default(long[]);
Csc: CS0029
*/
using System;


class Program
{
    static void Main()
    {
        int[] source=new int[1]; long[] target=source;
    }
}
