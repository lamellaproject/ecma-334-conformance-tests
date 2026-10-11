/*
Rules: E16-4-12-1-no-wider-assignment; E16-4-12-1-safe-context; E16-4-12-1-contexts
Authority: ECMA-334 7th ed 16.4.12.1
Version: 7.3
Expected: reject
Mutate: outside = inside;
Into: inside = outside;
*/
using System;
class Program
{
    static void Main()
    {
        Span<int> outside = default(Span<int>);
        { Span<int> inside = stackalloc int[1]; outside = inside; }
    }
}
