/*
Rules: E15-5-4-volatile-reference
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public volatile dynamic Value;
Into: public volatile dynamic Other;
*/
using System;
class Holder { public volatile dynamic Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        object input = new object();
        value.Value = input;
        object observed = value.Value;
        Check(observed == input, "volatile-dynamic-reference-identity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
