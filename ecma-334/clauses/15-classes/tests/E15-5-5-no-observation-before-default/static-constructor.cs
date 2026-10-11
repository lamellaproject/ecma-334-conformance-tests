/*
Rules: E15-5-5-no-observation-before-default
Authority: ECMA-334 7th ed 15.5.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public static int Number;
Into: public static int Number = 3;
*/
using System;
class Holder
{
    public static int Number;
    public static int Early;
    static Holder() { Early = Number; Number = 5; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Holder.Early == 0, "first-static-constructor-read-is-default");
        Check(Holder.Number == 5, "static-constructor-assignment-follows-default-read");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
