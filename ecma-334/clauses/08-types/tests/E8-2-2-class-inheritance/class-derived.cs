/*
Rules: E8-2-2-class-inheritance
Authority: ECMA-334 7th ed 8.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: override int Read()
Into: new int Read()
*/
using System;
class Base { public virtual int Read() { return 5; } }
class Derived : Base { public override int Read() { return 19; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Base value = new Derived();
        Check(value.Read() == 19, "derived-specialization");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
