/*
Rules: E12-14-1-conditional-logical-category; E12-14-1-form-inclusive-or; E12-14-1-form-and; E12-14-1-form-conditional-and; E12-14-1-form-or
Authority: ECMA-334 7th ed 12.14.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: A(true, "a") || A(false, "b")
Into: A(true, "a") && A(false, "b")
*/
using System;
class Program
{
    static string trace = "";
    static bool A(bool value, string id) { trace += id; return value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool value = A(true, "a") || A(false, "b") && A(true, "c") | A(false, "d");
        Check(value && trace == "a", "conditional-grammar-and-precedence");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
