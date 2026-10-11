/*
Rules: E7-3-type-method-overloads; E7-6-method-overloading
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Read(string argument)
Into: Read(int argument)
*/
using System;
struct Holder
{
    public int Read(int argument) { return 29; }
    public int Read(string argument) { return 31; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var value = new Holder();
        Check(value.Read(1) == 29, "struct-integer-overload");
        Check(value.Read("leaf") == 31, "struct-string-overload");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
