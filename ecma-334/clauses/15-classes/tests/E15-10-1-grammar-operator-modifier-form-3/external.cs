/*
Rules: E15-10-1-grammar-operator-modifier-form-3; E15-10-1-grammar-operator-body-form-3
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: public static extern int operator +(Gauge x);
Into: public static extern int operator +(Gauge x) { return 1; }
*/
using System;
class Gauge { public static extern int operator +(Gauge x); }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {

        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
