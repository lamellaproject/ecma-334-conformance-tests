/*
Rules: E15-3-8-types-static; E15-3-8-static-or-instance
Authority: ECMA-334 7th ed 15.3.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public class Token { public int Read() { return 173; } }
Into: public object Token;
*/
using System;
class Shell { public class Token { public int Read() { return 173; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Shell.Token token = new Shell.Token();
        Check(token.Read() == 173, "nested-type-accessed-through-containing-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
