/*
Rules: E12-8-21-negative-constant-length
Authority: ECMA-334 7th ed 12.8.21
Version: 7.3
Expected: reject
Mutate: stackalloc int[-2]
Into: stackalloc int[2]
*/
using System;
class Program
{
    static void Main()
    {
        Span<int> values = stackalloc int[-2];
    }
}
