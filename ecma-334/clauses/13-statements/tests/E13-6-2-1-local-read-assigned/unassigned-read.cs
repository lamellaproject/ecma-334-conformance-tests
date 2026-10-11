/*
Rules: E13-6-2-1-local-read-assigned; E13-6-2-1-local-initial-unassigned
Authority: ECMA-334 7th ed 13.6.2.1
Version: 7.3
Expected: reject
Mutate: int value;
Into: int value = 7;
*/
using System;
class Program
{
    static void Main()
    {
        int value;
        Console.WriteLine("" + value);
    }
}
