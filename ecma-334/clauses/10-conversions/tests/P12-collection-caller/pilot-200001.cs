/*
Rules: P12-collection-caller
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: run
Stdout: OK 1
Mutate: ReadOnlySpan<int> result=CollectionReturn.Constants();
Into: ReadOnlySpan<int> result=default(ReadOnlySpan<int>);
*/
using System;

static class CollectionReturn{public static ReadOnlySpan<int> Constants()=>[191,193];public static Span<int> Empty()=>[];}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ReadOnlySpan<int> result=CollectionReturn.Constants(); ReadOnlySpan<int> empty=CollectionReturn.Empty(); Check(result[1]==193 && empty.Length==0, "P12-collection-caller-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
