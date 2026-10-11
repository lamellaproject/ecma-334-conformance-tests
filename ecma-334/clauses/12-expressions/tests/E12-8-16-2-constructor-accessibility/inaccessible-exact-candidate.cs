/*
Rules: E12-8-16-2-constructor-accessibility
Authority: ECMA-334 7th ed 12.8.16.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: private Choice(int value)
Into: public Choice(int value)
*/
using System;
class Choice
{
    public int Selected;
    private Choice(int value) { Selected = 1; }
    public Choice(long value) { Selected = 2; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Choice result = new Choice(6);
        Check(result.Selected == 2, "only-accessible-constructor-candidates");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
