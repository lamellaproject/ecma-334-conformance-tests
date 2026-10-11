/*
Rules: E15-6-2-1-this-in-struct
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: this in Counter value
Into: in Counter value
*/
using System;
struct Counter { public int Value; }
static class Extensions
{
    public static int Read(this in Counter value) { return value.Value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Counter value = new Counter();
        value.Value = 23;
        Check(value.Read() == 23, "this-in-extension-reads-struct-variable");
        Check(Extensions.Read(in value) == 23, "ordinary-input-extension-call");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
