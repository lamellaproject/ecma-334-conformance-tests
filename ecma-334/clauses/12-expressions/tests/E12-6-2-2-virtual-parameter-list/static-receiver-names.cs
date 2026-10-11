/*
Rules: E12-6-2-2-virtual-parameter-list
Authority: ECMA-334 7th ed 12.6.2.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Base receiver = new Derived();
Into: Derived receiver = new Derived();
*/
using System;
class Base { public virtual int Read(int baseName) { return baseName + 10; } }
class Derived : Base { public override int Read(int derivedName) { return derivedName + 20; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Base receiver = new Derived(); int first = receiver.Read(baseName: 3);
        Derived other = new Derived(); int second = other.Read(derivedName: 5);
        Check(first == 23, "base-static-type-parameter-name");
        Check(second == 25, "derived-static-type-parameter-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
