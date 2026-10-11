/*
Rules: E15-6-10-extension-classification; E15-6-10-extension-regular-static; E15-6-10-extension-instance-syntax
Authority: ECMA-334 7th ed 15.6.10
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public static int Offset(this int receiver, int amount)
Into: public static int Offset(int receiver, int amount)
*/
using System;
static class Extensions
{
    public static int Offset(this int receiver, int amount) { return receiver + amount; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 19;
        Check(Extensions.Offset(value, 4) == 23, "extension-remains-callable-as-an-ordinary-static-method");
        Check(value.Offset(7) == 26, "this-first-parameter-enables-instance-invocation-syntax");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
