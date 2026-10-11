/*
Rules: E10-2-8-array-rank
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
        string[,] source=new string[1,1]; object[] target=source;
    }
}
