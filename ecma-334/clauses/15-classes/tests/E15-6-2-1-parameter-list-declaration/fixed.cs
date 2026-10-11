/*
Rules: E15-6-2-1-parameter-list-declaration; E15-6-2-1-grammar-formal-parameter-list-form-1; E15-6-2-1-grammar-fixed-parameters; E15-6-2-1-grammar-fixed-parameter; E15-6-2-1-fixed-parameter-type-name; E15-6-2-1-invocation-argument-assignment; E15-6-2-1-parameter-simple-name; E15-6-2-1-value-parameter-kind
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: first += second;
Into: first -= second;
*/
using System;
class Program
{
    static int Combine(int first, int second) { first += second; return first; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int left = 7, right = 11;
        Check(Combine(left, right) == 18, "fixed-parameter-identifiers-refer-to-argument-values");
        Check(left == 7, "value-parameter-assignment-does-not-modify-first-argument");
        Check(right == 11, "value-parameter-assignment-does-not-modify-second-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
