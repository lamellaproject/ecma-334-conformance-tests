/*
Rules: E12-5-1-class-method-hides-interface-nonmethods
Authority: ECMA-334 7th ed 12.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where T : Base, IProbe
Into: where T : IProbe
*/
using System;
interface IProbe { int Pick { get; } }
class Base { public int Pick() { return 17; } }
class Derived : Base, IProbe { int IProbe.Pick { get { return 31; } } }
class Program
{
    delegate int Read();
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Invoke<T>(T receiver) where T : Base, IProbe { Read call = receiver.Pick; return call(); }
    static void Main()
    {
        Check(Invoke<Derived>(new Derived()) == 17, "class-method-group-hides-interface-property");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
