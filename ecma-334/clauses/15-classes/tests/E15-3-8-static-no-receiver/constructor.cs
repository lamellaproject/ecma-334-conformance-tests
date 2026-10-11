/*
Rules: E15-3-8-static-no-receiver; E15-3-8-static-modifier-classifies
Authority: ECMA-334 7th ed 15.3.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: static Register()
Into: public Register()
*/
using System;
class Register
{
    private static int stored;
    static Register() { stored = 163; }
    public static int Read() { return stored; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Register.Read() == 163, "static-constructor-executes-without-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
