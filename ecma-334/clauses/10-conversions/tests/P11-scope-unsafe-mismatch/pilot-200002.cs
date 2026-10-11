/*
Rules: P11-scope-unsafe-mismatch
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: reject
Mutate: ScopedSpan value=Readers.Return;
Into: ScopedSpan value=default(ScopedSpan);
*/
using System;

delegate Span<int> ScopedSpan(scoped Span<int> n);static class Readers{public static Span<int> Return(Span<int> n)=>n;}
class Program
{
    static void Main()
    {
        ScopedSpan value=Readers.Return;
    }
}
