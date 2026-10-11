/*
Rules: E15-3-8-static-no-receiver; E15-3-8-static-modifier-classifies
Authority: ECMA-334 7th ed 15.3.8
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public static event Signal Changed
Into: public event Signal Changed
*/
using System;
class Register
{
    public delegate void Signal();
    public static int Adds, Removes;
    public static event Signal Changed { add { Adds++; } remove { Removes++; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void OnSignal() { }
    static void Main()
    {
        Register.Changed += OnSignal;
        Check(Register.Adds == 1, "static-event-add-without-instance");
        Register.Changed -= OnSignal;
        Check(Register.Removes == 1, "static-event-remove-without-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
