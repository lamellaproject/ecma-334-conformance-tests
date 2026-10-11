/*
Rules: E7-3-type-method-overloads; E7-6-method-overloading
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int Read(string argument);
Into: int Read(int argument);
*/
using System;
interface Contract { int Read(int argument); int Read(string argument); }
class Holder : Contract
{
    public int Read(int argument) { return 37; }
    public int Read(string argument) { return 41; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Contract value = new Holder();
        Check(value.Read(1) == 37, "interface-integer-overload");
        Check(value.Read("leaf") == 41, "interface-string-overload");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
