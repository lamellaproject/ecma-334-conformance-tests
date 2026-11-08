/*
Rules: E8-3-1-simple-types-keywords
Authority: ECMA-334 7th ed 8.3.1
Version: 7.3
Expected: reject
Mutate: Int count = 37;
Into: int count = 37;
*/
using System;
class Program
{
    static void Main()
    {
        Int count = 37;
        Console.WriteLine(count == 37 ? "OK 1" : "FAIL type-name");
    }
}
