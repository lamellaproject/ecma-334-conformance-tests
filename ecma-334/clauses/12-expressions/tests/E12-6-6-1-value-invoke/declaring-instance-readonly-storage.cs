/*
Rules: E12-6-6-1-value-invoke; E12-6-6-1-value-mutation-observable
Authority: ECMA-334 5th ed 12.6.6.1
Version: 5
Expected: run
Stdout: OK 2
Mutate: reading.Advance(9);
Into: Meter temporary = reading; temporary.Advance(9);
*/
using System;
struct Meter
{
    public int Value;
    public Meter(int value) { Value = value; }
    public void Advance(int amount) { Value += amount; }
}
class Box
{
    readonly Meter reading;
    public readonly int Initial;
    public Box()
    {
        reading = new Meter(14);
        Initial = reading.Value;
        reading.Advance(9);
    }
    public int Value { get { return reading.Value; } }
}
class Program
{
    static int checks;
    static int failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Box box = new Box();
        Check(box.Initial == 14, "field-value-before-method-call");
        Check(box.Value == 23, "constructor-method-writes-instance-field");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
