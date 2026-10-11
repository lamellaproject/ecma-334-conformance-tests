/*
Rules: E15-5-1-field-assignment; E15-5-1-field-variable
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public int Code;
Into: public readonly int Code;
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
        int result = (value.Code = 293);
        Check(result == 293, "field-assignment-expression-value");
        Check(value.Code == 293, "field-assignment-stored-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
