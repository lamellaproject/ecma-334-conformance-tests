/*
Rules: E12-8-21-catch-initializer
Authority: ECMA-334 7th ed 12.8.21
Version: 7.3
Expected: reject
Mutate: stackalloc int[1] { 7 }
Into: default(Span<int>)
*/
using System;
class Program
{
    static void Main()
    {
        try { }
        catch (Exception) { Span<int> values = stackalloc int[1] { 7 }; }
    }
}
