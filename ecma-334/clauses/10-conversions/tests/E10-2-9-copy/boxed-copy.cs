/*
Rules: E10-2-9-copy; E10-2-9-object; E10-3-7-object; E10-3-7-copy
Authority: ECMA-334 7th ed 10.2.9
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: object boxed = value;
Into: object boxed = new Counter();
*/
using System;
struct Counter { public int Number; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Counter value = new Counter();
        value.Number = 61;
        object boxed = value;
        value.Number = 93;
        Counter restored = (Counter)boxed;
        Check(restored.Number == 61, "boxed-copy/original-value");
        restored.Number = 12;
        Check(((Counter)boxed).Number == 61, "boxed-copy/unboxed-copy");
        Check(value.Number == 93, "boxed-copy/source-independent");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
