/*
Rules: E7-8-1-enclosing-namespace-search-order; E7-8-1-namespace-type-resolution
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: namespace Inner { class Token { public int Value = 73; }
Into: namespace Inner { class Other { public int Value = 73; }
*/
using System;
// 7.8.1, pp. 64-65 requires trying every enclosing namespace before the final
// undefined-name case. This test reads the otherwise branch with that search loop.
class GlobalToken { public int Value = 71; }
namespace Orchard
{
    class Token { public int Value = 69; }
    namespace Inner { class Token { public int Value = 73; }
        class Reader { public static int Read() { return new Token().Value; } } }
    namespace Sibling { class Reader { public static int Read() { return new Token().Value; } } }
    class Reader { public static int ReadGlobal() { return new GlobalToken().Value; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Orchard.Inner.Reader.Read() == 73, "current-namespace-before-outer");
        Check(Orchard.Sibling.Reader.Read() == 69, "continue-past-empty-inner-level");
        Check(Orchard.Reader.ReadGlobal() == 71, "continue-to-global-namespace");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
