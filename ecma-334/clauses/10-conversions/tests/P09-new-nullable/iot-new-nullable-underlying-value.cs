/*
Rules: P09-new-nullable
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 3
Mutate: Gauge? value = new(29);
Into: Gauge? value = new();
*/
using System;

// Target-typed new specification L50: a Nullable target constructs its underlying type.
struct Gauge
{
    public static int Calls;
    public int Reading;
    public Gauge(int reading) { Calls++; Reading = reading; }
}
class Program
{
    static int checks, failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Gauge? value = new(29);
        Check(value.HasValue, "nullable-target-contains-underlying-value");
        Check(value.GetValueOrDefault().Reading == 29, "underlying-constructor-value");
        Check(Gauge.Calls == 1, "underlying-constructor-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
