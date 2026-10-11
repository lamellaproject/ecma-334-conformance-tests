/*
Rules: E7-3-method-name-overloads; E7-3-type-method-overloads; E7-6-method-overloading; E7-6-method-signature-parameters
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Read(string argument)
Into: Read(int argument)
*/
using System;
class Holder
{
    public int Read(int argument) { return 17; }
    public int Read(string argument) { return 23; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var value = new Holder();
        Check(value.Read(1) == 17, "integer-method-signature");
        Check(value.Read("leaf") == 23, "string-method-signature");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
