/*
Rules: E15-6-2-1-this-ref-struct
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: this ref Counter value
Into: this Counter value
*/
using System;
struct Counter { public int Value; }
static class Extensions
{
    public static void Add(this ref Counter value, int amount) { value.Value += amount; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Counter value = new Counter();
        value.Value = 3;
        value.Add(7);
        Check(value.Value == 10, "this-ref-extension-modifies-struct-variable");
        Extensions.Add(ref value, 2);
        Check(value.Value == 12, "ordinary-ref-extension-call-modifies-same-variable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
