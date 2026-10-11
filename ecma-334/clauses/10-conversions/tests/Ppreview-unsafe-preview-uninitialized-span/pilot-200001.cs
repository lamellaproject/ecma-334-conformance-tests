/*
Rules: Ppreview-unsafe-preview-uninitialized-span
Authority: csc 5.11.0-1.26425.128 (C# preview)
Version: preview
Expected: reject
Requirements: updated-memory-safety
Mutate: stackalloc int[2]
Into: stackalloc int[]{1,2}
*/
using System;

static class Source{[System.Runtime.CompilerServices.SkipLocalsInit]public static void Read(){Span<int> value=stackalloc int[2];}}
class Program
{
    static void Main()
    {
        Source.Read();
    }
}
