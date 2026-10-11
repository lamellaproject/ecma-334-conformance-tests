/*
Rules: E12-8-21-initializer-length-match
Authority: ECMA-334 7th ed 12.8.21
Version: 7.3
Expected: reject
Mutate: stackalloc int[3] { 7, 11 }
Into: stackalloc int[2] { 7, 11 }
*/
using System;
class Program
{
    static void Main()
    {
        Span<int> values = stackalloc int[3] { 7, 11 };
    }
}
