/*
Rules: E10-2-7-nonnullable
Authority: ECMA-334 7th ed 10.2.7
Version: 7.3
Expected: reject
Mutate: int destination=null;
Into: int destination=default(int);
Csc: CS0037
*/
using System;


class Program
{
    static void Main()
    {
        int destination=null;
    }
}
