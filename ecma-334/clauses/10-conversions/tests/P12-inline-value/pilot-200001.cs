/*
Rules: P12-inline-value
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: reject
Mutate: ReadOnlySpan<int> span=default(Buffer);
Into: ReadOnlySpan<int> span=default(ReadOnlySpan<int>);
*/
using System;

[System.Runtime.CompilerServices.InlineArray(3)] struct Buffer {private int first;} 
class Program
{
    static void Main()
    {
        ReadOnlySpan<int> span=default(Buffer);
    }
}
