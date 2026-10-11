/*
Rules: E16-4-12-6-invocation-minimum
Authority: ECMA-334 7th ed 16.4.12.6
Version: 7.3
Expected: reject
Mutate: return First(wide, narrow);
Into: return First(wide, default(Span<int>));
*/
using System;
class Program
{
    static Span<int> First(Span<int> left, Span<int> right) { return left; }
    static Span<int> Escape()
    {
        Span<int> wide = new int[1]; Span<int> narrow = stackalloc int[1];
        return First(wide, narrow);
    }
    static void Main() { }
}
