/*
Rules: E22-5-5-4-caller-member-body; E22-5-5-4-caller-member-eligible
Authority: ECMA-334 7th ed 22.5.5.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: [System.Runtime.CompilerServices.CallerMemberName] string name
Into: string name
*/
using System;
class Caller
{
    public static string Name([System.Runtime.CompilerServices.CallerMemberName] string name = null) { return name; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Caller.Name() == "Main", "caller-member-body");
        Check(Caller.Name("supplied") == "supplied", "explicit-member-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
