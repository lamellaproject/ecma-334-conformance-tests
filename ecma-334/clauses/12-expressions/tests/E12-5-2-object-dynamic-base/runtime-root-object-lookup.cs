/*
Rules: E12-5-2-object-dynamic-base
Authority: ECMA-334 7th ed 12.5.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: dynamic root = new object();
Into: dynamic root = new Derived();
*/
using System;
class Base
{
    public static int Calls;
    public void Touch() { Calls++; }
}
class Derived : Base { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic root = new object();
        bool caught = false;
        try { root.Touch(); }
        catch (Exception) { caught = true; }
        Check(caught, "runtime-root-has-no-base-member");
        Check(Base.Calls == 0, "root-lookup-cannot-enter-derived-base-method");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
