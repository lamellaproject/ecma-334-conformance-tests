/*
Rules: P15-collection15-other
Authority: csc 5.11.0-1.26425.128 (C# 15.0)
Version: 15.0
Expected: reject
Mutate: Span<int> value=[with(),653];
Into: Span<int> value=default(Span<int>);
*/
using System;


class Program
{
    static void Main()
    {
        Span<int> value=[with(),653];
    }
}
