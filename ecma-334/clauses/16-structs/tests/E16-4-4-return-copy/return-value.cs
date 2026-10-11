/*
Rules: E16-4-4-return-copy
Authority: ECMA-334 7th ed 16.4.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: struct Entry
Into: class Entry
*/
using System;
struct Entry { public int Value; }
class Program
{
    static int checks, failures;
    static Entry saved;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Entry Read() { return saved; }
    static void Main()
    {
        saved = new Entry(); saved.Value = 23;
        Entry result = Read();
        Check(result.Value == 23, "returned-data");
        result.Value = 77;
        Check(saved.Value == 23, "return-copy-source");
        Check(result.Value == 77, "return-copy-destination");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
