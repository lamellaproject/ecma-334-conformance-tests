/*
Rules: E10-2-11-negative-long
Authority: ECMA-334 7th ed 10.2.11
Version: 7.3
Expected: reject
Mutate: ulong destination=source;
Into: ulong destination=default(ulong);
Csc: CS0031
*/
using System;


class Program
{
    static void Main()
    {
        const long source=-1; ulong destination=source;
    }
}
