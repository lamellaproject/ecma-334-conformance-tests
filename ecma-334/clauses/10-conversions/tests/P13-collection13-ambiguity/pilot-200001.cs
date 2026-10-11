/*
Rules: P13-collection13-ambiguity
Authority: csc 5.11.0-1.26425.128 (C# 13.0)
Version: 13.0
Expected: reject
Mutate: Pick.Read([]);
Into: Pick.Read((ReadOnlySpan<int>)[]);
*/
using System;

static class Pick{public static void Read(ReadOnlySpan<int> x){}public static void Read(Span<int?> x){}}
class Program
{
    static void Main()
    {
        Pick.Read([]);
    }
}
