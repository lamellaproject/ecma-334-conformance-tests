/*
Rules: E12-8-9-3-search-order; E12-8-9-3-direct-candidates; E12-8-9-3-imported-candidates
Authority: ECMA-334 7th ed 12.8.9.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public static int Read(this object value)
Into: public static int Read(this string value)
*/
using System;
namespace Imported { public static class Extensions { public static int Read(this int value) { return 3; } } }
namespace Outer
{
    public static class Extensions { public static int Read(this int value) { return 2; } }
    namespace Inner
    {
        using Imported;
        public static class Extensions { public static int Read(this object value) { return 1; } }
        public class Call { public static int Run() { return 5.Read(); } }
    }
    namespace ImportOnly
    {
        using Imported;
        public class Call { public static int Run() { return 5.Read(); } }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Outer.Inner.Call.Run() == 1, "direct-inner-set-precedes-import-and-outer-better-conversions");
        Check(Outer.ImportOnly.Call.Run() == 3, "inner-imported-set-precedes-outer-direct-set");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
