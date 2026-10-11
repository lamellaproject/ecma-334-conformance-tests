/*
Rules: E15-2-5-base-value
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: ValueType boxed=Bridge.Cast(source);
Into: ValueType boxed=default(ValueType);
*/
using System;


interface IRoot { int Read(); }
interface ILeaf : IRoot { }
interface IExtra { int Extra(); }
class Parent : IRoot { public int Read() { return 61; } }
class Child : Parent, ILeaf, IExtra { public int Extra() { return 82; } }
class Deep : Child { }
struct Stamp : ILeaf, IExtra { public int Number; public int Read(){return Number;} public int Extra(){return Number+1;} }

        static class Bridge {public static ValueType Cast<T>(T x) where T:struct {return x;} }

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Stamp source=new Stamp {Number=61}; ValueType boxed=Bridge.Cast(source);
        Check(((Stamp)boxed).Number==61, "E15-2-5-base-value-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
