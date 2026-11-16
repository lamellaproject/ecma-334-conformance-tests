/*
Rules: P12-inline-lifetime
Authority: csc 5.12.0-1.26529.118 (C# 12.0)
Version: 12.0
Expected: reject
Mutate: Escape(){Buffer buffer=default;return buffer;}
Into: Escape(ref Buffer buffer){return buffer;}
*/
using System;

[System.Runtime.CompilerServices.InlineArray(3)] struct Buffer {private int first;} static class Reader{public static Span<int> Escape(){Buffer buffer=default;return buffer;}}
class Program
{
    static void Main()
    {

    }
}
