/*
Rules: E10-3-5-array-rank
Authority: ECMA-334 7th ed 10.3.5
Version: 7.3
Expected: reject
Mutate: string[] target=(string[])source;
Into: string[] target=default(string[]);
Csc: CS0030
*/
using System;


class Program
{
    static void Main()
    {
        object[,] source=null; string[] target=(string[])source;
    }
}
