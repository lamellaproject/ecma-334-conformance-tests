/*
Rules: E16-4-12-5-operand-minimum
Authority: ECMA-334 7th ed 16.4.12.5
Version: 7.3
Expected: reject
Mutate: return choose ? wide : narrow;
Into: return choose ? wide : default(Span<int>);
*/
using System;
class Program
{
    static Span<int> Escape(bool choose)
    {
        Span<int> wide = new int[1]; Span<int> narrow = stackalloc int[1];
        return choose ? wide : narrow;
    }
    static void Main() { }
}
