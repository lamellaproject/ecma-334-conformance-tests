/*
Rules: E8-1-unified-object-treatment; E8-1-value-object-bridge; E8-1-object-ultimate-base; E8-2-3-object-base-type; E8-2-3-object-alias; E8-2-1-class-form-object
Authority: ECMA-334 7th ed 8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: object boxed = 71;
Into: object boxed = "71";
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object boxed = 71;
        System.Object view = boxed;
        Check((int)view == 71, "object-view-of-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
