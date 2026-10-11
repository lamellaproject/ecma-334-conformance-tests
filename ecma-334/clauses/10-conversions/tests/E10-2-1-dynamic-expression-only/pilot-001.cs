/*
Rules: E10-2-1-dynamic-expression-only
Authority: ECMA-334 7th ed 10.2.1
Version: 7.3
Expected: reject
Mutate: long target=source;
Into: long target=default(long);
Csc: CS0266
*/
using System;


class Program
{
    static void Main()
    {
        object source=61; long target=source;
    }
}
