/*
Rules: E15-5-2-static-field-classification
Authority: ECMA-334 7th ed 15.5.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public static int Code;
Into: public int Code;
*/
using System;
class Holder { public static int Code; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder.Code = 983;
        Check(Holder.Code == 983, "static-declaration-type-qualified-field");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
