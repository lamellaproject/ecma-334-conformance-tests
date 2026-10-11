/*
Rules: E12-8-9-1-dynamic-invalid-primary
Authority: ECMA-334 7th ed 12.8.9.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: dynamic primary = 5;
Into: dynamic primary = (Operation)Double;
*/
using System;
public delegate int Operation(int value);
class Program
{
    static int checks, failures;
    static int Double(int value) { return value * 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic primary = 5;
        bool rejected = false;
        try { primary(4); }
        catch (Exception) { rejected = true; }
        Check(rejected, "nondelegate-dynamic-primary-binding-error");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
