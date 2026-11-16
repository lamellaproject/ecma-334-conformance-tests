/*
Rules: P15-collection15-other
Authority: csc 5.12.0-1.26529.118 (C# 15.0)
Version: 15.0
Expected: reject
Mutate: ReadOnlySpan<int> value=[with(),653];
Into: ReadOnlySpan<int> value=default(ReadOnlySpan<int>);
*/
using System;


class Program
{
    static void Main()
    {
        ReadOnlySpan<int> value=[with(),653];
    }
}
