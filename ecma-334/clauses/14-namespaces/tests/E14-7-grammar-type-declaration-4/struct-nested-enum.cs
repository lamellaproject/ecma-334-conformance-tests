/*
Rules: E14-7-grammar-type-declaration-4; E14-7-type-in-struct; E14-7-nested-type-definition
Authority: ECMA-334 7th ed 14.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: First = 29
Into: First = 31
*/
using System;
struct Owner { public enum Code { First = 29 } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check((int)Owner.Code.First == 29, "struct-nested-enum");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
