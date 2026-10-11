/*
Rules: E16-4-12-1-default-caller
Authority: ECMA-334 7th ed 16.4.12.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return default(Span<int>);
Into: Span<int> item = stackalloc int[1]; return item;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Span<int> Read() { return default(Span<int>); }
    static void Main()
    {
        Span<int> item = Read();
        Check(item.Length == 0, "default-ref-struct-caller-context");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
