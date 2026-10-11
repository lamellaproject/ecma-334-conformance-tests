/*
Rules: E15-6-3-instance-method-instance; E15-6-3-instance-method-classification; E15-6-3-instance-method-this
Authority: ECMA-334 7th ed 15.6.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: first.Add(3)
Into: new Counter(5).Add(3)
*/
using System;
class Counter
{
    public int Value;
    public Counter(int value) { Value = value; }
    public int Add(int step) { this.Value += step; return this.Value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Counter first = new Counter(5), second = new Counter(19);
        Check(first.Add(3) == 8, "instance-method-accesses-receiver-through-this");
        Check(first.Value == 8, "instance-method-changes-selected-object");
        Check(second.Value == 19, "other-instance-value-unchanged");
        Check(second.Add(-2) == 17, "second-receiver-has-independent-state");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
