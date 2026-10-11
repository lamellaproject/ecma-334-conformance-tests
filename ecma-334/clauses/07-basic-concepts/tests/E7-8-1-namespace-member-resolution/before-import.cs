/*
Rules: E7-8-1-namespace-member-resolution; E7-8-1-enclosing-namespace-search-order
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: namespace Grove { public class Fruit { public int Value = 79; } }
Into: namespace Local { public class Fruit { public int Value = 79; } }
*/
using System;
namespace Imported { public class Grove { public class Fruit { public int Value = 77; } } }
namespace Orchard
{
    using Imported;
    namespace Grove { public class Fruit { public int Value = 79; } }
    class Reader { public static int Read() { return new Grove.Fruit().Value; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Orchard.Reader.Read() == 79, "namespace-member-precedes-imported-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
