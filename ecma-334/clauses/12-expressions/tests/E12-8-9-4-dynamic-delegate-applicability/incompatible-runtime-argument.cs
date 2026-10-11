/*
Rules: E12-8-9-4-dynamic-delegate-applicability
Authority: ECMA-334 7th ed 12.8.9.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: dynamic argument = "pine";
Into: dynamic argument = 5;
*/
using System;
public delegate int Operation(int value);
class Program
{
    static int checks, failures;
    static int calls;
    static int Read(int value) { calls++; return value; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Operation operation = Read;
        dynamic argument = "pine";
        bool rejected = false;
        try { operation(argument); }
        catch (Exception) { rejected = true; }
        Check(rejected, "dynamic-delegate-argument-must-be-applicable");
        Check(calls == 0, "invalid-argument-never-invokes-delegate");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
