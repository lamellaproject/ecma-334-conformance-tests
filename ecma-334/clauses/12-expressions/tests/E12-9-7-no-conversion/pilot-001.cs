/*
Rules: E12-9-7-no-conversion
Authority: ECMA-334 7th ed 12.9.7
Version: 7.3
Expected: reject
Mutate: int x=(int)new DateTime();
Into: int x=default(int);
Csc: CS0030
*/
using System;


class Program
{
    static void Main()
    {
        int x=(int)new DateTime();
    }
}
