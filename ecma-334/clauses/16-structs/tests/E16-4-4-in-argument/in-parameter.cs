/*
Rules: E16-4-4-in-argument
Authority: ECMA-334 7th ed 16.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: in Entry item
Into: Entry item
*/
using System;
struct Entry { public int Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(in Entry item) { return item.Value; }
    static void Main()
    {
        Entry item = new Entry(); item.Value = 127;
        Check(Read(in item) == 127, "in-struct-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
