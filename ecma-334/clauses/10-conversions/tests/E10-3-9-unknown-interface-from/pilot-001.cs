/*
Rules: E10-3-9-unknown-interface-from; E10-3-9-interface-box
Authority: ECMA-334 7th ed 10.3.9
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: IExtra fromValue=Bridge.Cast(value);
Into: IExtra fromValue=default(IExtra);
*/
using System;


interface IRoot { int Read(); }
interface ILeaf : IRoot { }
interface IExtra { int Extra(); }
class Parent : IRoot { public int Read() { return 61; } }
class Child : Parent, ILeaf, IExtra { public int Extra() { return 82; } }
class Deep : Child { }
struct Stamp : ILeaf, IExtra { public int Number; public int Read(){return Number;} public int Extra(){return Number+1;} }

        static class Bridge { public static IExtra Cast<T>(T x) { return (IExtra)x; } }

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Stamp value=new Stamp {Number=61}; IExtra fromValue=Bridge.Cast(value);
        Deep reference=new Deep(); IExtra fromReference=Bridge.Cast(reference);
        Check(fromValue.Extra()==62 && fromValue.GetType()==typeof(Stamp) && ReferenceEquals(reference,fromReference), "E10-3-9-unknown-interface-from-pilot-001-check-01");
        try { Bridge.Cast(61); Check(false, "E10-3-9-unknown-interface-from-pilot-001-check-02"); } catch (InvalidCastException) { Check(true, "E10-3-9-unknown-interface-from-pilot-001-check-02"); } catch (Exception error) { Check(false, "E10-3-9-unknown-interface-from-unexpected-exception-1"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
