/*
Rules: E18-4-1-new-suppresses-warning
Authority: ECMA-334 7th ed 18.4.1
Version: 7.3
Expected: run
Stdout: OK 0
Diagnostic: none
Mutate: interface IDerived : IBase { new void Read(); }
Into: interface IDerived : IBase { void Read(); }
*/
using System;
// 18.4.1, pp. 491-492 prints a blanket modifier ban that conflicts with its grammar
// and hiding rules. This test follows those rules, which permit new.
interface IBase { void Read(); }
interface IDerived : IBase { new void Read(); }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { if (failures == 0) Console.WriteLine("OK " + checks); }
}
