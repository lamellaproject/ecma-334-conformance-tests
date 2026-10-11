/*
Rules: E15-5-5-default-initial-field-value
Authority: ECMA-334 7th ed 15.5.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public int? Value;
Into: public int? Value = 7;
*/
using System;
class Holder { public int? Value; public static int? Global; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(!new Holder().Value.HasValue, "instance-nullable-default-without-value");
        Check(!Holder.Global.HasValue, "static-nullable-default-without-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
