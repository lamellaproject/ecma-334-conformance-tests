/*
Rules: E12-8-21-span-ref-struct
Authority: ECMA-334 7th ed 12.8.21
Version: 7.3
Expected: reject
Mutate: object boxed = values;
Into: Span<int> boxed = values;
*/
using System;
class Program
{
    static void Main()
    {
        Span<int> values = stackalloc int[1];
        object boxed = values;
    }
}
