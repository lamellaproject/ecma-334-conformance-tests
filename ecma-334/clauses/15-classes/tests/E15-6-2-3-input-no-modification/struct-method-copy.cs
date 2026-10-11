/*
Rules: E15-6-2-3-input-no-modification
Authority: ECMA-334 7th ed 15.6.2.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: static int Observe(in Counter value)
Into: static int Observe(Counter value)
*/
using System;
struct Counter
{
    public int Value;
    public void Increment() { Value++; }
}
class Program
{
    static int Observe(in Counter value) { value.Increment(); return value.Value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Counter value = new Counter();
        value.Value = 71;
        Check(Observe(value) == 71, "mutating-struct-method-uses-copy-of-readonly-input");
        Check(value.Value == 71, "readonly-input-method-call-preserves-caller-struct");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
