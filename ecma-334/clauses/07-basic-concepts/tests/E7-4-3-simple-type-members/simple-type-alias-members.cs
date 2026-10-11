/*
Rules: E7-4-3-simple-type-members
Authority: ECMA-334 7th ed 7.4.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int alias = 17;
Into: short alias = 17;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int alias = 17;
        System.Int32 named = 17;
        Check(alias.Equals(named) && alias.GetType() == typeof(System.Int32), "aliased-instance-members");
        Check(int.MaxValue == System.Int32.MaxValue, "aliased-constant-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
