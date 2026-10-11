/*
Rules: E12-12-12-1-no-user-conversions
Authority: ECMA-334 7th ed 12.12.12.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: source is Target
Into: (Target)(Source)source != null
*/
using System;
class Target { }
class Source
{
    public static implicit operator Target(Source s) { Program.Calls++; return new Target(); }
}
class Program
{
    public static int Calls;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object source = new Source();
        Check(!(source is Target), "user-conversion-does-not-establish-is-compatibility");
        Check(Calls == 0, "conversion-not-invoked");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
