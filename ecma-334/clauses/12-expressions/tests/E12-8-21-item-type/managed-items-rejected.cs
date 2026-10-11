/*
Rules: E12-8-21-item-type
Authority: ECMA-334 7th ed 12.8.21
Version: 7.3
Expected: reject
Mutate: stackalloc string[1]
Into: default(Span<string>)
*/
using System;
class Program
{
    static void Main()
    {
        Span<string> values = stackalloc string[1];
    }
}
