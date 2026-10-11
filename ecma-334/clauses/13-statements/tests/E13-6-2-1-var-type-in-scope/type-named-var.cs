/*
Rules: E13-6-2-1-var-type-in-scope
Authority: ECMA-334 7th ed 13.6.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: var item = 6;
Into: var item = 7;
*/
using System;
class var
{
    public int Value;
    public static implicit operator var(int n) { return new var { Value = n + 10 }; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var item = 6;
        Check(item.Value == 16, "var-names-type-and-conversion-runs");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
