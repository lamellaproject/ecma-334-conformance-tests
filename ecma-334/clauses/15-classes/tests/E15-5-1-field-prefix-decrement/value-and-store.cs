/*
Rules: E15-5-1-field-prefix-decrement
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int result = --value.Code;
Into: int result = value.Code--;
*/
using System;
class Holder { public int Code = 359; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        int result = --value.Code;
        Check(result == 358, "prefix-decrement-new-field-value");
        Check(value.Code == 358, "prefix-decrement-stored-field-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
