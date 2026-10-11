/*
Rules: E15-5-1-field-volatile; E15-5-1-grammar-field-modifier-form-8
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public volatile int Code;
Into: public volatile long Code;
*/
using System;
class Holder { public volatile int Code; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        value.Code = 947;
        Check(value.Code == 947, "volatile-field-declaration");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
