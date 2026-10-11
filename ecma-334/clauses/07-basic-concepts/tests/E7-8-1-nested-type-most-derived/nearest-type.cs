/*
Rules: E7-8-1-nested-type-most-derived; E7-8-1-nested-type-resolution
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public new class Token { public int Value = 67; }
Into: public class Other { public int Value = 67; }
*/
using System;
class Root { public class Token { public int Value = 63; } }
class Middle : Root { public new class Token { public int Value = 67; } }
class Leaf : Middle { public static int Read() { return new Token().Value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Leaf.Read() == 67, "most-derived-inherited-nested-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
