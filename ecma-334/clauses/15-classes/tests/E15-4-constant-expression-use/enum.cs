/*
Rules: E15-4-constant-expression-use
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public const int Code = 179;
Into: public static readonly int Code = 179;
*/
using System;
class Limits { public const int Code = 179; }
enum Mark { Ready = Limits.Code }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check((int)Mark.Ready == 179, "constant-used-in-enum-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
