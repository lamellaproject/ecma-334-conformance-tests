/*
Rules: E16-2-3-no-safe-context-escape; E16-4-12-1-return-caller; E16-4-12-3-initializer-context; E16-4-12-7-function-member-context
Authority: ECMA-334 7th ed 16.2.3
Version: 7.3
Expected: reject
Mutate: stackalloc int[2]
Into: new int[2]
*/
using System;
class Program
{
    static Span<int> Escape() { Span<int> item = stackalloc int[2]; return item; }
    static void Main() { }
}
