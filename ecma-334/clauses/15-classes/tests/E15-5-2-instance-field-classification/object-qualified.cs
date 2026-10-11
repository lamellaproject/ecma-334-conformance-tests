/*
Rules: E15-5-2-instance-field-classification
Authority: ECMA-334 7th ed 15.5.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public int Code;
Into: public static int Code;
*/
using System;
class Holder { public int Code; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        value.Code = 991;
        Check(value.Code == 991, "nonstatic-declaration-object-qualified-field");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
