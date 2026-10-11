/*
Rules: E10-2-12-unknown-dependent; E10-2-12-dependent-box; E10-2-12-dependent-value; E10-2-12-dependent-reference; E10-3-9-unknown-dependent; E10-3-9-dependent-unbox; E10-3-9-dependent-value; E10-3-9-dependent-reference; E10-2-1-categories
Authority: ECMA-334 7th ed 10.2.12
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: IRoot box=Bridge.Up<Stamp,IRoot>(value);
Into: IRoot box=default(IRoot);
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
            public static U Up<T,U>(T x) where T:U { return x; }
            public static T Down<T,U>(U x) where T:U { return (T)x; }
        }

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Stamp value=new Stamp {Number=61}; IRoot box=Bridge.Up<Stamp,IRoot>(value);
        Stamp unbox=Bridge.Down<Stamp,IRoot>(box), same=Bridge.Up<Stamp,Stamp>(value), downSame=Bridge.Down<Stamp,Stamp>(value);
        Deep reference=new Deep(); Parent up=Bridge.Up<Deep,Parent>(reference); Deep down=Bridge.Down<Deep,Parent>(up);
        Check(box.GetType()==typeof(Stamp) && unbox.Number==61 && same.Number==61 && downSame.Number==61 && ReferenceEquals(reference,down), "E10-2-12-unknown-dependent-pilot-001-check-01");
        try { Bridge.Down<Deep,Parent>(new Parent()); Check(false, "E10-2-12-unknown-dependent-pilot-001-check-02"); } catch (InvalidCastException) { Check(true, "E10-2-12-unknown-dependent-pilot-001-check-02"); } catch (Exception error) { Check(false, "E10-2-12-unknown-dependent-unexpected-exception-1"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
