/*
Rules: E7-8-1-namespace-name-form; E7-8-1-namespace-name-definition; E7-8-1-name-form-identifier; E7-8-2-namespace-unqualified-name
Authority: ECMA-334 7th ed 7.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: using Orchard.Grove;
Into: using Orchard;
*/
using System;
using Orchard.Grove;
namespace Orchard.Grove { class Fruit { public int Value = 17; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Fruit().Value == 17, "qualified-namespace-declaration-imported-by-declared-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
