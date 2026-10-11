/*
Rules: E15-3-8-static-no-receiver; E15-3-8-static-modifier-classifies
Authority: ECMA-334 7th ed 15.3.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public static int operator +(Token value)
Into: public int operator +(Token value)
*/
using System;
class Token { public static int operator +(Token value) { return 157; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Token token = null;
        Check(+token == 157, "static-operator-null-operand-is-not-receiver");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
