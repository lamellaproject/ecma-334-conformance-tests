/*
Rules: E12-8-7-1-instance-property; E12-8-7-1-instance-property-type; E12-8-7-1-instance-lookup
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: first.Value
Into: second.Value
*/
using System;
class Worker
{
    public int value, calls;
    public int Value { get { calls++; return value; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Pick(int value) { return value; }
    static int Pick(object value) { return 9; }
    static void Main()
    {
        Worker first = new Worker { value = 3 }, second = new Worker { value = 8 };
        int result = Pick(first.Value);
        Check(result == 3, "instance-property-has-declared-type-and-receiver-value");
        Check(first.calls == 1 && second.calls == 0, "instance-property-has-associated-receiver");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
