/*
Rules: P14-span14-no-reverse
Authority: csc 5.12.0-1.26529.118 (C# 14.0)
Version: 14.0
Expected: reject
Mutate: Span<int> mutable=(Span<int>)source;
Into: Span<int> mutable=default(Span<int>);
*/
using System;


class Program
{
    static void Main()
    {
        ReadOnlySpan<int> source=new int[]{491};Span<int> mutable=(Span<int>)source;
    }
}
