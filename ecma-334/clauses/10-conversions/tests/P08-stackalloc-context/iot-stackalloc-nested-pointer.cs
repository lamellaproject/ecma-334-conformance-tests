/*
Rules: P08-stackalloc-context
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: Read(int* data)
Into: Read(Span<int> data)
*/
using System;
class Program
{
    static unsafe int Read(int* data) { return data[0] + data[1]; }
    static unsafe int Main()
    {
        return Read(stackalloc int[] { 17, 23 }) == 40 ? 0 : 1;
    }
}
