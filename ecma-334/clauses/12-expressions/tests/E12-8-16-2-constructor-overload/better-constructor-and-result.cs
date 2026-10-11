/*
Rules: E12-8-16-2-constructor-overload; E12-8-16-2-constructor-applicability; E12-8-16-2-constructor-result-type; E12-8-16-2-constructor-result; E12-8-16-2-parenthesized-form
Authority: ECMA-334 7th ed 12.8.16.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new Choice(8)
Into: new Choice(8L)
*/
using System;
class Choice
{
    public int Selected;
    public Choice(int number) { Selected = 1; }
    public Choice(long number) { Selected = 2; }
    public Choice(string text) { Selected = 3; }
}
class Program
{
    static int Choose(Choice value) { return 1; }
    static int Choose(object value) { return 2; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Choice result = new Choice(8);
        Check(result.Selected == 1, "better-applicable-constructor");
        Check(Choose(result) == 1, "constructor-creation-static-result-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
