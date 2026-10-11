/*
Rules: E12-5-2-class-bases
Authority: ECMA-334 7th ed 12.5.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: receiver.BaseMethod()
Into: receiver.OtherMethod()
*/
using System;
class Base { public int BaseMethod() { return 11; } public int OtherMethod() { return 17; } }
class Derived : Base { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived receiver = new Derived(); int result = receiver.BaseMethod();
        Check(result == 11, "inherited-class-member");
        Check(receiver.Equals(receiver), "inherited-object-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
