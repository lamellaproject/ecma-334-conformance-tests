/*
Rules: E10-2-3-only-listed; E8-3-8-no-floating-implicit
Authority: ECMA-334 7th ed 10.2.3
Version: 7.3
Expected: reject
Mutate: decimal destination=value;
Into: decimal destination=default(decimal);
Csc: CS0266
*/
using System;


class Program
{
    static void Main()
    {
        double value=2.25; decimal destination=value;
    }
}
