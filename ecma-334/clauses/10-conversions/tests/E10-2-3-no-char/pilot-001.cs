/*
Rules: E10-2-3-no-char; E10-2-3-only-listed
Authority: ECMA-334 7th ed 10.2.3
Version: 7.3
Expected: reject
Mutate: char destination=value;
Into: char destination=default(char);
Csc: CS0266
*/
using System;


class Program
{
    static void Main()
    {
        byte value=61; char destination=value;
    }
}
