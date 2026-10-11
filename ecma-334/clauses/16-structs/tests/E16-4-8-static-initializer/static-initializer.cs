/*
Rules: E16-4-8-static-initializer
Authority: ECMA-334 7th ed 16.4.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public static int Value = 163;
Into: public int Value = 163;
*/
using System;
struct Entry { public static int Value = 163; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Entry.Value == 163, "static-field-initializer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
