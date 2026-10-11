/*
Rules: E15-6-8-external-method-classification
Authority: ECMA-334 7th ed 15.6.8
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: public static extern void Signal();
Into: public static void Signal();
*/
using System;
class External { public static extern void Signal(); }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { if (failures == 0) Console.WriteLine("OK " + checks); }
}
