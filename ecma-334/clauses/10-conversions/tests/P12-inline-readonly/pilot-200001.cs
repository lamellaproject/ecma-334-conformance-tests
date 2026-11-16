/*
Rules: P12-inline-readonly
Authority: csc 5.12.0-1.26529.118 (C# 12.0)
Version: 12.0
Expected: reject
Mutate: Span<int> span=buffer;
Into: ReadOnlySpan<int> span=buffer;
*/
using System;

[System.Runtime.CompilerServices.InlineArray(3)] struct Buffer {private int first;} static class Reader{public static void Modify(in Buffer buffer){Span<int> span=buffer;}}
class Program
{
    static void Main()
    {

    }
}
