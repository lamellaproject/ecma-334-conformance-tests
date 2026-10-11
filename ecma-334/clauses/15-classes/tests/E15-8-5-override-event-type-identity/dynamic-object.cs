/*
Rules: E15-8-5-override-event-type-identity
Authority: ECMA-334 7th ed 15.8.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public override event Action<object> Signal
Into: public override event Action<string> Signal
*/
using System;
class Source { public virtual event Action<dynamic> Signal; }
class Derived : Source { public Action<object> Added; public override event Action<object> Signal { add { Added = value; } remove { } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived source = new Derived();
        Action<object> handler = value => { };
        ((Source)source).Signal += handler;
        Check(source.Added == handler, "identity-in-delegate-type-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
