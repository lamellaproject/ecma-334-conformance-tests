/*
Rules: E10-2-11-nonconstant
Authority: ECMA-334 7th ed 10.2.11
Version: 7.3
Expected: reject
Mutate: byte destination=source;
Into: byte destination=default(byte);
Csc: CS0266
*/
using System;


class Program
{
    static void Main()
    {
        int source=61; byte destination=source;
    }
}
