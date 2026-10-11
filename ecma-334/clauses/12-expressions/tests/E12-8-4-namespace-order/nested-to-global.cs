/*
Rules: E12-8-4-namespace-order; E12-8-4-type-match
Authority: ECMA-334 7th ed 12.8.4
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: public static int Local() { return Probe.Value; }
Into: public static int Local() { return global::Probe.Value; }
*/
using System;
class Probe { public static int Value = 8; }
namespace World
{
    class Probe { public static int Value = 5; }
    namespace Nested
    {
        class Probe { public static int Value = 3; }
        public class Reader { public static int Local() { return Probe.Value; } }
        namespace Deep { public class Reader { public static int Read() { return Probe.Value; } } }
    }
    namespace Other { public class Reader { public static int Read() { return Probe.Value; } } }
}
namespace Last.Other { public class Reader { public static int Read() { return Probe.Value; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(World.Nested.Reader.Local() == 3, "containing-namespace-wins");
        Check(World.Nested.Deep.Reader.Read() == 3, "nearest-enclosing-namespace-wins");
        Check(World.Other.Reader.Read() == 5, "namespace-search-continues-outward");
        Check(Last.Other.Reader.Read() == 8, "namespace-search-reaches-global");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
