/*
Rules: E15-3-8-constants-static; E15-3-8-static-or-instance
Authority: ECMA-334 7th ed 15.3.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public const int Code = 167;
Into: public int Code = 167;
*/
using System;
class Register { public const int Code = 167; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Register.Code == 167, "constant-accessed-through-type-without-static-modifier");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
