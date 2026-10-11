/*
Rules: E12-13-1-logical-category; E12-13-1-form-equality; E12-13-1-form-and; E12-13-1-form-and-base; E12-13-1-form-xor; E12-13-1-form-xor-base; E12-13-1-form-or
Authority: ECMA-334 7th ed 12.13.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: | Flag(false, "b")
Into: & Flag(false, "b")
*/
using System;
class Program
{
    static string trace = "";
    static bool Flag(bool b, string id) { trace += id; return b; }
    static int Num(int n, string id) { trace += id; return n; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool value = Flag(true, "a") | Flag(false, "b") ^ Flag(true, "c") & Num(3, "d") == Num(4, "e");
        Check(value && trace == "abcde", "grammar-precedence-and-eager-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
