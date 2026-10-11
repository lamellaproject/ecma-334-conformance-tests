/*
Rules: E10-2-9-parameter; E10-2-12-unknown-box-runtime; E10-2-12-unknown-base; E10-2-12-unknown-interface; E10-2-12-boxing-iff; E10-3-7-parameter; E10-3-9-unknown-runtime; E10-3-9-unknown-base; E10-3-9-unknown-interface-to; E10-3-9-unboxing-iff; E15-2-5-base-empty; E15-2-5-interface-empty; E10-3-1-categories
Authority: ECMA-334 7th ed 10.2.9
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: public static object Box<T>(T x) { return x; }
Into: public static object Box<T>(T x) { return null; }
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
            public static object Box<T>(T x) { return x; }
            public static T FromObject<T>(object x) { return (T)x; }
            public static IRoot Interface<T>(T x) where T:IRoot { return x; }
            public static T FromInterface<T>(IRoot x) { return (T)x; }
        }

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Stamp value=new Stamp {Number=61}; object box=Bridge.Box(value);
        Stamp restored=Bridge.FromObject<Stamp>(box);
        Deep reference=new Deep(); object preserved=Bridge.Box(reference); Deep round=Bridge.FromObject<Deep>(preserved);
        Check(restored.Number==61 && box.GetType()==typeof(Stamp) && ReferenceEquals(reference,round), "E10-2-9-parameter-pilot-001-check-01");
        Check(Bridge.Interface(value).Read()==61 && Bridge.Interface(reference).Read()==61, "E10-2-9-parameter-pilot-001-check-02");
        Check(Bridge.FromInterface<Stamp>((IRoot)value).Number==61, "E10-2-9-parameter-pilot-001-check-03");
        try { Bridge.FromObject<Stamp>(null); Check(false, "E10-2-9-parameter-pilot-001-check-04"); } catch (NullReferenceException) { Check(true, "E10-2-9-parameter-pilot-001-check-04"); } catch (Exception error) { Check(false, "E10-2-9-parameter-unexpected-exception-1"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        try { Bridge.FromObject<Deep>(new Parent()); Check(false, "E10-2-9-parameter-pilot-001-check-05"); } catch (InvalidCastException) { Check(true, "E10-2-9-parameter-pilot-001-check-05"); } catch (Exception error) { Check(false, "E10-2-9-parameter-unexpected-exception-2"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
