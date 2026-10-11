/*
Rules: Ppreview-unsafe-preview-pointer-conversions; Ppreview-unsafe-preview-stackalloc-pointer
Authority: csc 5.11.0-1.26425.128 (C# preview)
Version: preview
Expected: run
Stdout: OK 2
Mutate: int* restored=(int*)erased;
Into: int* restored=default(int*);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value=787;int* address=&value;void* erased=address;int* restored=(int*)erased;
        long numeric=(long)restored;int* again=(int*)numeric;Check(again==address, "Ppreview-unsafe-preview-pointer-conversions-pilot-200001-check-01");
        int* allocated=stackalloc int[2];Check(allocated!=null, "Ppreview-unsafe-preview-pointer-conversions-pilot-200001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
