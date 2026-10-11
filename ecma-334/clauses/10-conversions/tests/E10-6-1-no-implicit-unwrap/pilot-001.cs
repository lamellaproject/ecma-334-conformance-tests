/*
Rules: E10-6-1-no-implicit-unwrap
Authority: ECMA-334 7th ed 10.6.1
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
        int? source=61; long target=source;
    }
}
