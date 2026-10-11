/*
Rules: E15-3-6-member-private-accessibility
Authority: ECMA-334 7th ed 15.3.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: private int ReadCore()
Into: private public int ReadCore()
*/
using System;
class Vault
{
    private int Number = 461;
    private int ReadCore() { return Number; }
    public int Read() { return ReadCore(); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Vault().Read() == 461, "private-field-and-method-accessible-in-declaring-class");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
