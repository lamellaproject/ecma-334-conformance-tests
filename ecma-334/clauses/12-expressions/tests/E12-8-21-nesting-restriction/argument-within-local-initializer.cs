/*
Rules: E12-8-21-nesting-restriction
Authority: ECMA-334 7th ed 12.8.21
Version: 7.3
Expected: reject
Mutate: Echo(stackalloc int[2])
Into: Echo(default(Span<int>))
*/
using System;
class Program
{
    static Span<int> Echo(Span<int> value) { return value; }
    static void Main()
    {
        Span<int> values = Echo(stackalloc int[2]);
    }
}
