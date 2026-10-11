/*
Rules: E14-5-2-extern-order-insignificant; E14-4-alias-contextual-keyword
Authority: ECMA-334 7th ed 14.5.2
Version: 7.3
Expected: run
Stdout: OK 3
Fixture: {"program":{"references":[{"alias":"Outside","asset":"System.Runtime.dll"},{"alias":"Other","asset":"System.Runtime.dll"}]}}
Mutate: extern alias Outside; extern alias Other;
Into: extern alias Missing; extern alias Other;
*/
using System;
class alias { public const int Code = 29; }
namespace First { extern alias Outside; extern alias Other; using Value = Outside::System.Int32; class Reader { public static Value Read() { return 29; } } }
namespace Second { extern alias Other; extern alias Outside; using Value = Outside::System.Int32; class Reader { public static Value Read() { return 29; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(First.Reader.Read() == 29, "first-extern-order");
        Check(Second.Reader.Read() == 29, "second-extern-order");
        Check(alias.Code == 29, "alias-is-ordinary-identifier-here");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
