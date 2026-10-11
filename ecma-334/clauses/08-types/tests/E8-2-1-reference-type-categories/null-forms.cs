/*
Rules: E8-2-1-reference-type-categories; E8-2-1-null-reference-compatible; E8-2-1-null-reference-absence; E8-2-1-reference-form-interface; E8-2-1-interface-form-name; E8-2-1-reference-form-delegate; E8-2-1-delegate-form-name; E8-2-1-reference-form-array
Authority: ECMA-334 7th ed 8.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Receiver c = null;
Into: Receiver c = new Receiver();
*/
using System;
class Receiver { }
interface ITag { }
delegate void Callback();
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Receiver c = null; ITag i = null; int[] a = null; Callback d = null;
        Check(c == null && i == null && a == null && d == null, "null-reference-forms");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
