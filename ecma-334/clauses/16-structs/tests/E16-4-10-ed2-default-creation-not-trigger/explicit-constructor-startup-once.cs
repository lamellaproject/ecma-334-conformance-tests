/*
Rules: E16-4-10-ed2-default-creation-not-trigger; E16-4-10-explicit-constructor-trigger; E16-4-10-first-trigger
Authority: ECMA-334 2nd ed 18.3.10
Version: ISO-1
Expected: run
Stdout: OK 4
Mutate: Ignition first = new Ignition(68);
Into: Ignition first = new Ignition();
*/
using System;
class IgnitionLog
{
    public static int Initializations, Order;
}
struct Ignition
{
    public int Code;
    static Ignition()
    {
        IgnitionLog.Initializations++;
        IgnitionLog.Order = IgnitionLog.Order * 10 + 3;
    }
    public Ignition(int code)
    {
        Code = code;
        IgnitionLog.Order = IgnitionLog.Order * 10 + 6;
    }
}
class ConstructorStartup
{
    static int checks, failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition)
        {
            failures++;
            Console.WriteLine("FAIL " + name);
        }
    }
    static int Main()
    {
        Ignition empty = new Ignition();
        Check(IgnitionLog.Initializations == 0, "default-before-constructor");
        Ignition first = new Ignition(68);
        Check(IgnitionLog.Initializations == 1 && IgnitionLog.Order == 36, "static-before-explicit-constructor");
        Check(first.Code == 68, "explicit-constructor-value");
        Ignition second = new Ignition(21);
        Check(second.Code == 21 && IgnitionLog.Initializations == 1 && IgnitionLog.Order == 366, "second-constructor-static-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
