/*
Rules: E7-7-1-namespace-member-scope; E7-7-1-scope-nesting; E7-7-1-hidden-outer-qualified-access; E7-7-2-2-nesting-hiding-sources
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: class Token { public static int Read() { return 31; } }
Into: class Renamed { public static int Read() { return 31; } }
*/
using System;
class Token { public static int Read() { return 23; } }
namespace Grove
{
    class Token { public static int Read() { return 31; } }
    namespace Inner { class Probe { public static int Read() { return Token.Read(); } } }
}
namespace Grove.Inner
{
    class Other
    {
        class Token { public static int Read() { return 37; } }
        public static int Own() { return Token.Read(); }
        public static int Outer() { return Grove.Token.Read(); }
        public static int Global() { return global::Token.Read(); }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Grove.Inner.Probe.Read() == 31, "namespace-member-in-descendant-namespace-body");
        Check(Grove.Inner.Other.Own() == 37, "nested-type-hides-namespace-type");
        Check(Grove.Inner.Other.Outer() == 31, "qualified-hidden-namespace-member");
        Check(Grove.Inner.Other.Global() == 23, "qualified-hidden-global-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
