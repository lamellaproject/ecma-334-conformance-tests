/*
Rules: E12-8-16-6-ed1-method-delegate-always-fresh
Authority: ECMA-334 1st ed 14.5.10.3
Version: ISO-1
Expected: run
Stdout: OK 4
Diagnostic: none
Mutate: return new Measure(ReadStatic);
Into: return Cached;
*/
// ECMA-334 1st ed 14.5.10.3, p. 150 (PDF p. 164), lines 29-33 allocates each time. The 7th
// edition's 10.8 permits reuse. Equal invocation behavior alone is insufficient: object
// identity distinguishes allocation from a cached delegate result.
using System;
delegate int Measure();
class Maker
{
    int payload;
    public Maker(int value) { payload = value; }
    int Read() { return payload; }
    public Measure Create() { return new Measure(Read); }
}
class Entry
{
    static int checks;
    static int failures;
    public static Measure Cached = new Measure(ReadStatic);
    static int ReadStatic() { return 67; }
    static Measure CreateStatic() { return new Measure(ReadStatic); }
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    public static int Main()
    {
        Measure first = CreateStatic();
        Measure second = CreateStatic();
        Maker maker = new Maker(71);
        Measure left = maker.Create();
        Measure right = maker.Create();
        Check(!object.ReferenceEquals(first, second), "static-fresh");
        Check(!object.ReferenceEquals(left, right), "instance-fresh");
        Check(first() == 67 && second() == 67, "static-method");
        Check(left() == 71 && right() == 71, "instance-target");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
