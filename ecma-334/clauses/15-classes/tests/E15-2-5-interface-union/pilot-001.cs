/*
Rules: E15-2-5-interface-union
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Stamp source=new Stamp {Number=61};
Into: Stamp source=default(Stamp);
*/
using System;


interface IRoot { int Read(); }
interface ILeaf : IRoot { }
interface IExtra { int Extra(); }
class Parent : IRoot { public int Read() { return 61; } }
class Child : Parent, ILeaf, IExtra { public int Extra() { return 82; } }
class Deep : Child { }
struct Stamp : ILeaf, IExtra { public int Number; public int Read(){return Number;} public int Extra(){return Number+1;} }

        static class Bridge {public static bool Test<T,U>(T x) where T:U,IExtra where U:ILeaf {
            IRoot root=x; IExtra extra=x; ILeaf leaf=x; return root.Read()==61 && extra.Extra()==62 && leaf.Read()==61;
        } }

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Stamp source=new Stamp {Number=61}; Check(Bridge.Test<Stamp,ILeaf>(source), "E15-2-5-interface-union-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
