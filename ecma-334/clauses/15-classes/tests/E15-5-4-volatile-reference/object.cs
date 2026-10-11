/*
Rules: E15-5-4-volatile-reference
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public volatile object Value;
Into: public volatile object Other;
*/
using System;
class Holder { public volatile object Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        object input = new object();
        value.Value = input;
        Check(value.Value == input, "volatile-object-reference-identity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
