/*
Rules: Ppreview-unsafe-preview-pointer-conversions
Authority: csc 5.11.0-1.26425.128 (C# preview)
Version: preview
Expected: run
Stdout: OK 1
Requirements: updated-memory-safety
Mutate: Func<int> callable=Source.Read;
Into: Func<int> callable=default(Func<int>);
*/
using System;

static class Source{public static unsafe int Read()=>809;}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        unsafe {Func<int> callable=Source.Read;Check(callable()==809, "Ppreview-unsafe-preview-pointer-conversions-pilot-200002-check-01");}
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
