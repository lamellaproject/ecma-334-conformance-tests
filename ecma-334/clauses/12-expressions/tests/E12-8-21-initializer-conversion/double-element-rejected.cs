/*
Rules: E12-8-21-initializer-conversion
Authority: ECMA-334 7th ed 12.8.21
Version: 7.3
Expected: reject
Mutate: stackalloc int[] { 4.0 }
Into: stackalloc int[] { 4 }
*/
using System;
class Program
{
    static void Main()
    {
        Span<int> values = stackalloc int[] { 4.0 };
    }
}
