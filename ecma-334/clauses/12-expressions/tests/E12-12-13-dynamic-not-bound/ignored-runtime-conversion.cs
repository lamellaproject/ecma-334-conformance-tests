/*
Rules: E12-12-13-dynamic-not-bound; E12-12-13-dynamic-result; E12-12-13-single-evaluation
Authority: ECMA-334 7th ed 12.12.13
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Get(new Source()) as Target
Into: (Target)Get(new Source())
*/
using System;
public class Target { }
public class Derived : Target { }
public class Source
{
    public static explicit operator Target(Source s) { Program.Conversions++; return new Target(); }
}
public class Program
{
    public static int Calls, Conversions;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static dynamic Get(object value) { Calls++; return value; }
    static int Kind(Target x) { return 1; }
    static int Kind(Derived x) { return 2; }
    static void Main()
    {
        var result = Get(new Derived()) as Target;
        Check(result != null && Calls == 1, "compatible-dynamic-value-once");
        Check(Kind(result) == 1, "as-result-has-static-target-type");
        result = Get(new Source()) as Target;
        Check(result == null && Calls == 2, "incompatible-dynamic-value-once");
        Check(Conversions == 0, "dynamic-user-conversion-not-bound");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
