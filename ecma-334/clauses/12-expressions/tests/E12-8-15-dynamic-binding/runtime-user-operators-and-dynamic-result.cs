/*
Rules: E12-8-15-dynamic-binding; E12-8-15-dynamic-type; E12-8-15-dynamic-runtime-type
Authority: ECMA-334 7th ed 12.8.15
Version: 7.3
Expected: run
Stdout: OK 8
Mutate: var old = value++;
Into: var old = ++value;
*/
using System;
public struct Counter
{
    public int Value;
    public Counter(int value) { Value = value; }
    public static Counter operator++(Counter value) { Program.calls++; return new Counter(value.Value + 5); }
    public static Counter operator--(Counter value) { Program.calls++; return new Counter(value.Value - 5); }
}
public class Program
{
    public static int calls;
    static int checks, failures;
    static int Kind(Counter value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic value = new Counter(7);
        var old = value++;
        int tag = Kind(old);
        Check(old.Value == 7, "dynamic-increment-old-value");
        Check(value.Value == 12, "runtime-increment-uses-custom-operator");
        Check(calls == 1, "dynamic-increment-invokes-once");
        Check(tag == 1, "var-postfix-result-keeps-dynamic-binding");
        var before = value--;
        tag = Kind(before);
        Check(before.Value == 12, "dynamic-decrement-old-value");
        Check(value.Value == 7, "runtime-decrement-uses-custom-operator");
        Check(calls == 2, "dynamic-decrement-invokes-once");
        Check(tag == 1, "var-decrement-result-keeps-dynamic-binding");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
