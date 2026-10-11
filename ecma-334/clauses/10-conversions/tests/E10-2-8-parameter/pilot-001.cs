/*
Rules: E10-2-8-parameter; E10-2-12-ref-base; E10-2-12-ref-interface; E10-2-12-ref-null; E10-3-5-parameter; E10-3-9-ref-base; E10-3-9-ref-interface-to; E10-3-9-ref-interface-from; E15-2-5-effective-base; E15-2-5-effective-interface; E15-2-5-known-reference; E15-2-5-base-class; E15-2-5-erase-other
Authority: ECMA-334 7th ed 10.2.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Child effective=input;
Into: Child effective=new Child();
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
            public static bool Test<T>(T input) where T:Child {
                Child effective=input; Parent ancestor=input; IRoot root=input; ILeaf leaf=input;
                T empty=null; T restored=(T)ancestor; T fromInterface=(T)root; IExtra extra=(IExtra)input;
                return empty==null && ReferenceEquals(input,effective) && ReferenceEquals(restored,input)
                       && ReferenceEquals(fromInterface,input) && root.Read()==61 && extra.Extra()==82 && ReferenceEquals(leaf,input);
            }
        }

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Deep source=new Deep(); Check(Bridge.Test(source), "E10-2-8-parameter-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
