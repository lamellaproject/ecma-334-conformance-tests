/*
Rules: E12-8-11-3-remove-interface-indexers
Authority: ECMA-334 7th ed 12.8.11.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: receiver[5]
Into: ((IChoice)receiver)[5]
*/
using System;
interface IChoice { int this[int index] { get; } }
class Base { public int this[object index] { get { return 1; } } }
class Concrete : Base, IChoice { int IChoice.this[int index] { get { return 2; } } }
class Program
{
    static int checks, failures;
    static int Read<T>(T receiver) where T : Base, IChoice { return receiver[5]; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Read(new Concrete()) == 1, "applicable-class-indexer-removes-better-interface-match");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
