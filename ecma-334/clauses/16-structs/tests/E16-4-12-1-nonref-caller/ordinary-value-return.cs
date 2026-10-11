/*
Rules: E16-4-12-1-nonref-caller
Authority: ECMA-334 7th ed 16.4.12.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return item;
Into: return default(Entry);
*/
using System;
struct Entry { public int Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Entry Read() { Entry item = new Entry(); item.Value = 179; return item; }
    static void Main()
    {
        Check(Read().Value == 179, "nonref-value-escapes-local-context");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
