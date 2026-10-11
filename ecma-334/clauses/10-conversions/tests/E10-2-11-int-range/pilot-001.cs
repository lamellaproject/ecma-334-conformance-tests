/*
Rules: E10-2-11-int-range
Authority: ECMA-334 7th ed 10.2.11
Version: 7.3
Expected: reject
Mutate: byte destination=256;
Into: byte destination=default(byte);
Csc: CS0031
*/
using System;


class Program
{
    static void Main()
    {
        byte destination=256;
    }
}
