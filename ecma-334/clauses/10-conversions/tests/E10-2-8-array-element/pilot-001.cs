/*
Rules: E10-2-8-array-element
Authority: ECMA-334 7th ed 10.2.8
Version: 7.3
Expected: reject
Mutate: object[] target=source;
Into: object[] target=default(object[]);
Csc: CS0029
*/
using System;


class Program
{
    static void Main()
    {
        int[] source=new int[1]; object[] target=source;
    }
}
