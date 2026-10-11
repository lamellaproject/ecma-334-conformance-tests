/*
Rules: Ppreview-unsafe-preview-pointer-conversions
Authority: csc 5.11.0-1.26425.128 (C# preview)
Version: preview
Expected: run
Stdout: OK 1
Requirements: updated-memory-safety
Mutate: stackalloc int[]{821}
Into: stackalloc int[1]
*/
using System;

static class Source{[System.Runtime.CompilerServices.SkipLocalsInit]public static int Read(){Span<int> value=stackalloc int[]{821};return value[0];}}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Source.Read()==821, "Ppreview-unsafe-preview-pointer-conversions-pilot-200003-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
