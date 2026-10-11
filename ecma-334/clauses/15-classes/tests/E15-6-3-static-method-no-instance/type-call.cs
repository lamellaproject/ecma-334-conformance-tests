/*
Rules: E15-6-3-static-method-no-instance; E15-6-3-static-method-classification
Authority: ECMA-334 7th ed 15.6.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public static int Read()
Into: public int Read()
*/
using System;
class Counter
{
    static int next = 41;
    public int Value;
    public Counter(int value) { Value = value; }
    public static int Read() { return next++; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Counter.Read() == 41, "static-method-call-needs-no-instance");
        Counter first = new Counter(5), second = new Counter(17);
        Check(Counter.Read() == 42, "static-method-uses-type-storage-after-instances-created");
        Check(first.Value == 5 && second.Value == 17, "static-method-independent-of-instance-values");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
