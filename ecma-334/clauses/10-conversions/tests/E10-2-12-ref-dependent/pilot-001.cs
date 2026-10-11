/*
Rules: E10-2-12-ref-dependent; E10-3-9-ref-dependent; E15-2-5-depends; E15-2-5-base-dependent; E15-2-5-base-specific; E15-2-5-interface-dependent
Authority: ECMA-334 7th ed 10.2.12
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Deep source=new Deep();
Into: Deep source=default(Deep);
*/
using System;


interface IRoot { int Read(); }
interface ILeaf : IRoot { }
interface IExtra { int Extra(); }
class Parent : IRoot { public int Read() { return 61; } }
class Child : Parent, ILeaf, IExtra { public int Extra() { return 82; } }
class Deep : Child { }
struct Stamp : ILeaf, IExtra { public int Number; public int Read(){return Number;} public int Extra(){return Number+1;} }

        static class Bridge {
            public static bool Test<T,U,V>(T input) where T:class,U where U:V,ILeaf where V:Parent {
                U middle=input; V end=input; IRoot root=input; ILeaf leaf=input;
                T restored=(T)middle; Parent ancestor=input;
                return ReferenceEquals(input,middle) && ReferenceEquals(end,input) && ReferenceEquals(restored,input)
                       && ReferenceEquals(ancestor,input) && root.Read()==61 && ReferenceEquals(leaf,input);
            }
        }

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Deep source=new Deep(); Check(Bridge.Test<Deep,Child,Parent>(source), "E10-2-12-ref-dependent-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
