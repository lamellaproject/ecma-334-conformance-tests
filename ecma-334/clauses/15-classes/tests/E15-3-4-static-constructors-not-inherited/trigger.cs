/*
Rules: E15-3-4-static-constructors-not-inherited
Authority: ECMA-334 7th ed 15.3.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: class Child : Parent { public static int Read() { return 331; } }
Into: class Child : Parent { static Child() { new Parent(); } public static int Read() { return 331; } }
*/
using System;
class Trace { public static int BaseCalls; }
class Parent { static Parent() { Trace.BaseCalls++; } }
class Child : Parent { public static int Read() { return 331; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Child.Read() == 331, "derived-static-member-executed");
        Check(Trace.BaseCalls == 0, "derived-static-member-does-not-inherit-base-initializer");
        new Parent();
        Check(Trace.BaseCalls == 1, "base-initializer-runs-on-base-trigger");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
