/*
Rules: E12-8-9-2-remove-interface-candidates
Authority: ECMA-334 7th ed 12.8.9.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: receiver.Choose(5)
Into: ((IChoice)receiver).Choose(5)
*/
using System;
interface IChoice { int Choose(int value); }
class Base { public int Choose(object value) { return 1; } }
class Concrete : Base, IChoice { int IChoice.Choose(int value) { return 2; } }
class Program
{
    static int checks, failures;
    static int Invoke<T>(T receiver) where T : Base, IChoice { return receiver.Choose(5); }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Invoke(new Concrete()) == 1, "class-candidate-removes-better-interface-candidate");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
