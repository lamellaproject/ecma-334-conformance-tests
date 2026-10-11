/*
Rules: E10-2-13-element
Authority: ECMA-334 7th ed 10.2.13
Version: 7.3
Expected: reject
Mutate: int x=61;
Into: const int x=61;
Csc: CS0029
*/
using System;


class Program
{
    static void Main()
    {
        int x=61; (byte a,string b) result=(x,"ok");
    }
}
