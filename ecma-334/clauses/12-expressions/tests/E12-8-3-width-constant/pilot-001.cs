/*
Rules: E12-8-3-width-constant
Authority: ECMA-334 7th ed 12.8.3
Version: 7.3
Expected: reject
Mutate: int width=4;
Into: const int width=4;
Csc: CS0150
*/
using System;


class Program
{
    static void Main()
    {
        int width=4; FormattableString result=$"{61,width}";
    }
}
